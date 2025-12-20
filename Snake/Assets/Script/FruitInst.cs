using UnityEngine;

public class FruitInst : MonoBehaviour
{
    public float InstCD;
    public Fruit fruit;

    private float _timer;

    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > InstCD)
        {
            Fruit inst = Instantiate(fruit, transform.position, transform.rotation);
            _timer = 0;
        }
    }
}
