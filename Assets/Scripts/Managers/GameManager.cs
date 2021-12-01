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

        if (instance != null)
        {
            DontDestroyOnLoad(this);
            isInit = true;
        }
    }
    
    public void OnApplicationSetting()
    {
        // 수직동기화 끄기
        QualitySettings.vSyncCount = 0;
        // 렌더 프레임을 60으로 설정
        Application.targetFrameRate = 60;
        // 앱 실행 중 장시간 대기 시에도 화면이 꺼지지 않게
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
