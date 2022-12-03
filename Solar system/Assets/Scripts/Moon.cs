using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    [SerializeField]
    private GameObject earth;
    [SerializeField]
    private GameObject moon;
    [SerializeField]
    private GameObject sun;

    private float nightPeriod = 2;
    private float yearPeriod = 10f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moon.transform.Rotate(0, Time.deltaTime / nightPeriod, 0);
        transform.RotateAround(sun.transform.position, sun.transform.up, Time.deltaTime * 10 / yearPeriod);
        transform.RotateAround(earth.transform.position, earth.transform.up, Time.deltaTime * 10 / nightPeriod);
    }
}
