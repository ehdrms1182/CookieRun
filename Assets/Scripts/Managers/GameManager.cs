using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private bool isInit;

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
        // ��������ȭ ����
        QualitySettings.vSyncCount = 0;
        // ���� �������� 60���� ����
        Application.targetFrameRate = 60;
        // �� ���� �� ��ð� ��� �ÿ��� ȭ���� ������ �ʰ�
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
}
