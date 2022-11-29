using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChechPointTwo : MonoBehaviour
{
    public static bool isActivated;

    private UnityEngine.UI.Image image;
    private const float timeout = 5;
    private float timeleft;

    void Start()
    {
        isActivated = false;
        timeleft = timeout;
        image = GetComponentInChildren<UnityEngine.UI.Image>();
    }

    void Update()
    {
        if (isActivated)
        {
            if (timeleft < 0)
            {
                gameObject.SetActive(false);
                GameStat.PassCheckPoint2(false);
            }
            else
            {
                GameStat.CheckPointTwoFill = image.fillAmount = timeleft / timeout;
                image.color = new Color(1 - image.fillAmount, image.fillAmount, 0);
                timeleft -= Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        GameStat.PassCheckPoint2(true);
    }
}
