using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCookie : MonoBehaviour
{
    [SerializeField]
    GameObject[] panels;

    public bool isStart = false;
    public GameObject startButton;
    public CookieType cookieType;
    public SelectCookie[] cookies;
    public Inventory inventory;
    public void SettingCookies()
    {
        inventory.currentCookie = cookieType;
        //OnSelected();
        for (int i = 0; i < cookies.Length; i++)
        {
            if (cookies[i] != this)
            {
                panels[i].SetActive(false);
                Debug.Log($"{i} panel not active");
            }
            else
            {
                panels[i].SetActive(true);
                isStart = true;
                Debug.Log($"{i} panel active");
            }
        }
        if(isStart)
        {
            startButton.SetActive(true);
        }
    }
    /*
    void OnSelected()
    {
        panels[i].SetActive(true);
    }
    void OffSelected()
    {
        panels[i].SetActive(false);
    }
    */
}
