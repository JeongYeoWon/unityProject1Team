using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeBtn : MonoBehaviour
{
    AudioSource clickEffect;
    void Start()
    {
        clickEffect = GetComponent<AudioSource>();
    }
    public void GoHomeBtn()
    {
        clickEffect.Play();
        SceneManager.LoadScene("Title"); //Ingame scene���� �̵��ϴ� ��ư�̴�
    }
}
