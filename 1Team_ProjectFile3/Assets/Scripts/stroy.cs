/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Story : MonoBehaviour
{
    public GameObject[] objectsToChangeGroup1; // 그룹 1의 오브젝트들
    public GameObject[] objectsToChangeGroup2; // 그룹 2의 오브젝트들

    private int currentIndex = 0; // 현재 활성화된 오브젝트의 인덱스

    private void Start()
    {
        StartCoroutine(ChangeObjects());
    }

    private IEnumerator ChangeObjects()
    {
        // 모든 오브젝트 비활성화
        DeactivateAllObjects();

        // 그룹 1의 오브젝트들 활성화
        foreach (GameObject obj in objectsToChangeGroup1)
        {
            obj.SetActive(true);
            yield return new WaitForSeconds(2f);

            obj.SetActive(false);
        }

        // 그룹 2의 오브젝트들 활성화
        foreach (GameObject obj in objectsToChangeGroup2)
        {
            obj.SetActive(true);
            yield return new WaitForSeconds(0.5f);

            obj.SetActive(false);
        }
    }

    private void DeactivateAllObjects()
    {
        foreach (GameObject obj in objectsToChangeGroup1)
        {
            obj.SetActive(false);
        }

        foreach (GameObject obj in objectsToChangeGroup2)
        {
            obj.SetActive(false);
        }
    }

    private void Update()
    {
        // 마우스 클릭 또는 터치를 감지하여 씬 변경
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Title");
        }
    }
}
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Story : MonoBehaviour
{
    public GameObject[] objectsToChangeGroup1; // 그룹 1의 오브젝트들
    public GameObject[] objectsToChangeGroup2; // 그룹 2의 오브젝트들

    private int currentIndex = 0; // 현재 활성화된 오브젝트의 인덱스
    private int maxIndex = 6; // 이동할 최대 인덱스

    private void Start()
    {
        StartCoroutine(ChangeObjects());
    }

    private IEnumerator ChangeObjects()
    {
        // 모든 오브젝트 비활성화
        DeactivateAllObjects();

        // 그룹 1의 오브젝트들 활성화
        foreach (GameObject obj in objectsToChangeGroup1)
        {
            obj.SetActive(true);
            yield return new WaitForSeconds(2f);

            obj.SetActive(false);

            currentIndex++; // 인덱스 증가
            if (currentIndex >= maxIndex)
            {
                LoadTitleScene();
                yield break; // 이동하면서 나머지 루프를 멈춥니다.
            }
        }

        // 그룹 2의 오브젝트들 활성화
        foreach (GameObject obj in objectsToChangeGroup2)
        {
            obj.SetActive(true);
            yield return new WaitForSeconds(0.5f);

            //obj.SetActive(false);

            currentIndex++; // 인덱스 증가
            if (currentIndex >= maxIndex)
            {
                LoadTitleScene();
                yield break; // 이동하면서 나머지 루프를 멈춥니다.
            }
        }
    }

    private void DeactivateAllObjects()
    {
        foreach (GameObject obj in objectsToChangeGroup1)
        {
            obj.SetActive(false);
        }

        foreach (GameObject obj in objectsToChangeGroup2)
        {
            obj.SetActive(false);
        }
    }

    private void LoadTitleScene()
    {
        SceneManager.LoadScene("Title");
    }
}

