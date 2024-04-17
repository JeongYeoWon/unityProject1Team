using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SfxOnBtn : MonoBehaviour
{
    public GameObject sfxOnBtn;
    public GameObject sfxOffBtn;
    void Start()
    {
        if (SoundManager.instance.sfxBtnOn)
        {
            sfxOnBtn.SetActive(true);
            sfxOffBtn.SetActive(false);
        }
        else
        {
            sfxOnBtn.SetActive(false);
            sfxOffBtn.SetActive(true);
        }
    }
    public void SfxOnBtn_OnClick()
    {
        SoundManager.instance.SFX_OnBtn_OnClick();
        SoundManager.instance.SfxLoad();
        sfxOnBtn.SetActive(false);
        sfxOffBtn.SetActive(true);
    }
}
