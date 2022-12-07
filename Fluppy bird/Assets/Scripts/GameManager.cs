using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public GameObject gameOverCanvas;

    private GameObject resumeGameButton;
    private GameObject startGameButton;
    private GameObject gameOverText;

    void Start()
    {
        resumeGameButton = GameObject.Find("ResumeGame");
        startGameButton = GameObject.Find("StartGame");
        gameOverText = GameObject.Find("GameOver");

        gameOverCanvas.SetActive(false);
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        resumeGameButton.SetActive(false);
        Time.timeScale = 0;
    }

    public void Pause()
    {
        gameOverCanvas.SetActive(true);
        startGameButton.SetActive(false);
        gameOverText.SetActive(false);
        Time.timeScale = 0;
    }

    public void Replay()
    {
        SceneManager.LoadScene(0);
    }

    public void Resume()
    {
        startGameButton.SetActive(true);
        gameOverText.SetActive(true);
        gameOverCanvas.SetActive(false);
        Time.timeScale = 1;
    }
}
