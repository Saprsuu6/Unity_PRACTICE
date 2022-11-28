using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStat : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI clock;
    [SerializeField]
    private UnityEngine.UI.Image energy;  // EnergyIndicator - filled-type image
    [SerializeField]
    private TMPro.TextMeshProUGUI score;
    //[SerializeField]
    //private GameObject menuCanvas;
    [SerializeField]
    private GameObject bird;

    private AfterCollision afterCollisionScript;
    //private MenuCanvas menuCanvasScript;

    private const string bestDataFilename = "Assets/Files/bestdata.sav";
    private const string bestDataJsonname = "Assets/Files/bestdata.json";

    private float _gameTime;
    private float _gameEnergy;   // [0..1] value
    private int   _gameScore;
    private int   _bestScore;    // лучшее значение, храним в файле
    private float _bestTime;     // максимальное время, проведенное в игре

    public float GameTime { 
        get => _gameTime;
        set
        {
            _gameTime = value;
            UpdateUiTime();
        }
    }
    public float GameEnergy { 
        get => _gameEnergy;
        set
        {
            _gameEnergy = value;
            UpdateUiEnergy();
        }
    }
    public int GameScore
    {
        get => _gameScore;
        set
        {
            _gameScore = value;
            UpdateUiScore();
        }
    }

    void Start()
    {
        GameTime = 0;
        GameEnergy = energy.fillAmount;   // TODO: зависимость от сложности
        afterCollisionScript = bird.GetComponent<AfterCollision>();

        if (System.IO.File.Exists(bestDataJsonname))
        {
            BestData data = JsonUtility.FromJson<BestData>(
                System.IO.File.ReadAllText(bestDataJsonname)
            );
            _bestScore = data.Score;
            _bestTime = data.Time;
        }
        else
        {
            _bestScore = 0;
            _bestTime = 0;
        }
        Debug.Log($"Start: bestScore = {_bestScore}, bestTime = {_bestTime}");
    }
    void LateUpdate()
    {
        GameTime += Time.deltaTime;
    }
    private void OnDestroy()   // метод ЖЦ, запускается перед разрушением объекта
    {
        BestData data = new()
        {
            Score = (_gameScore >= _bestScore ? _gameScore : _bestScore),
            Time = (_gameTime >= _bestTime ? _gameTime : _bestTime)
        };
        System.IO.File.WriteAllText(bestDataJsonname, JsonUtility.ToJson(data, true));
    }

    private void UpdateUiTime()
    {
        int t = (int)_gameTime;
        clock.text = $"{t / 3600 % 24:00}:{t / 60 % 60:00}:{t % 60:00}.{(int)((_gameTime - t) * 10):0}";
        if (_gameTime > _bestTime)
        {
            clock.fontStyle = TMPro.FontStyles.Bold;
            _bestTime = _gameTime;   // новый рекорд
        }
    }
    private void UpdateUiEnergy()
    {
        if(_gameEnergy >=0 && _gameEnergy <= 1)
        {
            energy.fillAmount = _gameEnergy;
        }
        else
        {
            afterCollisionScript.Prepare();
        }
    }
    private void UpdateUiScore()
    {
        score.text = $"{_gameScore:0000}";
        if(_gameScore > _bestScore)
        {
            score.fontStyle = TMPro.FontStyles.Bold;
            _bestScore = _gameScore;
        }
    }

    class BestData    // для сериализации в JSON
    {
        public int Score;
        public float Time;
    }
}
