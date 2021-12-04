using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public const float firstJump = 13f;
    public const float secondJump = 17f;
    public const float jumpSpeed = 10f;

    [SerializeField]
    private bool isJump = false;
    private bool isSlide = false;
    private int jumpCount = 0;

    public void ExecuteJump()
    {
        if(!isSlide&&isJump)
        {
            if (Input.GetMouseButtonDown(0) && jumpCount == 0)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, firstJump, 0);
                jumpCount++;
            }
            if (Input.GetMouseButtonDown(0) && jumpCount == 1)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, firstJump, 0);
                jumpCount++;
            }
            if (jumpCount == 2)
            {
                isJump = false;
            }
        }
        
    }
    public void ExecuteSlide()
    {
        if(isSlide&&!isJump)
        {
            if (Input.GetMouseButtonDown(1))
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, firstJump, 0);
            }
            if (Input.GetMouseButtonUp(1))
            {
                isSlide = false;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Ground");
            jumpCount = 0;
        }
        else
            isJump = true;
    }
    private void FixedUpdate()
    {
        ExecuteJump();
        ExecuteSlide();
        if (0 >= HealthBar.size)
        {
            cookieAni.SetBool("Die", true);
            GameManager.instance.gameOver = true;
        }

        if (transform.position.y < -10)
        {
            GameManager.instance.gameOver = true;
        }
    }
}
