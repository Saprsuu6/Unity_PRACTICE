using UnityEngine;

public class Bird : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;
    private float force = 3;
    private Vector2 forceDirection;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        forceDirection = Vector2.up * force;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rigidbody2D.velocity = Vector2.up * force;
        }
    }
}
