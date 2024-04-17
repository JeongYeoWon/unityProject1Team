using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmOffBtn : MonoBehaviour
{
    public GameObject bgmOnBtn;
    public GameObject bgmOffBtn;
    private void Awake()
    {
        if (SoundManager.instance.bgmBtnOn)
        {
            Debug.Log($"배경OFF 버튼 클릭 확인1_TRUE{SoundManager.instance.bgmBtnOn}");
            bgmOnBtn.SetActive(true);
            bgmOffBtn.SetActive(false);
        }
        else
        {
            Debug.Log($"배경OFF 버튼 클릭 확인1_FALSE{SoundManager.instance.bgmBtnOn}");
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
    public void BgmOffBtn_OnClick()
    {
        SoundManager.instance.BGM_OffBtn_OnClick();
        SoundManager.instance.BgmLoad();
        Debug.Log($"배경OFF 버튼 클릭 확인2{SoundManager.instance.bgmBtnOn}");
        bgmOnBtn.SetActive(true);
        bgmOffBtn.SetActive(false);
    }
}
