using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxOffBtn : MonoBehaviour
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
    public void SfxOffBtn_OnClick()
    {
        SoundManager.instance.SFX_OffBtn_OnClick();
        SoundManager.instance.SfxLoad();
        sfxOnBtn.SetActive(true);
        sfxOffBtn.SetActive(false);
    }
}
