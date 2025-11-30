using UnityEngine;

public class Fruit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D rb = collision.attachedRigidbody;
        if (rb != null)
        {
            SnakeHead snakeHead = rb.GetComponent<SnakeHead>();
            if (snakeHead != null)
            {
                snakeHead.InstantiateTail();
                Destroy(gameObject);
            }
        }
    }
}