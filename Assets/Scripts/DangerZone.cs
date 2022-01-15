using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZone : MonoBehaviour
{
    public GameObject block;
    private Rigidbody2D blockBody;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collision");
            blockBody = block.GetComponent<Rigidbody2D>();
            blockBody.gravityScale = 3;
            Destroy(block, 1.5f);
        }
    }
}
