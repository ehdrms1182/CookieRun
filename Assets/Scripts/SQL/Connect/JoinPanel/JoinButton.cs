using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinButton : MonoBehaviour
{
    public GameObject joinButton;
    public void IsClicked()
    {
        joinButton.SetActive(true);
    }
}
