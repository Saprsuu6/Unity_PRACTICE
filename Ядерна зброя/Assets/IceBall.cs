using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBall : MonoBehaviour
{
    public float forceModeMagnitude = 2;

    private Rigidbody2D Rigidbody2D;
    private Vector2 forceDirection;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float dx = Input.GetAxis("Horizontal");
        float dy = Input.GetAxis("Vertical");

        forceDirection = new Vector2(dx, dy);
        Rigidbody2D.AddForce(forceModeMagnitude * forceDirection);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Collision " + collision.gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Triger " + collision.gameObject.name);
    }
}
