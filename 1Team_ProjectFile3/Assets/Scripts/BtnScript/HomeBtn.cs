using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeBtn : MonoBehaviour
{
    public void GoHomeBtn()
    {
        SoundManager.instance.SfxLoad();
        SceneManager.LoadScene("Title"); //Ingame scene���� �̵��ϴ� ��ư�̴�
    }
}
