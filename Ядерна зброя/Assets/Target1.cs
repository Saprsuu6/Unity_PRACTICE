using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            Debug.Log("+2 pt");
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("+1 pt");
        }

        float rX = Random.Range(-8f, 8f);
        float rY = Random.Range(-4f, 4f);
        transform.position = new Vector3(rX, rY, 0);

        Debug.Log("Triger1 " + collision.gameObject.name);
    }
}
