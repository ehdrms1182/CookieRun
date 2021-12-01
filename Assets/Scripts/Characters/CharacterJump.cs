using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour
{
    public const float firstJump = 13f;
    public const float secondJump = 17f;

    [SerializeField]
    bool isJump = false;
    public int jumpCount = 0;

    public void JumpButton()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (jumpCount == 0)
            {
                isJump = true;
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, firstJump, 0);
                jumpCount++;
            }
            else if (isJump == true && jumpCount == 1)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, secondJump, 0);
                isJump = false;

            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("ÂøÁö");
            jumpCount = 0;
            isJump = false;
        }
    }
    private void Update()
    {
        JumpButton();
    }
}
