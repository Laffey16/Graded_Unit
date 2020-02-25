using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AaronPlayerMovement : MonoBehaviour
{
    //Multiplies the gravity
    public float gravityModifier = 1f;
    public float minGroundNormalY = 0.65f;

    protected Rigidbody2D rb2d;
    protected bool grounded;
    protected Vector2 velocity;
    protected ContactFilter2D contactFilter;
    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
    protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D>(16);


    protected const float minMoveDistance = 0.001f;
    protected const float shellRadius = 0.01f;

    //When this is enabled, this is the code called first
    void OnEnable()
    {
        //sets the rb2d rigidbody to the one currently used by the parent object
        rb2d = GetComponent<Rigidbody2D> ();
    }
    // Start is called before the first frame update
    void Start()
    {
        //Ensures the contact filter doesn't check contact with triggers
        contactFilter.useTriggers = false;
        //Uses the Player layer collision mask
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        contactFilter.useLayerMask = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Like update except it's called on DeltaTime
    void FixedUpdate()
    {
        velocity += gravityModifier * Physics2D.gravity * Time.deltaTime;

        //Decides whether the player is on the ground. This is set to false before movement is triggered so that if the player actually is on the ground then this can be set to true.
        grounded = false;

        Vector2 deltaPosition = velocity * Time.deltaTime;

        Vector2 move = Vector2.up * deltaPosition.y;

        Movement(move, true);
    }

    void Movement(Vector2 move, bool yMovement)
    {
        float distance = move.magnitude;

        if(distance>minMoveDistance)
        {
            //Checks if there's an obstacle ahead of the player by casting the Rigidbody2D forward and seeing if it overlaps anything
            int count = rb2d.Cast(move, contactFilter, hitBuffer, distance + shellRadius);
            hitBufferList.Clear();
            for (int i = 0; i < count; i++)
            {
                hitBufferList.Add(hitBuffer[i]);
            }
            for (int i = 0; i < hitBufferList.Count; i++)
            {
                Vector2 currentNormal = hitBufferList[i].normal;
                //Checks if the player is above ground
                if (currentNormal.y > minGroundNormalY)
                {
                    grounded = true;
                }
            }
        }
        rb2d.position = rb2d.position + move;
    }
}
