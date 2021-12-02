using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour
{
    public const float firstJump = 13f;
    public const float secondJump = 17f;
    public const float jumpSpeed = 10f;

    [SerializeField]
    bool isJump = false;
    public int jumpCount = 0;
    public int maxJumpCount = 2;

    public void JumpButton()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("점프 활성화");
            isJump = true;
        }
        if(isJump && jumpCount < maxJumpCount)
        {
            if (jumpCount == 0)
            {
                gameObject.transform.position = Vector2.Lerp(transform.position,new Vector2(gameObject.transform.position.x,firstJump),Time.deltaTime);
                jumpCount++;
            }
            else if (jumpCount == 1)
            {
                gameObject.transform.position = Vector2.Lerp(transform.position, new Vector2(gameObject.transform.position.x, secondJump), Time.deltaTime);
                jumpCount++;
                isJump = false;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("착지");
            jumpCount = 0;
            isJump = false;
        }
    }
    private void FixedUpdate()
    {
        JumpButton();
    }
}
