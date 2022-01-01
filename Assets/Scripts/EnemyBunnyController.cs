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
    private Quaternion rotation;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        localScale = transform.localScale;
        rotation = transform.rotation;
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

        if (localScale.x == 1) rotation.y = 180;
        if (localScale.x == -1) rotation.y = 0;
        transform.rotation = rotation;
        if (transform.childCount > 0)
        {
            transform.GetChild(0).gameObject.transform.rotation = rotation;
        }
    }
}
