using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundShifting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float cameraHeight = Camera.main.orthographicSize * 2;
        Vector2 cameraSize = new Vector2(Camera.main.aspect * cameraHeight, cameraHeight);

        if (name.Contains("(L)"))
        {
            transform.position = new Vector2(transform.position.x - cameraSize.x, transform.position.y);
        }
        else if (name.Contains("(R)"))
        {
            transform.position = new Vector2(transform.position.x + cameraSize.x, transform.position.y);
        }
        else if (name.Contains("(U)"))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + cameraSize.y);
        }
        else if (name.Contains("(D)"))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - cameraSize.y);
        } else if (name.Contains("(LD)"))
        {
            transform.position = new Vector2(transform.position.x - cameraSize.x, transform.position.y - cameraSize.y);
        }
        else if (name.Contains("(RD)"))
        {
            transform.position = new Vector2(transform.position.x + cameraSize.x, transform.position.y - cameraSize.y);
        }
        else if (name.Contains("(LU)"))
        {
            transform.position = new Vector2(transform.position.x - cameraSize.x, transform.position.y + cameraSize.y);
        }
        else if (name.Contains("(RU)"))
        {
            transform.position = new Vector2(transform.position.x + cameraSize.x, transform.position.y + cameraSize.y);
        }


    }

}
