using UnityEngine;

public class Sun : MonoBehaviour
{
    private float period = 5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Time.deltaTime / period, 0);
    }
}
