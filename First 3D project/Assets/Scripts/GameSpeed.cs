using UnityEngine;

public class GameSpeed : MonoBehaviour
{
    public UnityEngine.UI.Slider gameSpeed;

    void Start()
    {
        gameSpeed.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    void Update()
    {
        gameSpeed = GameObject.Find("Slider").GetComponent<UnityEngine.UI.Slider>();
    }

    public void ValueChangeCheck()
    {
        Debug.Log(gameSpeed.value);
    }
}
