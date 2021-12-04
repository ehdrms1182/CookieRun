using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    CharacterStats characterStats;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Potion"))
        {
            characterStats.characterHp += 5f;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Obstacle"))
        {
            characterStats.characterHp -= 10f;
            LifeRenew();
        }
    }

    void LifeRenew()
    {
        characterStats.HPbar.size = characterStats.characterHp / 100f;
    }

}
