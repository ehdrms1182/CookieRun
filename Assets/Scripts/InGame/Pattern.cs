using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern : MonoBehaviour
{
    private Rigidbody2D patternRigid;    private const float EndPosX = -30f;
    public void Init(float moveSpeed)//init 함수 알아보기
    {
        patternRigid = GetComponent<Rigidbody2D>();
        patternRigid.velocity = new Vector2(-moveSpeed, 0.0f);
    }

    private void Update()
    {
        if (EndPosX >= transform.parent.position.x)
        {
            Destroy(gameObject);
        }
    }
}
