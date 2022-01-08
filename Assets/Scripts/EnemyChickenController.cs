using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChickenController : MonoBehaviour
{
    public float speed = 4f;
    public float floatStrength;
    public float amplitude;
    public int seconds = 3;

    private float originalX;
    private bool shouldMove = true;

    void Start()
    {
        this.originalX = this.transform.position.x;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        rb.velocity = transform.right * speed;
    }

    void Update()
    {
        if (this.shouldMove)
        {
            Move();
        }
    }

    void Move()
    {
        int direction = 1;
        if (Random.value < 0.5)
        {
            direction = -1;
        }
        transform.position = new Vector3(originalX + ((float)Mathf.Sin(Time.fixedTime * floatStrength) * amplitude * direction),
                           transform.position.y, transform.position.z);

        if (Random.value < 0.5)
        {
            StartCoroutine(WaitAtPoint());
        }
    }

    IEnumerator WaitAtPoint()
    {
        this.shouldMove = false;
        int counter = seconds;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }

        this.shouldMove = true;
    }
}
