using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    //private float _timer;

   /* private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer < -3)
        {
            _timer = 0;
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D rb = collision.attachedRigidbody;
        if (rb != null)
        {
            SnakeHead snakeHead = rb.GetComponent<SnakeHead>();
            if ((snakeHead != null) && (snakeHead.Timer <= -3))
            {
                snakeHead.Die();
            }
        }
    }
}
