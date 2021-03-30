using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCounter : MonoBehaviour
{
    //counts for all the symbols
    private int horseShoe;
    private int luckyClover;
    private int luckySeven;
    private int heart;
    private bool win = false;
    private int maxSprites;
    
    /*
     * Add one to the count of symbols and check for validity
     */ 
    public bool Count(int newSprite)
    {
        if (win) maxSprites = 2; // no double victories when we set the maximum amount of valid icons to 2
        else maxSprites = 3;
        switch (newSprite)
        {
            case 0: 
                luckyClover += 1;
                return CheckForValidity(luckyClover);
            case 1:
                luckySeven += 1;
                return CheckForValidity(luckySeven);
            case 2:
                horseShoe += 1;
                return CheckForValidity(horseShoe);
            case 3:
                heart += 1;
                return CheckForValidity(heart);
            default:
                return false;
        }
    }

    /*
     * if the amount of sprites is less than maximum it's valid return true
     * Else there are too many sprites and it's not valid return false
     */ 
    private bool CheckForValidity(int sprite)
    {
        if(sprite  >= maxSprites && win == false)
        {
            win = true;
            return true;
        }
        if (sprite > maxSprites) return false;
        return true;
    }

}
