using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteArray : MonoBehaviour
{


    [SerializeField] private SpriteSwap[] spriteArray;
    public SpriteRenderer[] spriteRenderers;
    [SerializeField] private GameObject[] spritesToAppear;
    
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void ChangeSprite()
    {
        for (int i = 0; i < spritesToAppear.Length; i++) {
            if (spritesToAppear[i].activeInHierarchy == false) {
                spritesToAppear[i].SetActive(true);
                Debug.Log("set active is true");
            } else {
                spritesToAppear[i].SetActive(false);
            }
        }

        for (int i = 0; i < spriteArray.Length; i++) {
           
            if (spriteArray[i].currentSprite == spriteArray[i].newSprite) {
                spriteArray[i].currentSprite = spriteArray[i].oldSprite; 
                spriteRenderers[i].sprite = spriteArray[i].currentSprite;
            } else {
                spriteArray[i].currentSprite = spriteArray[i].newSprite; 
                spriteRenderers[i].sprite = spriteArray[i].currentSprite;
            }

            
        }

        
        
    }
}

