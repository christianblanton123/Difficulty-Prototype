using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    float GameTime=0;
    float speed;
    int flip=1;
    Rigidbody2D rb;
    // Start is called before the first frame update
    float velocity;
    void Start()
    {
        speed= Random.Range(0, .5f);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);
    }

    // Update is called once per frame
    void Update()
    { 
        speed += Time.deltaTime/10.0f;
        rb.velocity = new Vector2(flip*speed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        flip *= -1;
        
    }
}
