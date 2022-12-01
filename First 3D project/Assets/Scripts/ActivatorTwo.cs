using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorTwo : MonoBehaviour
{
    public static float GameTime { get; set; }

    private void Update()
    {
        GameTime += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        ChechPointTwo.isActivated = true;
    }
}
