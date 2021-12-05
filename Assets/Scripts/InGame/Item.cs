using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField]
    CharacterMove characterMove;
    [SerializeField]
    ScoreManager scoreManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Potion"))
        {
            characterMove.characterHp += 5f;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Obstacle"))
        {
            characterMove.characterHp -= 10f;
            LifeRenew();
        }
        if (collision.CompareTag("Jelly"))
        {
            scoreManager.score += 100;
        }
        if (collision.CompareTag("BearJelly"))
        {
            scoreManager.score += 500;
        }
    }

    void LifeRenew()
    {
        characterMove.isSlide = false;
        characterMove.characterHp --;
        characterMove.hpBar.size = characterMove.characterHp / 100f;
    }
    private void FixedUpdate()
    {
        LifeRenew();
    }
    
}
