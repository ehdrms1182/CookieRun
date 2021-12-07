using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory inventory;
    public CookieType currentCookie;

    /*
    [SerializeField]
    GameObject panel_1;
    [SerializeField]
    GameObject panel_2;
    [SerializeField]
    GameObject panel_3;
    */    
    public void CookieSpotLight()//비효율적인 임시 코드
    {
        /// 원래 알고리즘 -> 버튼을 눌렀을때, i번째 패널이면 index에서 i값을 제외한 나머지 패널 비활성화, 
        /// 버튼을 한번 더 누르거나 다른 버튼을 클릭했을경우 i번째 패널도 비활성화
        /// 1. 버튼이 눌린다
        /// 2. 게임오브젝트 안에 할당된 배열개수만큼, FOR문을 돌린다.
        /// 3. i번째 패널이 n번째 패널이면, 
        Debug.Log("gogo");
    }
}
public enum CookieType
{
    Default,
    Brave,
    ButterCream,
    Santa
}