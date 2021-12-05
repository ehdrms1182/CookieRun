using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMove : MonoBehaviour
{
    public const float jump = 5f;
    public bool isSlide = false;
    public int jumpCount = 0;
    public Scrollbar hpBar;
    public float characterHp = 100;
    
    private void Start() 
    {
        transform.parent.position = gameObject.transform.position;
    }    
    public void Jump()
    {

        if (
            //Input.GetMouseButton(0) && 
            jumpCount == 0&&!isSlide)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, jump, 0);
            jumpCount++;
            Debug.Log("FirstJump");
        }
        if (
            //Input.GetMouseButton(0) && 
            jumpCount == 1 && !isSlide)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, jump+2, 0);
            jumpCount++;
            Debug.Log("SecondJump");
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
            jumpCount = 0;
        }
    }
    
}