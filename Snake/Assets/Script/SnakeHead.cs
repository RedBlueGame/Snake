using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : MonoBehaviour
{
    public int Speed;
    public int Offset;
    public float Timer;
    public Transform TailPf;
    public List<Transform> Tails;
    public List<Vector3> Positions;
    public List<Quaternion> Rotations;

    public void Start()
    {
        Tails.Add(transform);
        Positions.Add(transform.position);
        Rotations.Add(transform.rotation);
    }

    public void Die()
    {
        foreach (Transform t in Tails)
        {
            Destroy(t.gameObject);
        }
    }

    public void InstantiateTail()
    {
        Transform tail = Instantiate(TailPf, Positions[^1], Rotations[^1]);
        if (Tails.Count == 1)
        {
            tail.GetComponentInChildren<Collider2D>().enabled = false;
        }
        Tails.Add(tail);
        for (int i = 0; i < Offset; i++)
        {
            Positions.Add(Positions[^1]);
            Rotations.Add(Rotations[^1]);
        }

        if (TailPf != null)
        {
            Timer -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.up * Time.deltaTime * Speed);
        for (int i = Positions.Count - 1; i > 0; i--)
        {
            Positions[i] = Positions[i - 1];
            Rotations[i] = Rotations[i - 1];
        }

        Positions[0] = transform.position;
        Rotations[0] = transform.rotation;

        for (int i = 0; i < Tails.Count; i++)
        {
            Tails[i].SetPositionAndRotation(Positions[i * Offset], Rotations[0]);
        }
    }

    private void Update()
    {
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