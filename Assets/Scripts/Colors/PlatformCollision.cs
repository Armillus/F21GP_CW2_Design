using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollision : MonoBehaviour
{
    private Collider2D platformCollider;
    private ColoredPlayer player;
    private ColoredNonPlayer platform;
    private bool passThrough;

    private void Start()
    {
        passThrough = false;
        platform = this.GetComponentInParent<ColoredNonPlayer>();
        platformCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if(player!=null && platform!=null && !passThrough && !player.isSameColor(platform))
        {
            Rigidbody2D body = player.transform.GetComponent<Rigidbody2D>();
            if (body != null) { body.WakeUp(); }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        passThrough = false;
        Collider2D colid = collision.transform.GetComponent<Collider2D>();
        if(colid!=null && colid.CompareTag("Player"))
        {
            player = colid.GetComponent<ColoredPlayer>();
            if (player != null && platform != null)
            {
                if (player.isSameColor(platform))
                {
                    Physics2D.IgnoreCollision(platformCollider, colid, false);
                }
                else
                {
                    Physics2D.IgnoreCollision(platformCollider, colid, true);
                    passThrough = true;
                }
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!passThrough && player != null && platform != null && !player.isSameColor(platform))
        {
            Physics2D.IgnoreCollision(platformCollider, collision.transform.GetComponent<Collider2D>(), true);
            passThrough = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Collider2D colid = collision.transform.GetComponent<Collider2D>();
        if (colid!=null && colid.CompareTag("Player"))
        {
            player = null;
        }
    }
}
