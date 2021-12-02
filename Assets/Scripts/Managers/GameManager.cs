using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private bool isInit;
       
    //TextMeshProUGUI counts;

    protected override void Awake()
    {
        base.Awake();
        OnApplicationSetting();
        if (instance != null)
        {
            DontDestroyOnLoad(this);
            isInit = true;
        }
    }
    
    public void OnApplicationSetting()
    {
        // ��������ȭ ����
        QualitySettings.vSyncCount = 0;
        // ���� �������� 60���� ����
        Application.targetFrameRate = 60;
        // �� ���� �� ��ð� ��� �ÿ��� ȭ���� ������ �ʰ�
        //Screen.sleepTimeout = SleepTimeout.NeverSleep;

    }
    IEnumerator GameStart()
    {

        yield return null; 
    }
    IEnumerator GameEnd()
    {
        yield return null;
    }
}
