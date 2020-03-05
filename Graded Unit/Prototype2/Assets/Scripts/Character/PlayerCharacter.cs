using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Callum
// 22/02/2020
//Player Controls
public class PlayerCharacter : MonoBehaviour
{//Speed at which the player moves
    private float moveSpeed = 8f;
    //Fall Multiplier
    private float fallMultipler = 5f;
    private float lowJumpMultiplier = 5f;
    //Changes the height at which the player jumps
    private float jumpForce = 8;
    //For checking what type of ground is below
    public LayerMask GroundType;
    //Boolean that turns on each time the player touches the ground. To allow a player a double jump but no more
    private bool doublejump;
    //A variable to reference the rigid body of the character
    Rigidbody2D rb;
    //A variable to reference the BoxCollider of the character
    BoxCollider2D bc;
    //How long in seconds the dash takes to be usable again
    private float dashCooldown = 2;
    //Time until the player can reuse the dash
    private float nextdashtime;
    //How long in seconds the dash lasts
    private float dashTime = 1;
    //References the component audiosource and creates a variable needed for the coin sound in respect to the AudioSource
    public AudioSource coinSound;
    //Keeps count of coins
    private int coins;
  //A boolean made to determine what direction the player is looking in
    private bool facingRight;
    //A float made to check a change in the direction checking if the velocity is currently positive or negative. 
    float direction;
    // Start is called before the first frame update
    bool jumpRequest;
    bool doubleJumpRequest;
    void Start()
    {
        //Calls on the component RigidBody
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        //Gets the component AudioSource 
        coinSound = GetComponent<AudioSource>();
        facingRight = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            jumpRequest = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && doublejump == true)
        {
            doubleJumpRequest = true;
        }
  }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Calls all methods
        BasicMovement();
        Jump();
        Dash();
        
    }
    //Method for movement
    void BasicMovement()
    {
        //Gets input from the Unity Horizontal function for movement using A or D (or left arrow or right arrow)
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        //Moves at a fixed rate 
        transform.position += movement * Time.deltaTime * moveSpeed;
        //Gives value to the direction as a float. This is used to compare which way the player is looking
        direction = (Input.GetAxis("Horizontal"));
        //If the players direction is positive and they're not looking to the right then the player is flipped
        if (direction > 0 && !facingRight)
        {
            //runs the function Flip
            Flip();
            //if the players direction is negative and they're not looking to the right then the player is flipped
        } else if (direction < 0 && facingRight)
        {
            //runs the function Flip
            Flip();
        }


    }
    //Method for jumping
    void Jump()
    {
        //Checks if the space bar is pressed and if the player is on the ground (if not then they wont jump, this is to avoid infinite jumping
        if (jumpRequest)
        {

            //if the space bar is pressed the player gets moved up by the set variable "jumpForce" 

            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpRequest = false;
        }

        //If the player isnt touching the ground BUT does have a double jump still remaining then the if statement below will trigger
        if (doubleJumpRequest)
        {
            //Adds a double jump equal to the original jump (though this can be easily changed by changing the "jumpForce" to something else
            rb.velocity = (new Vector2(0f, jumpForce));

            //Turns the doublejump boolean to false so they cant jump again
            doublejump = false;
            doubleJumpRequest = false;
        }

        //If on the ground the ability to use a double jump is made true again
        if (IsGrounded())
        {
            doublejump = true;
        }


        //For quicker descent to the ground, if the player starts falling the below if statement will trigger
        if (rb.velocity.y < 0)
        {//the player starts falling quicker as they fall more (-1 being to make sure they dont fall fast and Unity by default has a multiplier at 1 thus without this it would be too fast
            rb.gravityScale = fallMultipler;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.gravityScale = lowJumpMultiplier;
        }
        else
        {
            rb.gravityScale = 1;
        }
    }
    //A method for checking if they're on the ground
    private bool IsGrounded()
    {

        RaycastHit2D raycastHit = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, 0.5f, GroundType);
        return raycastHit.collider != null;
    }

    void Dash()
    {
        //Gives a cooldown period of 3 seconds until they can dash again
        if (Time.time > nextdashtime)
        {
            //If the left shift key is pressed then the if statement will trigger
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                //States in the log the cooldown is starting again
                print("Cooldown started");
                //Gives 10 units of speed to the right
                rb.velocity = new Vector2(Input.GetAxis("Horizontal") * 10, 0f);
                //resets the cooldown timer
                nextdashtime = Time.time + dashCooldown;


            }
        }

        
    }
    private void Flip()
    {
        //Inverts the direction the player 
        facingRight = !facingRight;
        //Rotates the player in the y axis to change for shooting
        transform.Rotate(0f, 180f, 0f);
        

       
        
    }
    //Checks for collisions
    private void OnTriggerEnter2D(Collider2D other)
    {
        //If the player is touching a coin the following if statement is executed
        if (other.gameObject.CompareTag("Coins"))
        {
            //Destroys the coin so it cant be continuously picked up
            Destroy(other.gameObject);
            //Plays the coin sound effect "Coin_Sound_effect.wav"
            coinSound.Play();
            coins += 1;
        }
    }
}
