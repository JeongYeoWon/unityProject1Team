using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Move : MonoBehaviour
{
    public float scrollSpeed = 0.02f; // ��� �̹����� ��ũ�� �ӵ�
    Renderer cloudRenderer; // ��� �̹����� Renderer ������Ʈ
    void Start()
    {
        // ��� �̹����� Renderer ������Ʈ�� ������
        cloudRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // ��� �̹����� Offset�� �����Ͽ� ��ũ�� ȿ���� ����
        float offsetX = Time.time * scrollSpeed;
        Vector2 offset = new Vector2(offsetX, 0);
        cloudRenderer.material.mainTextureOffset = offset;
    }
}
