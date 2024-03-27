using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoOptionBtn : MonoBehaviour
{
    AudioSource clickEffect;
    public GameObject Option;
    // Start is called before the first frame update
    void Start()
    {
        Option.SetActive(false);
        clickEffect = GetComponent<AudioSource>();
    }

    public void OnClick()
    {
        clickEffect.Play();
        Option.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
