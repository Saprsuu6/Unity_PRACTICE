using UnityEngine;

public class Sphere : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Debug.Log("X:: " + rb.velocity.x);
        //Debug.Log("Y:: " + rb.velocity.y);
        //Debug.Log("Z:: " + rb.velocity.z);

        if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y == 0)
        {
            {
                rb.AddForce(Vector3.up * 400);
            }
        }

        float dx = Input.GetAxis("Horizontal");
        float dy = Input.GetAxis("Vertical");
        rb.AddForce(new Vector3(dx, 0, dy) * 2);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        Destroy(other.gameObject);
    }
}
