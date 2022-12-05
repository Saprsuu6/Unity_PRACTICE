using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float speed = 2;

    void Start()
    {

    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
