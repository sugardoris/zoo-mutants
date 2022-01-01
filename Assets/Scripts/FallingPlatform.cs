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

    private void FixedUpdate()
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        if (!GeometryUtility.TestPlanesAABB(planes, rb.GetComponent<Collider2D>().bounds)) {
            Destroy(gameObject);
        }
    }

    void DropPlatform()
    {
        rb.isKinematic = false;
    }
}
