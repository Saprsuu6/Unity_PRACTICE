using UnityEngine;

public class Earth : MonoBehaviour
{
    [SerializeField]
    private GameObject earth;
    [SerializeField]
    private GameObject atmosphere;
    [SerializeField]
    private GameObject sun;

    private float dayPeriod = 5;
    private float yearPeriod = 10f;
    private float windPeriod = 2.5f;

    private Vector3 rotAxis;

    // Start is called before the first frame update
    void Start()
    {
        rotAxis = new Vector3(1, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        earth.transform.Rotate(0, Time.deltaTime / dayPeriod, 0);
        atmosphere.transform.Rotate(0, Time.deltaTime / windPeriod, 0);
        transform.RotateAround(sun.transform.position, sun.transform.up, Time.deltaTime * 10 / yearPeriod);
    }
}
