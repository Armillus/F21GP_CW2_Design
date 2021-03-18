using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerHealth))]
public class Player : MonoBehaviour
{
    public float speed = 1;
    public float jumpForce = 1;
    public float pushForce = 1;


    public Rigidbody2D rb = null;
    public Animator animator = null;
    public Transform groundCheckLeft;
    public Transform groundCheckRight;
    public Transform firePoint;
    public GameObject bullet;
    public AnimationClip shot;

    private Vector2 _startScale = Vector2.one;
    private bool _isPushed = false;
    private float _timeRemaining = 1;
    private bool isGrounded;
    private int currentHealth = 10;
    void Start()
    {
        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);
        _startScale = transform.localScale;
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);
        if (currentHealth <= 0)
        {
            //            Destroy(gameObject);
            Debug.Log("Dead");
            return;
        }
        Move();
        UpdateAnimation();
        if (_isPushed)
        {
            if (_timeRemaining > 0)
            {
                _timeRemaining -= Time.deltaTime;
            }
            else
            {
                _timeRemaining = 1;
                _isPushed = false;
            }
        }

        if (Input.GetKeyDown("e"))
        {
            Shoot();
        }
    }

    private void Move()
	{
        float h = Input.GetAxis("Horizontal");

        if (!_isPushed)
        {
            rb.velocity = new Vector2(h * speed, rb.velocity.y);
        }

        if (Input.GetAxis("Vertical") > 0 && IsOnFloor())
        {
            Jump();
        }

    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
//        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }

    private bool IsOnFloor()
    {
        return (isGrounded);
    }


    private void UpdateAnimation()
    {
        animator.SetFloat("SpeedX", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("SpeedY", rb.velocity.y);
        animator.SetBool("OnFloor", IsOnFloor());

        if (Input.GetAxis("Horizontal") != 0)
            transform.localScale = new Vector2(Mathf.Sign(Input.GetAxis("Horizontal")) * _startScale.x, _startScale.y);
    }   

    public void Pushed(float direction)
    {
        rb.AddForce(new Vector2(pushForce * direction, 0), ForceMode2D.Impulse);
        _isPushed = true;
        currentHealth -= 3;
    }

    private void Shoot()
    {
        animator.SetTrigger("Shoot");
        if (transform.localScale.x > 0)
        {
            Instantiate(bullet, firePoint.position, Quaternion.Euler(0f, 0f, 0f));
        }
        else
        {
            Instantiate(bullet, firePoint.position, Quaternion.Euler(0f, 180f, 0f));
        }
    }
}
