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
            GameStat.PassCheckPoint1(false);
        }
        else
        {
            GameStat.CheckPointOneFill = image.fillAmount = timeleft / timeout;
            image.color = new Color(1 - image.fillAmount, image.fillAmount, 0);
            timeleft -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
        GameStat.PassCheckPoint1(true);
    }
}
