using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBtn : MonoBehaviour
{
    public void GameStartBtn()
    {
        SoundManager.instance.SfxLoad();
        SceneManager.LoadScene("Ingame"); //Ingame scene���� �̵��ϴ� ��ư�̴�
    }
}
