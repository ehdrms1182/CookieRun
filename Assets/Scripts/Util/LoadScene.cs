using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void InGameScene()
    {
        //SceneManager.LoadScene("InGame");
        SceneManager.LoadScene("SampleScene");
    }
    public void LobbyScene()
    {
        SceneManager.LoadScene("Lobby");
    }    
}
