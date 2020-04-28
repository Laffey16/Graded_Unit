using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using Vector2 = UnityEngine.Vector2;
//WILL BE EXPANEDED UPON
public class EnemyBehaviour : MonoBehaviour
{//Enemy health
    public int health=5;
//A way to reference the enemies health bar
    public Slider slider;
    //The speed the enemy moves
    public float speed;
    //For checks if they're facing right
    private bool facingright = true;
    public LayerMask GroundType;
    //References the ground detector in front of the enemy
    public Transform GroundDetection;
    private void Start()
    {
        HealthBar();
    }
    private void HealthBar()
    {
        //When the enemy spawns it makes sure the healthbar is full.
        slider.maxValue = health;
    }
    private void FixedUpdate()
    {
        
        EnemyAI();
        
    }
    private void EnemyAI()
    {
        //The enemy constant moves to the right
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        //From a spot infront of the enemy the enemy sents a ray 3 unit to the left and checks if its ground using layermasks 
        RaycastHit2D Walldetector = Physics2D.Raycast(GroundDetection.position, Vector2.left, 3,GroundType);
        //If the ray does detect something
        if (Walldetector.collider == true)
        {
            //And its currently facing right
            if (facingright == true)
            {
                //Will rotate the Y axis by -180 to turn around
                transform.eulerAngles = new UnityEngine.Vector3(0, -180,0);
                slider.transform.eulerAngles = new UnityEngine.Vector3(0, 0, 0);
                //Will then set facingright false as its no longer false right
                facingright = false;
            }//If its not facing right
            else if(facingright==false)
            {
                //The rotate it to face right
                transform.eulerAngles = new UnityEngine.Vector3(0, 0,0);
                slider.transform.eulerAngles = new UnityEngine.Vector3(0, 0, 0);
                //Sets right to true
                facingright = true;
            }
            //If the enemy runs into another enemy then 
            if(Walldetector.collider.gameObject.CompareTag("Enemies"))
            {//DEBUG
                print("Yay");
                //Will turn around
                transform.eulerAngles = new UnityEngine.Vector3(0, -180, 0);
                slider.transform.eulerAngles= new UnityEngine.Vector3(0, 0, 0);
                //Sets facingright to false
                facingright = false;
            }
        }
        //This time the ray is going down and will check if ground is still infront of them
        RaycastHit2D grounddetector = Physics2D.Raycast(GroundDetection.position, Vector2.down, 3, GroundType);
        //If not
        if (grounddetector.collider == false)
        {
            //And facing right
            if (facingright == true)
            {
                //The enemy will turn around
                transform.eulerAngles = new UnityEngine.Vector3(0, -180, 0);
                slider.transform.eulerAngles = new UnityEngine.Vector3(0, 0, 0);
                //Sets facing right to false
                facingright = false;
            }
            //If not facing right 
            else
            {
                //Turns around
                transform.eulerAngles = new UnityEngine.Vector3(0, 0, 0);
                slider.transform.eulerAngles = new UnityEngine.Vector3(0, 0, 0);
                //And turns right again
                facingright = true;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Everytime a collision occurs makes sure the slider health is the same as the enemy health
        slider.value = health;
        //And this object happens to interact with a bullet
        if (other.CompareTag("Bullet"))
        {
            //minus 1 health
            health -= 1;
        }
        //If their health is equal to 0 they die
        if (health<=0)
        {
            //Destroys the enemy
            Destroy(gameObject);
           
        }
    }
    


}
