using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoorMonkey : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(this);
        }
        else if(collision.CompareTag("DeathPlane"))
        {
            Destroy(this);
        }

    }
}


