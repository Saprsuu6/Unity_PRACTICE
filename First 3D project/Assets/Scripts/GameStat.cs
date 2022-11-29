using UnityEngine;

public class GameStat : MonoBehaviour
{
    private static TMPro.TextMeshProUGUI clock;
    private static UnityEngine.UI.Image checkPoint;
    private static UnityEngine.UI.Image checkPointTwo;
    private static float gameTime;
    private static float checkPointOneFill;
    private static float checkPointTwoFill;

    public static float GameTime
    {
        get => gameTime;
        set
        {
            gameTime = value;
            UpdateTime();
        }
    }

    public static float CheckPointOneFill
    {
        get => checkPointOneFill;
        set
        {
            checkPointOneFill = value;
            UpdateCheckPointOneFill();
        }
    }

    public static float CheckPointTwoFill
    {
        get => checkPointTwoFill;
        set
        {
            checkPointTwoFill = value;
            UpdateCheckPointTwoFill();
        }
    }

    void Start()
    {
        clock = GameObject.Find("Clock").GetComponent<TMPro.TextMeshProUGUI>();
        checkPoint = GameObject.Find("CheckPointImageStat").GetComponent<UnityEngine.UI.Image>();
        checkPointTwo = GameObject.Find("CheckPointImageStatTwo").GetComponent<UnityEngine.UI.Image>();
    }

    void Update()
    {
        GameTime += Time.deltaTime;
    }

    private static void UpdateTime()
    {
        int t = (int)gameTime;
        clock.text = $"{t / 3600 % 24:00}:{t / 60 % 60:00}:{t % 60:00}.{(int)((gameTime - t) * 10):0}";
    }

    private static void UpdateCheckPointOneFill()
    {
        if (CheckPointOneFill >= 0 && CheckPointOneFill <= 1)
        {
            checkPoint.fillAmount = checkPointOneFill;
            checkPoint.color = new Color(1 - CheckPointOneFill, checkPointOneFill, 0);
        }
        else
        {
            Debug.Log("CheckPointFill error:: " + checkPointOneFill);
        }
    }

    private static void UpdateCheckPointTwoFill()
    {
        if (checkPointTwoFill >= 0 && checkPointTwoFill <= 1)
        {
            checkPointTwo.fillAmount = checkPointTwoFill;
            checkPointTwo.color = new Color(1 - CheckPointOneFill, checkPointOneFill, 0);
        }
        else
        {
            Debug.Log("CheckPointFill error:: " + checkPointTwoFill);
        }
    }

    public static void PassCheckPoint1(bool status)
    {
        CheckPointOneFill = 1;
        checkPoint.color = status ? Color.green : Color.red;
    }

    public static void PassCheckPoint2(bool status)
    {
        CheckPointTwoFill = 1;
        checkPointTwo.color = status ? Color.green : Color.red;
    }
}
