using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField]
    public GameManager gameManager;
    private new Rigidbody2D rigidbody2D;
    private float force = 3;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rigidbody2D.velocity = Vector2.up * force;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe") ||
            collision.gameObject.CompareTag("Border"))
        {
            gameManager.GameOver();
        }
    }
}
