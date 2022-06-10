using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterCollision : MonoBehaviour
{
    public float MaxLifeTime;
    public bool startTimer;
    Color originalColor;
    SpriteRenderer[] rend;
    public PlatformManager pm;
    // Start is called before the first frame update
    void Awake()
    {
        startTimer = false;
        rend = gameObject.GetComponentsInChildren<SpriteRenderer>();
        originalColor = rend[0].color;
        pm = GameObject.FindObjectOfType<PlatformManager>();
    }

    IEnumerator mDestroyRoutine;
    public void StartDestroyFX()
    {
        if (mDestroyRoutine != null)
            StopCoroutine(mDestroyRoutine);
        mDestroyRoutine = Destroy();
        StartCoroutine(mDestroyRoutine);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn(Transform t)
    {
        gameObject.SetActive(true);
        foreach (SpriteRenderer r in rend)
        {
            r.color = originalColor;
        }
        transform.position = t.position;
        startTimer = false;
    }

    IEnumerator Destroy()
    {
        
        float t = 0.0f;
        while (t < MaxLifeTime)
        {
            t += Time.deltaTime;
            Color color = rend[0].color;
            Debug.Log(t);
            color.a = Mathf.Lerp(originalColor.a, 0, t / MaxLifeTime);
            foreach (SpriteRenderer r in rend)
            {
                r.color = color;
            }
            yield return null;
        }
        if (t > MaxLifeTime)
        {
           gameObject.SetActive(false);
           //pm.occupiedMap[this.transform] = false;
           pm.SpawnNewPlatform(this.gameObject.transform.parent.gameObject);
           startTimer = false;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(!startTimer)
            StartDestroyFX();
            startTimer = true;
        }
    }
}
