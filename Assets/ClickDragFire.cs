using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDragFire : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 InitmousePos;
    Vector3 finalMousePos;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            InitmousePos = Input.mousePosition;
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            finalMousePos = Input.mousePosition;
            //shoot
            rb.AddForce(new Vector2(InitmousePos.x,InitmousePos.y)-new Vector2(finalMousePos.x,finalMousePos.y));
        }
    }
}
