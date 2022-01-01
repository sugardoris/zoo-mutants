using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAngryPigController : MonoBehaviour
{
    public float speed = 3f;
    public float floatStrength = 1f;
    public float amplitude = 4f;

    float originalX;

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        this.originalX = this.transform.position.x;

        rb.velocity = transform.right * speed;
    }

    void FixedUpdate()
    {
        float targetX = originalX + ((float)Mathf.Sin(Time.fixedTime * floatStrength) * amplitude);
        Vector3 targetPosition = new Vector3(targetX, transform.position.y, transform.position.z);

        transform.position = targetPosition;
    }
}
