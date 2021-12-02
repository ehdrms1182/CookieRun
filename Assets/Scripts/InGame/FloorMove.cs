using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMove : MonoBehaviour
{
    float floorSpeed = 2f;
    void Update() 
    {
        transform.Translate(-floorSpeed * Time.deltaTime,0,0);
    }
    
}
