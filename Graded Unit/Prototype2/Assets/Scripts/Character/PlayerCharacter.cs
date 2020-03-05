using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Callum
// 22/02/2020
//Player Controls
public class PlayerCharacter : MonoBehaviour
{//Speed at which the player moves
    public float moveSpeed = 5f;
    //Fall Multiplier
    public float fallMultipler = 2.5f;
    public float lowJumpMultiplier = 2f;
    //Changes the height at which the player jumps
    public float jumpheight = 10;
    //hitbox specifically for the ground
    public Transform feetPos;
    //Checks the radius below the "feet"
    public float checkRadius;
    //For checking what type of ground is below
    public LayerMask GroundType;
    //Checks if the player is on the ground or not
    private bool isGrounded;
    //Boolean that turns on each time the player touches the ground. To allow a player a double jump but no more
    private bool doublejump;
    //A variable to reference the rigid body of the character
    Rigidbody2D rb;
    //States the time of a s
    public float cooldownTime = 2;
    //Time until the player can reuse the dash
    private float nextdashtime = 3;
    //References the component audiosource and creates a variable needed for the coin sound in respect to the AudioSource
    public AudioSource coinSound;
  //A boolean made to determine what direction the player is looking in
    private bool facingRight;
    //A float made to check a change in the direction checking if the velocity is currently positive or negative. 
    float direction;
    // Start is called before the first frame update
    void Start()
    {
        //Calls on the component RigidBody
        rb = GetComponent<Rigidbody2D>();
        //Gets the component AudioSource 
        coinSound = GetComponent<AudioSource>();
        facingRight = true;
    }

    

    // Update is called once per frame
    void Update()
    {
        //Calls all methods
        
        Jump();
        CheckGround();
        Dash();
        
    }
    private void FixedUpdate()
    {
        //Calls BasicMovement in fixed update
        BasicMovement();
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
        if (direction >0 && !facingRight)
        {
            //runs the function Flip
            Flip();
            //if the players direction is negative and they're not looking to the right then the player is flipped
        } else if (direction <0 && facingRight)
        {
            //runs the function Flip
            Flip();
        }


    }
    //Method for jumping
    void Jump()
    {
        //Checks if the space bar is pressed and if the player is on the ground (if not then they wont jump, this is to avoid infinite jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            
            //if the space bar is pressed the player gets moved up by the set variable "jumpheight" 
            rb.velocity = (new Vector2(0f, jumpheight));
        }

        //If the player isnt touching the ground BUT does have a double jump still remaining then the if statement below will trigger
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == false && doublejump==true )
        {
            //Adds a double jump equal to the original jump (though this can be easily changed by changing the "jumpheight" to something else
            rb.velocity = (new Vector2(0f, jumpheight));
            //Turns the doublejump boolean to false so they cant jump again
            doublejump = false;
        }

        //If on the ground the ability to use a double jump is made true again
        if (isGrounded == true)
            {
            doublejump = true;
        }


        //For quicker descent to the ground, if the player starts falling the below if statement will trigger
            if (rb.velocity.y < 0)
        {//the player starts falling quicker as they fall more (-1 being to make sure they dont fall fast and Unity by default has a multiplier at 1 thus without this it would be too fast
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultipler - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
    //A method for checking if they're on the ground
    void CheckGround()
    {
        //Checks if the player is on the ground by using a small little invisible circle, the circle also detects the layer allowing for it to only jump on ground if another platform is added such as water
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, GroundType);
        //prints their state, no reason to be here just for debugging
       
    }

    void Dash()
    {
        //Gives a cooldown period of 3 seconds until they can dash again
        if (Time.time > nextdashtime)
        {
            //If the left shift key is pressed then the if statement will trigger
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                //if the player is facing to the right the code for dashing to the right will active and the player will get velocity going right
                if (facingRight == true)
                {
                    //States in the log the cooldown is starting again
                    print("Cooldown started");
                    //Gives 10 units of speed to the right
                    rb.velocity += Vector2.right * 10;
                    //resets the cooldown timer
                    nextdashtime = Time.time + cooldownTime;
                }
                //However if the player is looking left instead of right then the player will receive velocity going left
                else if(facingRight == false)
                {
                    //States in the log the cooldown is starting again
                    print("Cooldown started");
                    //Gives 10 units of speed to the left
                    rb.velocity += Vector2.left * 10;
                    //resets the cooldown timer
                    nextdashtime = Time.time + cooldownTime;
                }

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
        }
    }
}
