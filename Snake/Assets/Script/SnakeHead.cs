using System.Collections;
using System.Collections.Generic;
using UnityEditor.MPE;
using UnityEngine;

public class SnakeHead : MonoBehaviour
{
    public int Speed;
    public int Offset;
    public float Timer;
    public Transform TailPF;
    public List<Vector3> Route;
    public List<Transform> Tails;

    public void Start()
    {
        Tails.Add(transform);
        Route.Add(transform.position);
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void InstantiateTail()
    {
        Transform tail =  Instantiate(TailPF, transform.position, transform.rotation);
        Tails.Add(tail);
        for (int i = 0; i < Offset; i++)
        {
            Route.Add(transform.position);
        }

        if (TailPF != null)
        {
            Timer -= Time.deltaTime;
           /* if (Timer < -3)
            {
                Timer = 0;
            } */
        }
    }

    private void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * Speed);
        for (int i = Route.Count - 1; i > 0; i--)
        {
            Route[i] = Route[i - 1];
        }

        Route[0] = transform.position;

        for (int i = 0;i < Tails.Count; i++)
        {
           Tails[i].position = Route[i * Offset];           
        }


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