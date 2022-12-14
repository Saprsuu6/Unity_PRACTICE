using System;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    public static bool isSoundsEnabled { get; private set; }
    public static float soundsVolume { get; private set; }

    private static GameObject MenuContent;
    private static UnityEngine.UI.Text _menuMessage;
    private static UnityEngine.UI.Text buttonCaption;
    private static UnityEngine.UI.Text result;

    private AudioSource bgMusic;
    private bool bgMusicEnamblet;
    private float bgMusicaValue;

    private const string settingsFilename = "setings.txt";

    #region life sycle
    private void OnDestroy()
    {
        SaveSettings();
    }

    void Start()
    {
        MenuContent = GameObject.Find("MenuContent");
        _menuMessage = GameObject.Find("MenuMessage").GetComponent<UnityEngine.UI.Text>();
        buttonCaption = GameObject.Find("ButtonCaption").GetComponent<UnityEngine.UI.Text>();
        result = GameObject.Find("Result").GetComponent<UnityEngine.UI.Text>();

        bgMusic = GetComponent<AudioSource>();

        var musicToggle = GameObject.Find("MusicToggle").GetComponent<UnityEngine.UI.Toggle>();
        var musicSlider = GameObject.Find("MusicSlider").GetComponent<UnityEngine.UI.Slider>();

        var soundsToggle = GameObject.Find("SoundsToggle").GetComponent<UnityEngine.UI.Toggle>();
        var soundsSlider = GameObject.Find("SoundsSlider").GetComponent<UnityEngine.UI.Slider>();

        if (LoadSettings())
        {
            musicToggle.isOn = bgMusicEnamblet;
            musicSlider.value = bgMusicaValue;

            soundsToggle.isOn = isSoundsEnabled;
            soundsSlider.value = soundsVolume;
        }
        else
        {
            bgMusicEnamblet = musicToggle.isOn;
            bgMusicaValue = musicSlider.value;

            isSoundsEnabled = soundsToggle.isOn;
            soundsVolume = soundsSlider.value;
        }

        UpdateBgMusic();

        Time.timeScale = MenuContent.activeInHierarchy ? 0.0f : 1.0f;
    }

    void LateUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Toggle();
        }
    }
    #endregion

    #region event handlers
    public void MenuButtonClick()
    {
        Hide();
    }

    public void MusicToggleChanged(bool isChecked)
    {
        bgMusicEnamblet = isChecked;
        UpdateBgMusic();
    }

    public void MusicVolumeChanged(float value)
    {
        bgMusicaValue = value;
        UpdateBgMusic();
    }

    public void SoundsToggleChanged(bool isChecked)
    {
        isSoundsEnabled = isChecked;
    }

    public void SoundsVolumeChanged(float value)
    {
        soundsVolume = value;
    }
    #endregion

    #region inner methods
    private void SaveSettings()
    {
        System.IO.File.WriteAllText(settingsFilename,
            $"{bgMusicEnamblet};{bgMusicaValue};{isSoundsEnabled};{soundsVolume}");
    }

    private bool LoadSettings()
    {
        if (System.IO.File.Exists(settingsFilename))
        {
            string[] data = System.IO.File.ReadAllText(settingsFilename).Split(";");

            try
            {
                bgMusicEnamblet = Convert.ToBoolean(data[0]);
                bgMusicaValue = Convert.ToSingle(data[1]);
                isSoundsEnabled = Convert.ToBoolean(data[2]);
                soundsVolume = Convert.ToSingle(data[3]);

                return true;
                //Debug.Log("bgMusicEnamblet: " + bgMusicEnamblet +
                //    "bgMusicaValue: " + bgMusicaValue +
                //    "isSoundsEnabled: " + isSoundsEnabled +
                //    "soundsVolume: " + soundsVolume);
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.Message);
                return false;
            }
        }

        return false;
    }

    private void UpdateBgMusic()
    {
        bgMusic.volume = bgMusicaValue;

        if (bgMusicEnamblet)
        {
            if (!bgMusic.isPlaying)
            {
                bgMusic.Play();
            }
        }
        else
        {
            bgMusic.Stop();
        }
    }

    public static void Show(
        string menuMessage = "Game paused",
        string button = "Continue")
    {
        Time.timeScale = 0.0f;
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
    #endregion
}
