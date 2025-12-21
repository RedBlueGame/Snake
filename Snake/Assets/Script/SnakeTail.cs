using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D rb = collision.attachedRigidbody;
        if (rb != null)
        {
            SnakeHead snakeHead = rb.GetComponent<SnakeHead>();
            if (snakeHead != null)
            {
                snakeHead.Die();
            }
        }
    }
}