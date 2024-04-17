/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Story : MonoBehaviour
{
    public GameObject[] objectsToChangeGroup1; // �׷� 1�� ������Ʈ��
    public GameObject[] objectsToChangeGroup2; // �׷� 2�� ������Ʈ��

    private int currentIndex = 0; // ���� Ȱ��ȭ�� ������Ʈ�� �ε���

    private void Start()
    {
        StartCoroutine(ChangeObjects());
    }

    private IEnumerator ChangeObjects()
    {
        // ��� ������Ʈ ��Ȱ��ȭ
        DeactivateAllObjects();

        // �׷� 1�� ������Ʈ�� Ȱ��ȭ
        foreach (GameObject obj in objectsToChangeGroup1)
        {
            obj.SetActive(true);
            yield return new WaitForSeconds(2f);

            obj.SetActive(false);
        }

        // �׷� 2�� ������Ʈ�� Ȱ��ȭ
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
        // ���콺 Ŭ�� �Ǵ� ��ġ�� �����Ͽ� �� ����
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
    public GameObject[] objectsToChangeGroup1; // �׷� 1�� ������Ʈ��
    public GameObject[] objectsToChangeGroup2; // �׷� 2�� ������Ʈ��

    private int currentIndex = 0; // ���� Ȱ��ȭ�� ������Ʈ�� �ε���
    private int maxIndex = 6; // �̵��� �ִ� �ε���

    private void Start()
    {
        StartCoroutine(ChangeObjects());
    }

    private IEnumerator ChangeObjects()
    {
        // ��� ������Ʈ ��Ȱ��ȭ
        DeactivateAllObjects();

        // �׷� 1�� ������Ʈ�� Ȱ��ȭ
        foreach (GameObject obj in objectsToChangeGroup1)
        {
            obj.SetActive(true);
            yield return new WaitForSeconds(2f);

            obj.SetActive(false);

            currentIndex++; // �ε��� ����
            if (currentIndex >= maxIndex)
            {
                LoadTitleScene();
                yield break; // �̵��ϸ鼭 ������ ������ ����ϴ�.
            }
        }

        // �׷� 2�� ������Ʈ�� Ȱ��ȭ
        foreach (GameObject obj in objectsToChangeGroup2)
        {
            obj.SetActive(true);
            yield return new WaitForSeconds(0.5f);

            //obj.SetActive(false);

            currentIndex++; // �ε��� ����
            if (currentIndex >= maxIndex)
            {
                LoadTitleScene();
                yield break; // �̵��ϸ鼭 ������ ������ ����ϴ�.
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

