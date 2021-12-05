using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private bool isInit;
    public bool gameOver {get; set;}
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
    private void Start() 
    {
        StartCoroutine(GameStart());
    }
    
    public void OnApplicationSetting()
    {
        Application.targetFrameRate = 60;
    }
    IEnumerator GameStart()
    {
        yield return gameOver = false;
    }
    IEnumerator GameEnd()
    {
        yield return gameOver = true;
    }
}
