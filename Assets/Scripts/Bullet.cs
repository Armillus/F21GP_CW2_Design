using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1f;
    public Rigidbody2D rb;
    
    private float start;
    private float distance = 3;
    void Start()
    {
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
        if (hitInfo.name == "Player")
        {
            return;
        }

        EnemyPatrol enemy = hitInfo.GetComponent<EnemyPatrol>();
        PredatorTracker enemy2 = hitInfo.GetComponent<PredatorTracker>();

        if (enemy != null)
        {
            enemy.TakeDamage(10);
        }
        else if (enemy2 != null)
        {
            enemy2.TakeDamage(10);
        }
        Destroy(gameObject);
    }
}
