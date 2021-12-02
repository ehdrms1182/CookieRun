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
            isJump = true;
        }
        if(isJump)
        {
            if (jumpCount == 0)
            {
                gameObject.transform.position = Vector2.Lerp(transform.position,new Vector2(gameObject.transform.position.x,firstJump),Time.smoothDeltaTime);
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
            Debug.Log("착지");
            jumpCount = 0;
            isJump = false;
        }
    }
    private void Update()
    {
        JumpButton();
    }
}
