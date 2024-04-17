using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgmOnBtn : MonoBehaviour
{
    public GameObject bgmOnBtn;
    public GameObject bgmOffBtn;
    private void Awake()
    {
        if (SoundManager.instance.bgmBtnOn)
        {
            Debug.Log($"���ON ��ư Ŭ�� Ȯ��1_TURE{SoundManager.instance.bgmBtnOn}");
            bgmOnBtn.SetActive(true);
            bgmOffBtn.SetActive(false);
        }
        else
        {
            Debug.Log($"���ON ��ư Ŭ�� Ȯ��1_FALSE{SoundManager.instance.bgmBtnOn}");
            bgmOnBtn.SetActive(false);
            bgmOffBtn.SetActive(true);
        }
    }
    /*void Start()
    {
        if (SoundManager.instance.bgmBtnOn)
        {
            bgmOnBtn.SetActive(true);
            bgmOffBtn.SetActive(false);
        }
        else
        {
            bgmOnBtn.SetActive(false);
            bgmOffBtn.SetActive(true);
        }
    }*/
    public void BgmOnBtn_OnClick()
    {
        SoundManager.instance.BGM_OnBtn_OnClick();
        SoundManager.instance.BgmLoad();
        Debug.Log($"���ON ��ư Ŭ�� Ȯ��2{SoundManager.instance.bgmBtnOn}");
        bgmOnBtn.SetActive(false);
        bgmOffBtn.SetActive(true);
    }
}
