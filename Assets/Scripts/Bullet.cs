using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1f;
    public Rigidbody2D rb;
    
    private float start;
    private float distance = 3;
    private Color _color;
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        _color = player.GetComponent<ColoredPlayer>().getColor(player.GetComponent<ColoredPlayer>().GetColor());
        start = transform.position.x;
        rb.velocity = transform.right * speed;
    }

    void Update()
    {
        if (Mathf.Abs(transform.position.x - start) >= distance)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        ColoredNonPlayer nonPlayer = null;

        if (hitInfo.name == "Player")
        {
            return;
        }

        if (hitInfo.name == "EnemyGraphics" || hitInfo.name == "PredatorGraphics")
            nonPlayer = hitInfo.gameObject.GetComponent<ColoredNonPlayer>();

        if (nonPlayer != null && !nonPlayer.IsSameColors(_color))
        {
            if (hitInfo.gameObject.GetComponent<EnemyPatrol>())
            {
                hitInfo.gameObject.GetComponent<EnemyPatrol>().TakeDamage(10);
            }
            else if (hitInfo.gameObject.GetComponent<PredatorTracker>())
            {
                hitInfo.gameObject.GetComponent<PredatorTracker>().TakeDamage(10);
            }
        }

        Destroy(gameObject);
    }
}
