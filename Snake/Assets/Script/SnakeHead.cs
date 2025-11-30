using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : MonoBehaviour
{
    public int Speed;
    public int Offset;
    public SnakeTail TailPF;
    public SnakeTail Tail;
    public List<Vector3> Route;

    public void Die()
    {
        Destroy(gameObject);
    }

    public void InstantiateTail()
    {
         Tail = Instantiate(TailPF, transform.position, transform.rotation);
    }

    private void Start()
    {
        for (int i = 0; i < Offset; i++)
        {
           Route.Add(transform.position);
        }
    }

    private void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * Speed);
        for (int i = Offset - 1; i > 0; i--)
        {
            Route[i] = Route[i - 1];
        }
        Route[0] = transform.position;
        Tail.transform.position = Route[Offset - 1];

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
}