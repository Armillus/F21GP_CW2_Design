using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{

    private Vector2 startpos;
    public GameObject cam;
    public float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position;
        //Debug.Log(startpos);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distx = (cam.transform.position.x * parallaxEffect);
        float disty = (cam.transform.position.y * parallaxEffect);
        
        transform.position = new Vector3(startpos.x + distx, startpos.y + disty, transform.position.z);
    }
}
