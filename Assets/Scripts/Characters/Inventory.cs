using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    GameObject[] braveCookie;

    GameObject currentCookie;
    void SelectCookie()
    {
        currentCookie = braveCookie[0];
    }
}
