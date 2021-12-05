using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    GameManager gameManager;
    [SerializeField]
    CharacterMove characterMove;
    [SerializeField]
    GameObject endPanel;
    
    public float playTime = 0;
    public int score = 0;
    void FixedUpdate()
    {
        if (!gameManager.gameOver)
        {
            playTime += Time.fixedDeltaTime;
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
            Debug.Log("Over");
            gameManager.gameOver = true;
            endPanel.SetActive(true);
            return score;

        }
        if (characterMove.transform.parent.position.y < -10)
        {
            gameManager.gameOver = true;
            endPanel.SetActive(true);
            return score;
        }
        return 1;
    }
}
