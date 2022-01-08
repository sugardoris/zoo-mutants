using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBeeController : MonoBehaviour
{
    public float speed = 3f;
    public float floatStrength = 2f;
    public float amplitude = 2f;

    float originalY;

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        this.originalY = this.transform.position.y;

        rb.velocity = transform.up * speed;
    }

    void FixedUpdate()
    {
        float targetY = originalY + ((float)Mathf.Sin(Time.fixedTime * floatStrength) * amplitude);
        Vector3 targetPosition = new Vector3(transform.position.x, targetY, transform.position.z);

        transform.position = targetPosition;
    }
}
