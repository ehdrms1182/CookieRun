using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMove : MonoBehaviour
{
    public float jump = 5f;
    public bool isSlide = false;
    public int jumpCount = 0;

    public Scrollbar hpBar;
    CookieInfo cookieInfo;
    private void Start() 
    {
        transform.parent.position = gameObject.transform.position;
        cookieInfo = GetComponent<CookieInfo>();
    }    
    public void Jump()
    {
        if(!(cookieInfo.isSlide))//&& timer == 0)
        {
            if (
                //Input.GetMouseButton(0) && 
                cookieInfo.jumpCount == 1)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0,cookieInfo.jump + 2, 0);
                cookieInfo.jumpCount++;
                Debug.Log("SecondJump");
            }
            else if (
            //Input.GetMouseButton(0) && 
            cookieInfo.jumpCount == 0)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, cookieInfo.jump, 0);
                cookieInfo.jumpCount++;
                Debug.Log("FirstJump");
            }
            
        }
    }
    /*
    public void ExecuteSlide()
    {
        if(isSlide&&!isJump)
        {
            if (Input.GetMouseButton(1))
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, jump, 0);
                Debug.Log("Slide");
            }
            if (Input.GetMouseButtonUp(1))
            {
                isSlide = false;
            }
        }
    }
    */
    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Ground");
            cookieInfo.jumpCount = 0;
        }
    }
}