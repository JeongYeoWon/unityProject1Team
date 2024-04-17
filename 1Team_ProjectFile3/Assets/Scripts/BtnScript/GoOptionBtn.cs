using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoOptionBtn : MonoBehaviour
{
    public GameObject Option;
    void Start()
    {
        Option.SetActive(false);
    }

    public void GoOptionOnClick()
    {
        SoundManager.instance.SfxLoad();
        Option.SetActive(true);
    }
}
