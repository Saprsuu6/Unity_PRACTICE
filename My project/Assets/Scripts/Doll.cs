using UnityEngine;

public class Doll : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            rigidbody2D.AddForce(
                Vector2.up * 45
                );
            rigidbody2D.AddTorque(100);
            Debug.Log("Toeque");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            rigidbody2D.AddForce(
                Vector2.up * 45
                );
            rigidbody2D.AddTorque(-100);
            Debug.Log("Toeque");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            rigidbody2D.angularVelocity = 0;
        }
    }
}
