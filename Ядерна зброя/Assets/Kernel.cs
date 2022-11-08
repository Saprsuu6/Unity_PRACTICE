using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Kernel : MonoBehaviour
{
    private Rigidbody2D rigidbody2D = null;
    private bool canShoote = true;
    //private CircleCollider2D circleCollider2D = null;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canShoote)
        {
            canShoote = false;
            //rigidbody2D.gameObject.AddComponent<CircleCollider2D>();
            rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
            rigidbody2D.AddForce(Vector2.up * 400);
            rigidbody2D.AddForce(Vector2.left * 600);
        }
    }
}
