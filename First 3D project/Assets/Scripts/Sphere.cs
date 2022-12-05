using UnityEngine;

public class Sphere : MonoBehaviour
{
    [SerializeField]
    private new GameObject camera;

    [SerializeField]
    private GameObject gate;
    [SerializeField]
    private GameObject gateTwo;

    private Rigidbody rb;
    private AudioSource soundHitWall;
    private AudioSource soundHitGate;
    private Vector3 forceDirection;

    private const float FORCE_MAGNITUDE = 2;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        AudioSource[] sounds = GetComponents<AudioSource>();
        soundHitWall = sounds[0];
        soundHitGate = sounds[1];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y == 0)
        {
            {
                rb.AddForce(Vector3.up * 400);
            }
        }

        float dx = Input.GetAxis("Horizontal");
        float dy = Input.GetAxis("Vertical");

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

        if (other.name == "CheckPointTwo")
        {
            gateTwo.GetComponent<Gates>().Open();
            GameStat.AddScore();
        }

        if (other.name == "CheckPointThree")
        {
            GameStat.AddScore();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (GameMenu.isSoundsEnabled)
        {
            AudioSource sound = collision.gameObject.tag switch
            {
                "Wall" => soundHitWall,
                "Gates" => soundHitGate,
                _ => null
            };

            if (sound is null) return;

            sound.volume = GameMenu.soundsVolume;
            sound.Play();
        }
    }
}
