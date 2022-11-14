using UnityEngine;

public class BirdScript : MonoBehaviour
{
    [SerializeField]
    private float forceFactor = 10;

    [SerializeField]
    private Sprite spriteBirdUp;
    [SerializeField]
    private Sprite spriteBirdDown;
    private SpriteRenderer spriteRenderer;

    private Rigidbody2D rb2D;
    private Vector2 forceDirection;

    private float holdTime;
    private const float holdTimeLimit = 1;

    // Start is called before the first frame update
    void Start()
    {


        rb2D = GetComponent<Rigidbody2D>();
        forceDirection = Vector2.up * forceFactor;
        holdTime = 0;

        spriteRenderer = GetComponent<SpriteRenderer>();
        //spriteRenderer.sprite = spriteBirdDown;
    }

    // Update is called once per frame
    void Update()
    {
        #region Hybrid scale
        //if (Input.GetKeyDown(KeyCode.Space)) holdTime = holdTimeLimit;
        //if (Input.GetKey(KeyCode.Space)) holdTime -= Time.deltaTime;
        //if (Input.GetKeyUp(KeyCode.Space)) holdTime = 0;
        //if (holdTime > 0) rb2D.AddForce(forceDirection * Time.deltaTime * 1000);
        #endregion

        #region Single scale
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2D.AddForce(forceDirection * 80);
        }

        #endregion
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe"))
        {
            Debug.Log("Booom");
        }
    }
}
