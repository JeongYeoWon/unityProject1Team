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
        SceneManager.LoadScene("Ingame"); //Ingame scene���� �̵��ϴ� ��ư�̴�
    }
}
