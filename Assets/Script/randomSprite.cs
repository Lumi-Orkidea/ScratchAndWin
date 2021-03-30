using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomSprite : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray; // array of all the symbol sprites
    
    /*
     * Randomizes one of the sprites to be used.
     */
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        ChooseSprite();
        
        
    }

    /*
     * Randoms the icon and calls for the count.
     * Count returns true if the sprite is valid, if it isn't rerandom a sprite
     */ 
    void ChooseSprite()
    {
        int sprite = Random.Range(0, spriteArray.Length);
        if (transform.parent.gameObject.GetComponent<WinCounter>().Count(sprite)) spriteRenderer.sprite = spriteArray[sprite];
        else ChooseSprite();
    }
}
