using UnityEngine;

public class Gates : MonoBehaviour
{
    private float timeout;
    private float timeleft;
    private bool GateDirectory = true;

    void Start()
    {
        timeout = Random.Range(5, 10);
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
        else if (GateDirectory)
        {
            GateDirectory = false;
            timeleft = timeout;
            Debug.Log("False");
        }

        if (transform.position.y <= 1 && !GateDirectory)
        {
            //transform.position = new Vector3(
            //transform.position.x,
            //transform.localScale.y * (-1f / 2 + timeleft / timeout),
            //transform.position.z);
        }
        else if (!GateDirectory)
        {
            GateDirectory = true;
            timeleft = timeout;
            Debug.Log("True");
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
