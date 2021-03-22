using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject player;
    public float timeOffset = 0.2f;
    public Vector3 posOffset;

    private Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        if (player)
        {
            if (player.transform.position.y >= 0)
            {
                transform.position = Vector3.SmoothDamp(transform.position + posOffset, player.transform.position, ref velocity, timeOffset);
            }
            else
            {
                transform.position = Vector3.SmoothDamp(transform.position + posOffset, new Vector3(player.transform.position.x, 0.0f, player.transform.position.z), ref velocity, timeOffset);
            }
        }
    }
}
