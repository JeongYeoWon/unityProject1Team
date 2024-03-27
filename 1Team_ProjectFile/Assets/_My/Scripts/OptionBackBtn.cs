using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionBackBtn : MonoBehaviour
{
    AudioSource clickEffect;
    public GameObject Option;
    void Start()
    {
        clickEffect = GetComponent<AudioSource>();
    }
    public void OnClick()
    {
        clickEffect.Play();
        Option.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
