using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    GameManager gameManager;
    [SerializeField]
    CharacterMove characterMove;
    
    float totalPlayTime = 0;
    float currentPlayTime = 0;
    public int score = 0;
    void FixedUpdate()
    {
        if (!gameManager.gameOver)
        {
            currentPlayTime += Time.fixedDeltaTime;
            totalPlayTime += currentPlayTime;
        }
    }
    private void Update() 
    {
        CheckScore();
    }
    int CheckScore()
    {
        if (0 >= characterMove.hpBar.size)
        {
            gameManager.gameOver = true;
            return score;
        }
        if (transform.position.y < -10)
        {
            gameManager.gameOver = true;
            return score;
        }
        return 1;
    }
}
