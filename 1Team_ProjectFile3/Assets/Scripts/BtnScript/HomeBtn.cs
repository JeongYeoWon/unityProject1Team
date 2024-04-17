using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeBtn : MonoBehaviour
{
    public void GoHomeBtn()
    {
        SoundManager.instance.SfxLoad();
        SceneManager.LoadScene("Title"); //Ingame scene으로 이동하는 버튼이다
    }
}
