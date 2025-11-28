using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : MonoBehaviour
{
    public int Speed;

    public SnakeTail SnakeTail;
    public List<Vector3> Route;

    private void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * Speed);

        if (Input.GetKeyDown(KeyCode.W))
        {
          transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 180f);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, -90f);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }
    }

    public void Destroying()
    {
        Destroy(gameObject);
    }

    public void TailInstantiating()
    {
        //print("+1 to tail");
        Instantiate(SnakeTail);
    }

}
