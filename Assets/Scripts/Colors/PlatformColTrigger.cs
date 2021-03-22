using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformColTrigger : MonoBehaviour
{
    private Collider2D platformCollider;
    private Collider2D playerCollider;
    private ColoredPlayer player;
    private ColoredNonPlayer platform;
    private bool passThrough;

    void Start()
    {
        platformCollider = transform.parent.GetComponent<Collider2D>();
        passThrough = false;
        platform = this.GetComponentInParent<ColoredNonPlayer>();
    }

    void OnTriggerEnter2D(Collider2D colid)
    {
        passThrough = false;

        if (colid != null && colid.CompareTag("Player"))
        {
            Debug.Log("player");
            playerCollider = colid;
            player = colid.GetComponent<ColoredPlayer>();
            if (player != null && platform != null)
            {
                if (player.IsSameColor(platform))
                {
                    Physics2D.IgnoreCollision(platformCollider, playerCollider, false);
                }
                else
                {
                    Physics2D.IgnoreCollision(platformCollider, playerCollider, true);
                    passThrough = true;
                }
            }
        }
    }


    private void Update()
    {
        if (player != null && platform != null && !passThrough && !player.IsSameColor(platform))
        {
            Rigidbody2D body = player.transform.GetComponent<Rigidbody2D>();
            if (body != null) { body.WakeUp(); }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!passThrough && player != null && platform != null && !player.IsSameColor(platform))
        {
            Physics2D.IgnoreCollision(platformCollider, playerCollider, true);
            passThrough = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Collider2D colid = collision.transform.GetComponent<Collider2D>();
        if (colid != null && colid.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(platformCollider, playerCollider, false);
            player = null;
        }
    }

}
