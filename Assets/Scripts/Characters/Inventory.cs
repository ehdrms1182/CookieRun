using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    GameObject[] cookie;
    GameObject currentCookie;
    void SelectCookie()
    {
        currentCookie = cookie[0];
    }
}
