using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3f;
    public new Rigidbody2D rb;
    public bool random;
    float originalX;

    public float floatStrength;
    public float amplitude;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        this.originalX = this.transform.position.x;

        if (random)
        {
            rb.velocity = Random.value * transform.right * speed;
        }
        else
        {
            rb.velocity = transform.right * speed;
        }


    }

    void Update()
    {
        transform.position = new Vector3(originalX + ((float)Mathf.Sin(Time.fixedTime * floatStrength) * amplitude),
               transform.position.y, transform.position.z);
    }
}
