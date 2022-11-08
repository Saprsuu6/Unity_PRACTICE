using UnityEngine;

public class Sun : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidbody2D.AddForce(
                Vector2.up * 3
                );
        }
    }

    // Update is called once per frame
    void UpdateDemo()
    {
        this.transform.Rotate(Vector3.forward, (float)0.2);
    }
}
