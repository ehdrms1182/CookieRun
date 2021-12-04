using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    GameManager gameManager;
    CharacterStats characterStats;
    private void Update() 
    {
        if (0 >= characterStats.HPbar.size)
        {
            gameManager.gameOver = true;
        }

        if (transform.position.y < -10)
        {
            gameManager.gameOver = true;
        }
    }
    
}
