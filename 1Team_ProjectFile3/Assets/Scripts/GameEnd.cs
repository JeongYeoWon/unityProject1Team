using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    void Update()
    {
        // �ȵ���̵忡�� �ڷΰ��� ��ư�� ������ ��
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // ������ ����
            Application.Quit();
        }
    }
}
