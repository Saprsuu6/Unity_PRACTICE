using UnityEngine;

public class GameStat : MonoBehaviour
{
    private static TMPro.TextMeshProUGUI clock;
    private static TMPro.TextMeshProUGUI scoreStat;

    private static UnityEngine.UI.Image checkPoint;
    private static UnityEngine.UI.Image checkPointTwo;
    private static UnityEngine.UI.Image checkPointThree;

    private static float score = 0;
    private static float gameTime;
    private static float checkPointOneFill;
    private static float checkPointTwoFill;
    private static float checkPointThreeFill;

    public static float CheckPointOneTime { get; set; } = 0;
    public static float CheckPointTwoTime { get; set; } = 0;
    public static float CheckPointThreeTime { get; set; } = 0;

    public static float Score { get => score; }

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

    public static float CheckPointThreeFill
    {
        get => checkPointThreeFill;
        set
        {
            checkPointThreeFill = value;
            UpdateCheckPointThreeFill();
        }
    }

    void Start()
    {
        clock = GameObject.Find("Clock").GetComponent<TMPro.TextMeshProUGUI>();
        scoreStat = GameObject.Find("Score").GetComponent<TMPro.TextMeshProUGUI>();

        checkPoint = GameObject.Find("CheckPointImageStat").GetComponent<UnityEngine.UI.Image>();
        checkPointTwo = GameObject.Find("CheckPointImageStatTwo").GetComponent<UnityEngine.UI.Image>();
        checkPointThree = GameObject.Find("CheckPointImageStatThree").GetComponent<UnityEngine.UI.Image>();
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
        if (CheckPointTwoFill >= 0 && CheckPointTwoFill <= 1)
        {
            checkPointTwo.fillAmount = checkPointTwoFill;
            checkPointTwo.color = new Color(1 - CheckPointTwoFill, checkPointTwoFill, 0);
        }
        else
        {
            Debug.Log("CheckPointFill error:: " + checkPointTwoFill);
        }
    }

    private static void UpdateCheckPointThreeFill()
    {
        if (CheckPointThreeFill >= 0 && CheckPointThreeFill <= 1)
        {
            checkPointThree.fillAmount = checkPointThreeFill;
            checkPointThree.color = new Color(1 - CheckPointThreeFill, checkPointThreeFill, 0);
        }
        else
        {
            Debug.Log("CheckPointFill error:: " + checkPointThreeFill);
        }
    }

    public static void PassCheckPoint1(bool status)
    {
        CheckPointOneFill = 1;
        checkPoint.color = status ? Color.green : Color.red;
        CheckPointOneTime = status ? GameTime : -1f;
    }

    public static void PassCheckPoint2(bool status)
    {
        CheckPointTwoFill = 1;
        checkPointTwo.color = status ? Color.green : Color.red;
        CheckPointTwoTime = status ? ActivatorTwo.GameTime : -1f;
    }

    public static void PassCheckPoint3(bool status)
    {
        CheckPointThreeFill = 1;
        checkPointThree.color = status ? Color.green : Color.red;
        CheckPointThreeTime = status ? GameTime : -1f;
    }

    public static void AddScore()
    {
        score += 1;
        scoreStat.text = score.ToString();
    }
}
