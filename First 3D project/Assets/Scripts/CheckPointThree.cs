using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointThree : MonoBehaviour
{
    private UnityEngine.UI.Image image;
    private const float timeout = 30;
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
            GameStat.PassCheckPoint3(false);
        }
        else
        {
            GameStat.CheckPointThreeFill = image.fillAmount = timeleft / timeout;
            image.color = new Color(1 - image.fillAmount, image.fillAmount, 0);
            timeleft -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        GameStat.PassCheckPoint3(true);
    }
}
