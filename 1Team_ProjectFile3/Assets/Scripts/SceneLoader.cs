using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Image fadeImage; // ���̵� ���� ���� �̹���
    public float fadeDuration = 1.0f; // ���̵� �� �ð�

    private void Start()
    {
        // ���� �� ���̵� �� ȿ���� ����
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        // ���̵� �� ȿ���� ���� �̹����� �����ϰ� ����
        fadeImage.color = new Color(0, 0, 0, 1);

        // ���̵� �� ȿ�� ����
        float timer = 0;
        while (timer < fadeDuration)
        {
            float alpha = Mathf.Lerp(1, 0, timer / fadeDuration);
            fadeImage.color = new Color(0, 0, 0, alpha);
            timer += Time.deltaTime;
            yield return null;
        }

        // ���̵� ���� �Ϸ�Ǹ� �̹��� ��Ȱ��ȭ
        fadeImage.gameObject.SetActive(false);
    }

    // ȭ���� ��ġ�ϸ� ���� ��ȯ�ϰ� ���̵� �� ȿ���� ����
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(FadeOutAndLoadScene("Title"));
        }
    }

    // ���̵� �ƿ� ȿ���� �Բ� ���� �ε��ϴ� �Լ�
    private IEnumerator FadeOutAndLoadScene(string sceneName)
    {
        // ���̵� �� �̹��� Ȱ��ȭ
        fadeImage.gameObject.SetActive(true);

        // ���̵� �ƿ� ȿ�� ����
        float timer = 0;
        while (timer < fadeDuration)
        {
            float alpha = Mathf.Lerp(0, 1, timer / fadeDuration);
            fadeImage.color = new Color(0, 0, 0, alpha);
            timer += Time.deltaTime;
            yield return null;
        }

        // ���̵� �ƿ��� �Ϸ�� �� �� ��ȯ
        SceneManager.LoadScene(sceneName);
    }
}
