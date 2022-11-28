using UnityEngine;

public class Gates : MonoBehaviour
{
    private const float timeout = 5;  // больше чем у чекпоинта
    private float timeleft;
    //private bool GateDirectory = true;
    //private Vector3 MIN;

    void Start()
    {
        MIN = new Vector3(
            transform.position.x,
            -2.30f,
            transform.position.z);

        timeleft = timeout;
    }

    void Update()
    {
        if (transform.position.y >= -2.30f)
        {
            transform.position = new Vector3(
            transform.position.x,
            transform.localScale.y * (-1f / 2 + timeleft / timeout),
            transform.position.z);
        }

        //if (transform.position.y == -2.30)
        //{
        //    Debug.Log("Boom");
        //}

        timeleft -= Time.deltaTime;
    }

    public void Open()
    {
        timeleft = 0;

        transform.position = new Vector3(
            transform.position.x,
            -2.30f,
            transform.position.z);
    }
}
