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
    [SerializeField]
    SoundManager soundManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        soundManager.PlayEattingSound();
        if (collision.gameObject.CompareTag("Potion"))
        {
            characterMove.characterHp += 5f;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            characterMove.characterHp -= 10f;
            LifeRenew();
        }
        if (collision.gameObject.CompareTag("Jelly"))
        {
            scoreManager.score += 100;
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("BearJelly"))
        {
            scoreManager.score += 500;
            Destroy(this.gameObject);
        }
    }

    void LifeRenew()
    {
        characterMove.isSlide = false;
        characterMove.characterHp -= 0.05f;//20sec 0.02 50sec 
        characterMove.hpBar.size = characterMove.characterHp / 100f;
    }
    private void FixedUpdate()
    {
        LifeRenew();
    }
    
}
