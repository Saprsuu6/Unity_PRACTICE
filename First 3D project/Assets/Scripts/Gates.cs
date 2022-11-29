using UnityEngine;

public class Gates : MonoBehaviour
{
    private const float timeout = 5;  // больше чем у чекпоинта
    private float timeleft;
    private bool GateDirectory = true;

    void Start()
    {
        timeleft = timeout;
    }

    void Update()
    {
        if (transform.position.y >= -2.40f && GateDirectory)
        {
            transform.position = new Vector3(
            transform.position.x,
            transform.localScale.y * (-1f / 2 + timeleft / timeout),
            transform.position.z);
        }
        else
        {
            GateDirectory = false;
        }

        if (transform.position.y <= 1 && !GateDirectory)
        {
            transform.position = new Vector3(
            transform.position.x,
            transform.localScale.y * (-1f / 2 + timeleft / timeout),
            transform.position.z);
        }
        else
        {
            GateDirectory = true;
        }

        timeleft -= Time.deltaTime;
    }

    public void Open()
    {
        timeleft = 0;

        transform.position = new Vector3(
            transform.position.x,
            -2.40f,
            transform.position.z);
    }
}
