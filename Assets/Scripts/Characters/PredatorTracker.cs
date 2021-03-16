using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredatorTracker : MonoBehaviour
{
    public float speed = 1;
    public GameObject player;
    public Animator animator = null;
    public Rigidbody2D rb = null;

    private Transform _target;
    private Vector2 _startScale = Vector2.one;
    private float _direction = 1.0f;
    private int health = 10;
    void Start()
    {
        _startScale = transform.localScale;
        _target = player.transform;
    }

    void Update()
    {
        if (health <= 0)
        {
            return;
        }
        if (_target.position.x - transform.position.x > 0)
        {
            _direction = 1;
        }
        else
        {
            _direction = -1;
        }
        Move();
        UpdateAnimation();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Player>().Pushed(_direction);
        }
    }

    private void Move()
    {
       rb.velocity = new Vector2(_direction * speed, 0.0f);
       //transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
    }

    private void UpdateAnimation()
    {
        animator.SetFloat("SpeedX", Mathf.Abs(rb.velocity.x));
        if (_target.position.x - transform.position.x > 0)
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
        }
    }
}
