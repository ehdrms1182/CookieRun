using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public enum SceneName
    {
        Login,
        Lobby,
        InGame
    }
    SceneName sceneName;
    void OnClicked()
    {
        
        {
            SceneManager.LoadScene("sceneName");
        }
    }
    
}
