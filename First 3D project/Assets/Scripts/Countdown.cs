using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    private UnityEngine.UI.Image image;
    private const float timeout = 5;
    private float timeleft;

    void Start()
    {
        timeleft = timeout;
        image = GetComponentInChildren<UnityEngine.UI.Image>();
    }

    void Update()
    {
        if (timeleft < 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            image.fillAmount = timeleft / timeout;
            timeleft -= Time.deltaTime;
        }
    }
}
