using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PatternManager : MonoBehaviour
{
    private List<GameObject> patternList = new List<GameObject>();//리스트 선언
    public GameObject startPattern;
    public GameObject[] patterns; //패턴을 받아올 배열 선언
    public GameManager gameManager;
    public int randomPattern = 0;
    public float speed = 0f;
    public float delayTime = 0.1f;
    public float posX = 0.0f;
    public GameObject s_pattern;
    private void Start()
    {
        s_pattern = Instantiate(startPattern, new Vector2(0.0f, 0.0f), Quaternion.identity);
        
        s_pattern.GetComponent<Pattern>().Init(speed);
        
        for(int i = 0; i<patterns.Length; i++)//패턴의 길이만큼
        {
            Debug.Log("Pattern");
            patternList.Add(patterns[i]);
        }
        StartCoroutine(CreatePattern());
    }
    IEnumerator CreatePattern()
    {
        while (!gameManager.gameOver)
        {
            randomPattern = Random.Range(0,patterns.Length);

            GameObject t_pattern = Instantiate(patternList[randomPattern], new Vector2(posX, 0.0f), Quaternion.identity);
            t_pattern.GetComponent<Pattern>().Init(speed);
            Debug.Log($"{randomPattern} Pattern");
            yield return new WaitForSeconds(delayTime);
        }
    }
}
