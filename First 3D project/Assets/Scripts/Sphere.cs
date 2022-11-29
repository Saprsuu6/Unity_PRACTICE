using UnityEngine;

public class Sphere : MonoBehaviour
{
    [SerializeField]
    private new GameObject camera;

    [SerializeField]
    private GameObject gate;

    private Rigidbody rb;
    private Vector3 forceDirection;

    private const float FORCE_MAGNITUDE = 2;

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

        //rb.AddForce(new Vector3(dx, 0, dy) * 2);
        
        forceDirection = camera.transform.forward;
        forceDirection.y = 0;
        forceDirection = forceDirection.normalized * dy * FORCE_MAGNITUDE;
        forceDirection += camera.transform.right * dx * FORCE_MAGNITUDE;

        rb.AddForce(forceDirection);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CheckPointOne")
        {
            gate.GetComponent<Gates>().Open();
        }

        Debug.Log(other.name);
    }
}
