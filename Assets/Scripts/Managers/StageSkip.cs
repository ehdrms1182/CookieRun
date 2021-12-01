using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSkip : MonoBehaviour
{
    public enum NextStageType
    {
        InitStage,
        SomeStage
    }
    public bool isStart = false;
    public NextStageType nextStageType;
    public Transform Destination; //스테이지가 끝나는곳

    [SerializeField]
    GameObject startCheck;
    void Start()
    {
        isStart = true;
        
        if (isStart)
        {
            startCheck.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            if(nextStageType == NextStageType.InitStage)
            {
                other.transform.position = Vector3.zero;//right
            }
            else if(nextStageType == NextStageType.SomeStage)
            {
                Debug.Log("이동");
                other.transform.position = Destination.position;
            }
            else
            {
                return;
            }
        }
    }
}
