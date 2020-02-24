using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    //Specifically in the module "Update" due to how a fixedupdate would cause a laggy camera and thus the camera needs to be constantly updated
    void Update()
    {
        //Makes the camera follow the player in the x and y coordinates taking into account the z wont move
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
