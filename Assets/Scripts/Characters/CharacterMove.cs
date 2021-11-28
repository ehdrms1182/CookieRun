using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public const float firstJump = 10f;
    public const float secondJump = 10f;

    [SerializeField]
    int jumpCount = 0;
    public void JumpButton()
    {
        if (jumpCount == 0)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, firstJump, 0);
            jumpCount++;
        }
        else if (jumpCount == 1)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, firstJump, 0);
            jumpCount++;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
        }
    }
}
