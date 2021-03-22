using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject player;
 
    void FixedUpdate()
    {
        if (player)
        {
            if (player.transform.position.y >= 0)
            {
                transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(player.transform.position.x, 0.0f, transform.position.z);
            }
        }
    }
}
