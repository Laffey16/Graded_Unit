using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeJumping : MonoBehaviour
{
    
    public float jumpForce;
    private float RandomJump;
    public LayerMask GroundType;
    public Transform GroundDetection;
    Rigidbody2D rb;
    private CircleCollider2D CC2;
    private BoxCollider2D BC;
    private float direction;
    public float speed;
    public float aggrospeed;
    public float radius;
    public LayerMask PlayerID;
    private Coroutine SlimeIdle;
    private Coroutine SlimeAgro;
    private bool isgrounded;
    public Transform player;
    private EnemyHealth HealthObj;
    public Slider slider;
    public AudioClip DamageSound;
    public GameObject DamageEffect;
    private AudioSource EnemySource;
    public float health;
    // Start is called before the first frame update
    void Start()
    {
        EnemySource = GetComponent<AudioSource>();
        RandomJump = Random.Range(2,4);
        rb = GetComponent<Rigidbody2D>();
        HealthObj = GameObject.FindObjectOfType<EnemyHealth>();

    }
    private void FixedUpdate()
    {
    }
    private void Update()
    {
        //Sends a raycast down checking if the ground is below them
        RaycastHit2D grounddetector = Physics2D.Raycast(GroundDetection.position, Vector2.down, 1, GroundType);
        {
            //If the ground is below them they can jump
            if (grounddetector.collider == true)
            {
                isgrounded = true;
            }
            else
            {
                //If the ground isnt below then they cant jump
                isgrounded = false;
            }
        }
        print(isgrounded);

    }

    IEnumerator IdleStance()
    {
        print("Idling");
        //Calm slimy boy
        direction = 1;
        while (true)
        {
            //sets a random jump time
            RandomJump = Random.Range(3, 5);
            //Randomly jumps back and forth
            rb.velocity = (new Vector2(speed * direction, 0));
            direction *= -1;
            yield return new WaitForSeconds(RandomJump);
           
        }
    }
   private void SlimeActions()
    {
        Collider2D PlayerDetection = Physics2D.OverlapCircle(transform.position, radius, PlayerID);
        if(PlayerDetection != null)
        {
            //If the player is detected then the slime will become aggro'd and start attacking the player
            StartCoroutine("Agro");
        }
        else
        {
            print("PlayerEscaped");
            //If the player isnt detected or is no longer detected then the slime will no longer attack the player
            StopCoroutine("Agro");
        }
       

    }
    IEnumerator Agro()
    {
        while (true)
        {
            print("I am aggressive");

            // 1 if player is to the right of the slime, If -1 if to the left
            int direction = (this.transform.position.x < player.transform.position.x) ? 1 : -1;
            print(direction);
           
            if(isgrounded==true)
            {
                    // Jump towards the player
                    rb.velocity = (new Vector2(aggrospeed * direction, jumpForce));
            }
            if (direction == 1)
            {
                transform.eulerAngles = new UnityEngine.Vector3(0, -180, 0);
            }
            else if (direction == -1)
            {
                transform.eulerAngles = new UnityEngine.Vector3(0, 0, 0);
            }
            yield return new WaitForSeconds(3);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet"))
        {

        }
    }
    private void OnDrawGizmosSelected()
    {
        //Makes the wireframe red
        Gizmos.color = Color.red;
        //Creates the wireframe from the shooting point and uses the variable attackRange to represent how big or small it is.
        Gizmos.DrawWireSphere(transform.position, radius);
    }
   
}
   


    
        
    

