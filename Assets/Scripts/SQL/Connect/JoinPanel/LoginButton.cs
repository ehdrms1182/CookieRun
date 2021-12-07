using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginButton : MonoBehaviour
{
    public GameObject loginButton;
    public void IsClicked()
    {
        loginButton.SetActive(false);
    }
}
