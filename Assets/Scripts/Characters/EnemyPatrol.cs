using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    public float speed;
    public Transform[] waypoints;
    public SpriteRenderer graphics;
    public Animator animator = null;

    private Transform target;
    private int destPoint = 0;
    private int health = 10;
    void Start()
    {
        target = waypoints[0];
    }

    void Update()
    {
        if (health <= 0)
        {
            return;
        }
        Move();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        float direction = 1;

        if (col.gameObject.tag == "Player")
        {
            if (col.transform.position.x - transform.position.x < 0)
            {
                direction = -1;
            }
            col.gameObject.GetComponent<Player>().Pushed(direction);
        }
    }

    private void Move()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) < 0.2f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
            graphics.flipX = !graphics.flipX;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            animator.SetBool("Dead", true);
        }
    }
}
