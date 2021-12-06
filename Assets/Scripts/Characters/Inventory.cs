using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    GameObject[] cookie;
    [SerializeField]
    GameObject[] panels;
    /*
    [SerializeField]
    GameObject panel_1;
    [SerializeField]
    GameObject panel_2;
    [SerializeField]
    GameObject panel_3;
    */
    GameObject currentCookie;
    void SelectCookie()
    {
        currentCookie = cookie[0];
    }
    public void CookieSpotLight()//비효율적인 임시 코드
    {
        //원래 알고리즘 -> 버튼을 눌렀을때, i번째 패널이면 index에서 i값을 제외한 나머지 패널 비활성화, 
        //버튼을 한번 더 누르거나 다른 버튼을 클릭했을경우 i번째 패널도 비활성화
        for(int i = 0; i<3; i++)
        {
            if (panels[i]==panels[0])//버튼을 눌렀을때, 1번 패널이면
            {
                Debug.Log("case 1");
                panels[0].SetActive(true);
                panels[1].SetActive(false);
                panels[2].SetActive(false);
                return;
            }
            if(panels[i] == panels[1])//"Button (1)")
            {
                Debug.Log("case 2");
                panels[1].SetActive(true);
                panels[0].SetActive(false);
                panels[2].SetActive(false);
                return;
            }
            if (panels[i] == panels[2])//"Button (2)")
            {
                Debug.Log("case 3");
                panels[2].SetActive(true);
                panels[0].SetActive(false);
                panels[1].SetActive(false);
                return;
            }
            else
                Debug.Log("Not Found");
        }
        
    }
}
