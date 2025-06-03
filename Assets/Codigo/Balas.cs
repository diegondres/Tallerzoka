using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balas : MonoBehaviour
{  
    public float speed = 1f;
    private float timer;
    public float liveTime = 15f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Time.deltaTime * transform.up;
        if (timer >= liveTime)
        {
            Destroy(gameObject);
        }
        timer += Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Exteriors"))
        {
            Destroy(gameObject);
        }
    }
}
