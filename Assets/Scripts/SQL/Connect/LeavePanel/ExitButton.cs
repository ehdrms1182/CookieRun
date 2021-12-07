using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public GameObject exitButton;
    public void IsClicked()
    {
        exitButton.SetActive(false);
    }
}
