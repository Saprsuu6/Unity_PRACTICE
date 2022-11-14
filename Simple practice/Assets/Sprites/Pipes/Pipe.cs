using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;
    private Vector2 direction;
    private Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        direction = Vector2.left * speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FinishPipe"))
        {
            transform.Translate(new Vector3(30, transform.forward.y, transform.forward.z));
            Debug.Log("FinishPipe Booom");
        }
    }
}
