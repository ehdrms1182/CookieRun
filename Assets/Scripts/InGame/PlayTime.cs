using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTime : MonoBehaviour
{
    GameManager gameManager;
    float totalPlayTime = 0;
    float currentPlayTime = 0;

    void FixedUpdate() 
    {
        if(!gameManager.gameOver)
        {
            currentPlayTime += Time.fixedDeltaTime;
            totalPlayTime += currentPlayTime;
        }    
        
    }
}
