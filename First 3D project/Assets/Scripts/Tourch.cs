using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tourch : MonoBehaviour
{
    private new Light light;

    void Start()
    {
        light = GetComponent<Light>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            light.intensity = 5;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            light.intensity = 2;
        }
    }
}
