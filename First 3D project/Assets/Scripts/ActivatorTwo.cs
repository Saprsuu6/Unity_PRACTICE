using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorTwo : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ChechPointTwo.isActivated = true;
    }
}
