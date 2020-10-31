using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + (moveSpeed * Time.deltaTime), transform.position.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("I HIT SOMETHING");
        if (collision.gameObject.name.Contains("ChangeDirection"))
        {
            Debug.Log("I AM CHANGING DIRECTION");
            moveSpeed *= -1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("I TRIGGERED SOMETHING");
        if (collision.gameObject.name.Contains("ChangeDirection"))
        {
            Debug.Log("I AM CHANGING DIRECTION");
            moveSpeed *= -1;
        }
    }
}
