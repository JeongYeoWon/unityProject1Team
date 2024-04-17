using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Image fadeImage; // 페이드 인을 위한 이미지
    public float fadeDuration = 1.0f; // 페이드 인 시간

    private void Start()
    {
        // 시작 시 페이드 인 효과를 실행
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        // 페이드 인 효과를 위해 이미지를 투명하게 설정
        fadeImage.color = new Color(0, 0, 0, 1);

        // 페이드 인 효과 실행
        float timer = 0;
        while (timer < fadeDuration)
        {
            float alpha = Mathf.Lerp(1, 0, timer / fadeDuration);
            fadeImage.color = new Color(0, 0, 0, alpha);
            timer += Time.deltaTime;
            yield return null;
        }

        // 페이드 인이 완료되면 이미지 비활성화
        fadeImage.gameObject.SetActive(false);
    }

    // 화면을 터치하면 씬을 전환하고 페이드 인 효과를 적용
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(FadeOutAndLoadScene("Title"));
        }
    }

    // 페이드 아웃 효과와 함께 씬을 로드하는 함수
    private IEnumerator FadeOutAndLoadScene(string sceneName)
    {
        // 페이드 인 이미지 활성화
        fadeImage.gameObject.SetActive(true);

        // 페이드 아웃 효과 실행
        float timer = 0;
        while (timer < fadeDuration)
        {
            float alpha = Mathf.Lerp(0, 1, timer / fadeDuration);
            fadeImage.color = new Color(0, 0, 0, alpha);
            timer += Time.deltaTime;
            yield return null;
        }

        // 페이드 아웃이 완료된 후 씬 전환
        SceneManager.LoadScene(sceneName);
    }
}
