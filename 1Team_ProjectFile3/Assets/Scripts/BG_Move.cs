using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Move : MonoBehaviour
{
    public float scrollSpeed = 0.02f; // 배경 이미지의 스크롤 속도
    Renderer cloudRenderer; // 배경 이미지의 Renderer 컴포넌트
    void Start()
    {
        // 배경 이미지의 Renderer 컴포넌트를 가져옴
        cloudRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // 배경 이미지의 Offset을 변경하여 스크롤 효과를 구현
        float offsetX = Time.time * scrollSpeed;
        Vector2 offset = new Vector2(offsetX, 0);
        cloudRenderer.material.mainTextureOffset = offset;
    }
}
