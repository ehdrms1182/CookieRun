using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveButton : MonoBehaviour
{
    public GameObject leaveButton;
    public void IsClicked()
    {
        leaveButton.SetActive(true);
    }
}
