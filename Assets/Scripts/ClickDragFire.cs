using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickDragFire : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 InitmousePos;
    Vector3 finalMousePos;
    Rigidbody2D rb;
    LineRenderer arrow;
    Vector3 zOffset;
    TrailRenderer tr;
    public CinemachineImpulseSource impulseSource;

    [SerializeField] SpriteArray spriteArray;
    [SerializeField] Buttons buttons;

    [SerializeField] ParticleSystem basketParticles;
   

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        arrow = GetComponentInChildren<LineRenderer>();
        zOffset = new Vector3(0, 0, 10);
        tr = GetComponent<TrailRenderer>();
        FindObjectOfType<AudioManager>().Play("Music");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //bad
        GetComponentInChildren<SquashStretch>().PlayImpactFX();
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
            tr.Clear();
            rb.AddForce((new Vector2(InitmousePos.x, InitmousePos.y) - new Vector2(finalMousePos.x, finalMousePos.y)) * 4);
        }
        else if (Input.GetButton("Fire1"))
        {
            arrow.SetPosition(0, rb.transform.position);
            arrow.SetPosition(1, rb.transform.position + Camera.main.ScreenToWorldPoint(InitmousePos) - (Camera.main.ScreenToWorldPoint(Input.mousePosition)));

            // A simple 2 color gradient with a fixed alpha of 1.0f.
            float alpha = 1.0f;
            float dist = Vector2.Distance(new Vector2(arrow.GetPosition(0).x, arrow.GetPosition(0).y), new Vector2(arrow.GetPosition(1).x, arrow.GetPosition(1).y));
            float lerpFactor = Mathf.Clamp(dist / 6, 0, 1);
            Debug.Log("Lerp" + lerpFactor);
            Gradient gradient = new Gradient();
            Color lerpedColor = Color.Lerp(Color.green, Color.red, lerpFactor);
            gradient.SetKeys(
                new GradientColorKey[] { new GradientColorKey(Color.green, 0.0f), new GradientColorKey(lerpedColor, 1.0f) },
                new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
            );
            arrow.colorGradient = gradient;


        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //can only make on falling shots
        if (collision.gameObject.CompareTag("net")&&rb.velocity.y<=0)
        { 
            if (buttons.getHasScreenShake())
            {
                impulseSource.GenerateImpulseWithVelocity(rb.velocity);
            }

            if (buttons.getHasParticles())
            {
                basketParticles.Play();
            }

            if (buttons.getHasAudio())
            {
                FindObjectOfType<AudioManager>().Play("Made");
            }
            Debug.Log("made");
        }
        
    }

}
