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
    public Transform spawnPoint;
    public GameObject bullet;
    public AnimationClip shot;
    public HungerBar hungBar;

    private Vector2 _startScale = Vector2.one;

    private float _timeRemaining = 0.5f;
    private float _timeDead = 1f;
    private float _timeBullet = 0.5f;

    private bool _isPushed = false;
    private bool _isGrounded;
    private bool _onGround;
    private bool _dead = false;
    private bool _shooting = false;

    private int incGround = 5;
    private int nbGround = 5;

    void Start()
    {
        _isGrounded = false;
        _onGround = false;
        _startScale = transform.localScale;
    }

    void OnCollisionStay2D()
    {
        if (incGround < nbGround)
        {
            incGround++;
        }
        else if (incGround >= nbGround)
        {
            _onGround = true;
        }
    }

    void Update()
    {
        _isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);
        UpdateAnimation();
        if (GetComponent<PlayerHealth>().IsOver())
        {
            DeathState();
            return;
        }
        ClickCheck();
        TimeCheck();
        if (!_isPushed)
        {
            Move();
            if (Input.GetKeyDown("e"))
            {
                Shoot();
            }
        }
    }

    private void DeathState()
    {
        _dead = true;
        if (_timeDead > 0)
        {
            _timeDead -= Time.deltaTime;
        }
        else
        {
            _dead = false;
            _timeDead = 1f;
            Revival();
        }
    }

    private void Revival()
    {
        UpdateAnimation();
        GetComponent<PlayerHealth>().Heal(100f);
        transform.position = spawnPoint.position;
    }

    private void ClickCheck()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.GetComponent<ColoredPlayer>().ApplyPreviousColor();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            this.GetComponent<ColoredPlayer>().ApplyNextColor();
        }
    }

    private void TimeCheck()
    {
        if (_isPushed)
        {
            if (_timeRemaining > 0)
            {
                _timeRemaining -= Time.deltaTime;
            }
            else
            {
                _timeRemaining = 0.5f;
                _isPushed = false;
            }
        }

        if (_shooting)
        {
            if (_timeBullet > 0)
            {
                _timeBullet -= Time.deltaTime;
            }
            else
            {
                _timeBullet = 0.5f;
                _shooting = false;
            }
        }
    }

    private void Move()
	{
        float h = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(h * speed, rb.velocity.y);

        if (Input.GetAxis("Vertical") > 0 && IsOnFloor())
        {
            Jump();
            _onGround = false;
            incGround = 0;
        }

    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private bool IsOnFloor()
    {
        return (_isGrounded && _onGround);
    }


    private void UpdateAnimation()
    {
        animator.SetFloat("SpeedX", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("SpeedY", rb.velocity.y);
        animator.SetBool("OnFloor", IsOnFloor());
        animator.SetBool("Push", _isPushed);
        animator.SetBool("Dead", _dead);

        if (Input.GetAxis("Horizontal") != 0 && !_isPushed)
            transform.localScale = new Vector2(Mathf.Sign(Input.GetAxis("Horizontal")) * _startScale.x, _startScale.y);
    }   

    public void Pushed(float direction)
    {
        if (!_isPushed)
        {
            rb.AddForce(new Vector2(pushForce * direction, 0), ForceMode2D.Impulse);
            _isPushed = true;
        }
    }

    private void Shoot()
    {
        if (!_shooting)
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
            _shooting = true;
        }
    }
    public void SetspawnPoint(Transform newspawnPoint)
    {
        spawnPoint = newspawnPoint;
    }

    public void FeedPlayer()
    {
        hungBar.IncreaseHungerBarBasic();
    }
}
