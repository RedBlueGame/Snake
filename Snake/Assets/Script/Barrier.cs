using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D rb = collision.attachedRigidbody;
        if (rb != null)
        {
            SnakeHead snakeHead = rb.GetComponent<SnakeHead>();
            if (snakeHead != null)
            {
                Destroy(snakeHead.gameObject);
            }
        }
    }
}
