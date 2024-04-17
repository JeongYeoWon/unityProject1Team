using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackOptionBtn : MonoBehaviour
{
    public GameObject Option;
    public void BackOptionOnClick()
    {
        SoundManager.instance.SfxLoad();
        Option.SetActive(false);
    }
}
