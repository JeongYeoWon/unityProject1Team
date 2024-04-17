using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    void Update()
    {
        // 안드로이드에서 뒤로가기 버튼이 눌렸을 때
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // 게임을 종료
            Application.Quit();
        }
    }
}
