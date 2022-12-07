using UnityEngine;

public class AddScore : MonoBehaviour
{
    private AudioClip scoreClip;

    private void Start()
    {
        scoreClip = GetComponent<AudioClip>();
        Debug.Log(scoreClip);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bird"))
        {
            Score.score++;
        }
    }
}
