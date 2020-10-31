using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpHeight;
    private bool isOnGround;
    [SerializeField] private Vector3 spawnPoint;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private LayerMask killBox;

    private Rigidbody2D rigidbody2D;
    private bool canJump;

    public bool CanJump
    {
        get
        {
            return canJump;
        }
        set
        {
            canJump = value;
        }
    }

    public bool dead { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        isOnGround = true;
        rigidbody2D = GetComponent<Rigidbody2D>();
        spawnPoint = new Vector3(transform.position.x, transform.position.y + 1);

    }

    // Update is called once per frame
    void Update()
    {
        isOnGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        canJump = isOnGround;
        Move();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rigidbody2D.velocity = new Vector2(-moveSpeed * 1.5f, rigidbody2D.velocity.y);
            }
            else
            {
                rigidbody2D.velocity = new Vector2(-moveSpeed, rigidbody2D.velocity.y);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rigidbody2D.velocity = new Vector2(moveSpeed * 1.5f, rigidbody2D.velocity.y);
            }
            rigidbody2D.velocity = new Vector2(moveSpeed, rigidbody2D.velocity.y);
        }
        if (Input.GetKey(KeyCode.W))
        {
            Jump();
        }
    }

    private void Jump()
    {
        if (isOnGround)
        {
            if (CanJump)
            {

                isOnGround = false;
                CanJump = false;
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpHeight);

            }
        }
    }

    public void Kill()
    {
        rigidbody2D.velocity = new Vector2(0, 0);
        transform.position = spawnPoint;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "killBox")
        {
            transform.position = spawnPoint;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("pickup"))
        {
            GameManager.Instance.Score += collision.gameObject.GetComponent<Pickup>().score;
            Destroy(collision.gameObject);
        }
    }
}
