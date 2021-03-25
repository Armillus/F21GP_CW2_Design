using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredatorTracker : MonoBehaviour
{
    public float speed = 1;
    public int damages = 15;
    public Transform target;
    public Animator animator = null;
    public Rigidbody2D rb = null;
    public Transform leftZonePoint;
    public Transform rightZonePoint;

    private Vector2 _startScale = Vector2.one;
    private float _direction = 1.0f;
    private int health = 10;

    void Start()
    {
        _startScale = transform.localScale;
    }

    void Update()
    {
        if (health <= 0 || !target)
        {
            return;
        }
        UpdateAnimation();
        rb.velocity = new Vector2(0.0f, 0.0f);

        if (IsTargetVisible())
            Move();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (!this.GetComponent<ColoredNonPlayer>().IsSameColor(col.gameObject))
            {
                col.gameObject.GetComponent<Player>().Pushed(_direction);
                col.gameObject.GetComponent<PlayerHealth>().TakeDamage(damages);
            }
            else
            {
                col.gameObject.GetComponent<Player>().FeedPlayer(); // duplicate to feed more
                this.TakeDamage(health);
            }
        }
    }

    private void Move()
    {
        if (transform.position.x >= leftZonePoint.position.x  &&
            transform.position.x <= rightZonePoint.position.x)
        {
            rb.velocity = new Vector2(_direction * speed, 0.0f);
        }

    }

    private void UpdateAnimation()
    {
        animator.SetFloat("SpeedX", Mathf.Abs(rb.velocity.x));
        if (target.position.x - transform.position.x > 0)
        {
            _direction = 1;
        }
        else
        {
            _direction = -1;
        }
        transform.localScale = new Vector2(Mathf.Sign(_direction) * _startScale.x, _startScale.y);
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
            if (box != null)
            {
                box.enabled = false;
            }
            rb.gravityScale = 0;
            rb.velocity = new Vector2(0f, 0f);
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


    private bool IsTargetVisible()
    {
        if (target.position.x >= leftZonePoint.position.x && 
            target.position.x <= rightZonePoint.position.x)
        {
            return target.position.y >= transform.position.y - 1 && target.position.y <= transform.position.y + 1;
        }
        
        return false;
    }
}
