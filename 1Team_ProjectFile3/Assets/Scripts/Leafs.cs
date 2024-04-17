using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leafs : MonoBehaviour
{
    public Sprite[] leafs;
    SpriteRenderer sr;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        int ranS = Random.Range(0, leafs.Length);
        sr.sprite = leafs[ranS];
    }
}
