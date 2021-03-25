using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{

    private Vector2 startpos;
    private float lengthX, lengthY;
    public GameObject cam;
    public float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position;
        lengthX = GetComponent<SpriteRenderer>().bounds.size.x;
        lengthY = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        float tempX = (cam.transform.position.x * (1 - parallaxEffect));
        float tempY = (cam.transform.position.y * (1 - parallaxEffect));
        float distX = (cam.transform.position.x * parallaxEffect);
        float distY = (cam.transform.position.y * parallaxEffect);
        
        transform.position = new Vector3(startpos.x + distX, startpos.y + distY, transform.position.z);
        
        if (tempX > startpos.x + lengthX) {
            startpos.x += lengthX;
        } else if (tempX < startpos.x - lengthX) {
            startpos.x -= lengthX;
        }

        if (tempY > startpos.y + lengthY)
        {
            startpos.y += lengthY;
        }
        else if (tempY < startpos.y - lengthY)
        {
            startpos.y -= lengthY;
        }

    }
}
