using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public bool isLevel2;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    
    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.name.Equals("Player"))
        {
            Invoke("DropPlatform", 0.1f);
            if (isLevel2)
                Destroy(gameObject, 2.5f);
            else
                Destroy(gameObject, 1f);
        }
    }

    void DropPlatform()
    {
        rigidBody.isKinematic = false;
    }
}
