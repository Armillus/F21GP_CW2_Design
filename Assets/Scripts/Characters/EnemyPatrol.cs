using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public int damages = 10;
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
            if (!this.GetComponent<ColoredNonPlayer>().IsSameColor(col.gameObject))
            {
                if (col.transform.position.x - transform.position.x < 0)
                {
                    direction = -1;
                }
                col.gameObject.GetComponent<Player>().Pushed(direction);
                col.gameObject.GetComponent<PlayerHealth>().TakeDamage(damages);
            }
            else
            {
                col.gameObject.GetComponent<Player>().FeedPlayer();
                this.TakeDamage(health);
            }
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
            CapsuleCollider2D caps = this.GetComponent<CapsuleCollider2D>();
            if (caps != null)
            {
                caps.enabled = false;
            }
            BoxCollider2D box = this.GetComponent<BoxCollider2D>();
            if(box != null)
            {
                box.enabled = false;
            }
            Invoke("FadeOut", 0.7f);
        }
    }

    private void FadeOut()
    {
        Color c = this.transform.GetComponent<SpriteRenderer>().color;
        this.transform.GetComponent<SpriteRenderer>().color = new Color(c.r, c.g, c.b, 0.8f);
        Invoke("DestroyObj", 1.0f);
    }

    private void DestroyObj()
    {
        Destroy(this.transform.parent.gameObject);
    }
    
}
