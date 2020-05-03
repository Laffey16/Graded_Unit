using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeJumping : MonoBehaviour
{
    
    private float jumpForce;
    private float RandomJump;
    public LayerMask GroundType;
    public Transform GroundDetection;
    Rigidbody2D rb;
    private float direction;
    // Start is called before the first frame update
    void Start()
    {
        RandomJump = Random.Range(3, 5);
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("Jump", 0f, RandomJump);

    }
    private void Update()
    {
        
    }


    // Update is called once per frame
    void Jump()
    {
        direction = Random.Range(-10, 10);
        RaycastHit2D GroundDetector = Physics2D.Raycast(GroundDetection.position, Vector2.down, 3, GroundType);
        if (GroundDetector == true)
        { 
            jumpForce = Random.Range(6, 20);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            rb.velocity = new Vector2(rb.velocity.y, direction);
            
        }
    }
}
