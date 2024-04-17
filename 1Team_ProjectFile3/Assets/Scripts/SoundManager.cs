using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    GameObject bgmObject;
    GameObject soundEffectObject;
    public AudioSource bgm;
    public AudioSource sfx;
    public bool bgmBtnOn = true, sfxBtnOn = true;
    public bool bgmOn = true, sfxOn = true;
    private void Awake()
    {
        bgmObject = GameObject.Find("TitleBGM");
        soundEffectObject = GameObject.Find("SoundEffect");
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            Debug.Log("���� �ȵ� �ν��Ͻ� ID" + GetInstanceID());

        }
        else
        {
            Destroy(this.gameObject);
            Debug.Log("���� ��" + GetInstanceID());
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        bgmOn = PlayerPrefs.GetInt("bgmOn", 1) == 0;
        sfxOn = PlayerPrefs.GetInt("sfxOn", 1) == 0;
        Debug.Log(bgmOn);
        Debug.Log(sfxOn);
        if (!bgmOn)
        {
            bgmBtnOn = false;
            bgm.Stop();
        }
        else if (bgmOn)
        {
            bgmBtnOn = true;
            bgm.Play();
        }

        if (!sfxOn)
        {
            sfxBtnOn = false;
            sfx.Stop();
        }
        else if (sfxOn)
        {
            sfxBtnOn = true;
            Debug.Log("ȿ���� ��������");
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // ���� �ε�� ������ ����� �ҽ��� ã��
        if (scene.name == "Title")
        {
            Debug.Log("Ÿ��Ʋ Ȯ��");
            bgmObject = GameObject.Find("TitleBGM");
        }
        else if (scene.name == "Ingame")
        {
            Debug.Log("�ΰ��� Ȯ��");
            Debug.Log(bgmBtnOn);
            bgmObject = GameObject.Find("IngameBGM"); Debug.Log(bgmObject);
        }

        soundEffectObject = GameObject.Find("SoundEffect");

        if (bgmObject != null)
        {
            bgm = bgmObject.GetComponent<AudioSource>();
            Debug.Log("����� Ȯ��");
        }

        if (soundEffectObject != null)
        {
            sfx = soundEffectObject.GetComponent<AudioSource>();
            Debug.Log("ȿ���� Ȯ��");
        }

        if (bgm != null && bgmOn)
        {
            bgm.Play();
            Debug.Log("���۵Ǵ��� Ȯ��");
        }
    }

    public void BGM_OnBtn_OnClick()
    {
        bgmBtnOn = false;
        bgmOn = false;
        PlayerPrefs.SetInt("bgmOn", bgmOn ? 1 : 0);
        PlayerPrefs.SetInt("bgmOnBtn", bgmBtnOn ? 1 : 0);
    }

    public void BGM_OffBtn_OnClick()
    {
        bgmBtnOn = true;
        bgmOn = true;
        PlayerPrefs.SetInt("bgmOn", bgmOn ? 1 : 0);
        PlayerPrefs.SetInt("bgmOnBtn", bgmBtnOn ? 1 : 0);
    }

    public void BgmLoad()
    {
        Debug.Log(bgmBtnOn);
        if (!bgmOn)
        {
            bgm.Stop();
        }
        else if (bgmOn)
        {
            bgm.Play();
        }
    }

    public void SFX_OnBtn_OnClick()
    {
            sfxBtnOn = false;
            sfxOn = false;
        PlayerPrefs.SetInt("sfxOn", sfxOn ? 1 : 0);
    }
    public void SFX_OffBtn_OnClick()
    {
        sfxBtnOn = true;
        sfxOn = true;
        PlayerPrefs.SetInt("sfxOn", sfxOn ? 1 : 0);
    }
    public void SfxLoad()
    {
        if (!sfxBtnOn)
        {
            sfx.Stop();
        }
        else if (sfxBtnOn)
        {
            sfx.Play();
        }
    }
}
