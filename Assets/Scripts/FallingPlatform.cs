using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.name.Equals("Player"))
        {
            Invoke("DropPlatform", 0.5f);
        }
    }

    void DropPlatform()
    {
        rb.isKinematic = false;
    }

    private void OnBecameInvisible()
    {
        if (rb.isKinematic == false)
        {
            Destroy(gameObject);
        }
    }
}
