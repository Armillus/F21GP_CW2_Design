using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenBackground : MonoBehaviour
{
    void Awake()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        float cameraHeight = Camera.main.orthographicSize * 2;
        Vector2 cameraSize = new Vector2(Camera.main.aspect * cameraHeight, cameraHeight);
        Vector2 spriteSize = spriteRenderer.sprite.bounds.size;

        Vector2 scale = transform.localScale;

        scale.x = cameraSize.x / spriteSize.x;
        scale.y = cameraSize.y / spriteSize.y;

        transform.localScale = scale;

        /*if (name.Contains("(L)"))
        {

            transform.position = new Vector2(transform.position.x - cameraSize.x, transform.position.y);
            //transform.localScale = Vector2.one;
        }
        else if (name.Contains("(R)"))
        {
            transform.position = new Vector2(transform.position.x + cameraSize.x, transform.position.y);
            transform.localScale = Vector2.one;
        }
        else if (name.Contains("(U)"))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + cameraSize.y);
            transform.localScale = Vector2.one;
        }
        else if (name.Contains("(D)"))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - cameraSize.y);
            transform.localScale = Vector2.one;
        }*/

    }


}
