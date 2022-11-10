using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class IceBall : MonoBehaviour
{
    [SerializeField]
    public float forceModeMagnitude = 2;

    [SerializeField]
    private TMPro.TextMeshProUGUI score;

    private Rigidbody2D Rigidbody2D;
    private Vector2 forceDirection;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float dx = Input.GetAxis("Horizontal");
        float dy = Input.GetAxis("Vertical");

        forceDirection = new Vector2(dx, dy);
        Rigidbody2D.AddForce((forceModeMagnitude * forceDirection) / 2);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Collision " + collision.gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Border"))
        {
            score.text = (int.Parse(score.text) - 1).ToString();
        }
    }
}
