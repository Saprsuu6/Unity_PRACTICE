using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Clock : MonoBehaviour
{
    private TextMeshProUGUI clock;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        clock = GetComponent<TextMeshProUGUI>();
        time = 4;
    }

    // Update is called once per frame
    void Update()
    {
        //time -= Time.deltaTime;
    }

    //private void LateUpdate()
    //{
    //    int t = (int)time;

    //    clock.text = string.Format("{0:00}:{1:00}:{2:00}.{3:0}",
    //        t / 3600 % 24,
    //        t / 60 % 60,
    //        t % 60,
    //        (int)((time - t) * 10));
    //}
}
