using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    
    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.name.Equals("Player"))
        {
            // PlatformManager.Instance.StartCoroutine("SpawnPlatform",
            //     new Vector2(transform.position.x, transform.position.y));
            Invoke("DropPlatform", 0.5f);
            Destroy(gameObject, 1.5f);
        }
    }

    void DropPlatform()
    {
        rigidBody.isKinematic = false;
    }
}
