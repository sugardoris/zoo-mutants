using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBunnyController : MonoBehaviour
{
    public float moveSpeed = 3f;

    private Rigidbody2D rb;
    private float directionX;
    private bool facingRight = false;
    private Vector3 localScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        localScale = transform.localScale;
        directionX = -1f;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(directionX * moveSpeed, rb.velocity.y);
    }

    void LateUpdate()
    {
        CheckFaceDirection();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Terrain" || collision.gameObject.name.StartsWith("FlipTrigger"))
        {
            directionX *= -1f;
        }
    }

    private void CheckFaceDirection()
    {
        if (directionX > 0) facingRight = true;
        else if (directionX < 0) facingRight = false;

        if ((facingRight && (localScale.x < 0)) || !facingRight && (localScale.x > 0)) localScale.x *= -1;

        transform.localScale = localScale;
    }
}
