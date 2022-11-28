using UnityEngine;

public class AfterCollision : MonoBehaviour
{
    [SerializeField]
    private GameObject bird;
    [SerializeField]
    private GameObject menuCanvas;
    [SerializeField]
    private GameObject gameStat;

    private MenuCanvas menuCanvasScript;
    private GameStat gameStatScript;
    private GameObject oldBird;

    private GameObject[] tubesForRemove;

    // Start is called before the first frame update
    void Start()
    {
        menuCanvasScript = menuCanvas.GetComponent<MenuCanvas>();
        gameStatScript = gameStat.GetComponent<GameStat>();
        oldBird = GameObject.FindGameObjectWithTag("Bird");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe"))
        {
            tubesForRemove = GameObject.FindGameObjectsWithTag("Tube");
            foreach (var item in tubesForRemove)
            {
                Destroy(item);
            }

            Prepare();
        }
        if (collision.gameObject.CompareTag("Border"))
        {
            gameStatScript.GameEnergy -= 0.1f;
        }
    }

    public void Prepare()
    {
        tubesForRemove = GameObject.FindGameObjectsWithTag("Tube");
        foreach (var item in tubesForRemove)
        {
            Destroy(item);
        }

        Prepare();
    }
}
