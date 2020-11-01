using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private bool facingRight;

    enum Direction
    {
        left, right
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + (moveSpeed * Time.deltaTime), transform.position.y);
    }

    private void Flip(Direction dir)
    {
        if (((dir == Direction.right) && !facingRight) || ((dir == Direction.left) && facingRight))
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("ChangeDirection"))
        {
            moveSpeed *= -1;
            if (moveSpeed > 0)
            {
                Flip(Direction.right);
                facingRight = true;
            }
            else
            {
                Flip(Direction.left);
                facingRight = false;
            }
        }
    }
}
