using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField]
    CharacterMove characterMove;
    [SerializeField]
    CookieInfo cookieInfo;
    [SerializeField]
    ScoreManager scoreManager;
    [SerializeField]
    //SoundManager soundManager;
    /*
    private void Start() 
    {
        characterMove = GetComponent<CharacterMove>();
        cookieInfo = GetComponent<CookieInfo>();
        scoreManager = GetComponent<ScoreManager>();
        soundManager = GetComponent<SoundManager>();        
    }
    */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        //soundManager.PlayEattingSound();
        if (collision.gameObject.CompareTag("Potion"))
        {
            cookieInfo.characterHp += 5f;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            cookieInfo.characterHp -= 10f;
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
        cookieInfo.isSlide = false;
        cookieInfo.characterHp -= 0.05f;//20sec 0.02 50sec 
        characterMove.hpBar.size = cookieInfo.characterHp / 100f;    
    }
    private void FixedUpdate()
    {
        LifeRenew();
    }
    
}
