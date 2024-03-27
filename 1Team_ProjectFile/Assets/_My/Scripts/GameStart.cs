using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    AudioSource clickEffect;

    void Start()
    {
        clickEffect = GetComponent<AudioSource>();
    }
    public void GameStartBtn()
    {
        clickEffect.Play();
        SceneManager.LoadScene("Ingame"); //Ingame scene으로 이동하는 버튼이다
    }
}
