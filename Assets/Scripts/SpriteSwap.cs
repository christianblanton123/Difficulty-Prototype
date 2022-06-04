using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSwap : MonoBehaviour
{

    //public SpriteArray spriteArray;
    
    public Sprite currentSprite;
    public Sprite oldSprite;
    public Sprite newSprite;
    // Start is called before the first frame update


    void Start()
    {
        oldSprite = GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}