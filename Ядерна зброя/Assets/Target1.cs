using UnityEngine;

public class Target1 : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI score;
    [SerializeField]
    private TMPro.TextMeshProUGUI clock;
    [SerializeField]
    private CircleCollider2D circle;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        time = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            ChangePosition();
        }
    }

    private void LateUpdate()
    {
        int t = (int)time;

        clock.text = string.Format("{0:00}:{1:00}:{2:00}.{3:0}",
            t / 3600 % 24,
            t / 60 % 60,
            t % 60,
            (int)((time - t) * 10));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            score.text = (int.Parse(score.text) + 2).ToString();
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            score.text = (int.Parse(score.text) + 1).ToString();
        }

        ChangePosition();

        Debug.Log("Triger1 " + collision.gameObject.name);
    }

    private void ChangePosition()
    {
        time = 5;


        float rX = Random.Range(-8f, 8f);
        float rY = Random.Range(-4f, 4f);

        var vector = new Vector3(rX, rY, 0);

        if (circle.OverlapPoint(vector))
        {
            ChangePosition();
        }
        else
        {
            transform.position = vector;
        }
    }
}
