using UnityEngine;

public class GameMenu : MonoBehaviour
{
    private static GameObject MenuContent;
    private static UnityEngine.UI.Text _menuMessage;
    private static UnityEngine.UI.Text buttonCaption;
    private static UnityEngine.UI.Text result;

    void Start()
    {
        MenuContent = GameObject.Find("MenuContent");
        _menuMessage = GameObject.Find("MenuMessage").GetComponent<UnityEngine.UI.Text>();
        buttonCaption = GameObject.Find("ButtonCaption").GetComponent<UnityEngine.UI.Text>();
        result = GameObject.Find("Result").GetComponent<UnityEngine.UI.Text>();

        Time.timeScale = MenuContent.activeInHierarchy ? 0.1f : 1.0f;
    }

    void LateUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Toggle();
        }
    }

    public void MenuButtonClick()
    {
        Hide();
    }

    public static void Show(
        string menuMessage = "Game paused",
        string button = "Continue")
    {
        Time.timeScale = 0.1f;
        _menuMessage.text = menuMessage;
        buttonCaption.text = button;

        result.text = $"Time in game: {GameStat.GameTime:F1} s\n" +
            $"Checkpoint 1: {GetCheckPointStatus(GameStat.CheckPointOneTime)}\n" +
            $"Checkpoint 2: {GetCheckPointStatus(GameStat.CheckPointTwoTime)}\n" +
            $"Checkpoint 3: {GetCheckPointStatus(GameStat.CheckPointThreeTime)}\n" +
            $"Total score: {GameStat.Score}";

        MenuContent.SetActive(true);
    }

    private static string GetCheckPointStatus(float temp)
    {
        switch (temp)
        {
            case -1f:
                return "Failed";
            case 0:
                return "No contact";
            default:
                return GameStat.CheckPointOneTime.ToString("F1");
        }
    }

    public static void Hide()
    {
        MenuContent.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public static void Toggle()
    {
        if (MenuContent.activeInHierarchy)
        {
            Hide();
        }
        else Show();
    }
}
/* Обеспечить появление/исчезновение меню по ESC
 * Реализовать обработчик события кнопки
 */