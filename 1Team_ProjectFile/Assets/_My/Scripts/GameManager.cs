using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // GameManager�� �ν��Ͻ��� �����ϴ� ����

    [Header("���")] // �ν����� â���� ���� �׷�ȭ�� ���� ���
    [Space(10)] // ���� �߰�

    public GameObject[] Stairs; // ��� ���� ������Ʈ �迭
    public bool[] isTurn; // �� ����� ȸ�� ���θ� ��Ÿ���� �Ҹ��� �迭

    private enum State { Start, Left, Right }; // ��� �̵� ���¸� ��Ÿ���� ������
    private State state; // ���� ��� �̵� ����
    private Vector3 oldPosition; // ���� ��ġ�� �����ϴ� ����

    [Header("UI")] // �ν����� â���� ���� �׷�ȭ�� ���� ���
    [Space(10)] // ���� �߰�

    public GameObject UI_GameOver; // ���� ���� UI ������Ʈ
    public TextMeshProUGUI textMaxScore; // �ְ� ������ ��Ÿ���� TMP �ؽ�Ʈ
    public TextMeshProUGUI textNowScore; // ���� ������ ��Ÿ���� TMP �ؽ�Ʈ
    public TextMeshProUGUI textShowScore; // ȭ�鿡 ǥ�õǴ� ������ ��Ÿ���� TMP �ؽ�Ʈ
    public TextMeshProUGUI textShowMaxScore; // ȭ�鿡 ǥ�õǴ� �ְ� ������ ��Ÿ���� TMP �ؽ�Ʈ
    private int maxScore = 0; // �ְ� ����
    private int nowScore = 0; // ���� ����


    void Start()
    {
        Instance = this; // GameManager�� �ν��Ͻ� ����
        Init(); // �ʱ�ȭ �޼��� ȣ��
        InitStairs(); // ��� �ʱ�ȭ �޼��� ȣ��
    }

    public void Init()
    {
        // ���� �ʱ�ȭ �޼���

        state = State.Start; // �ʱ� ���¸� ���� ���·� ����
        oldPosition = Vector3.zero; // ���� ��ġ�� �ʱ�ȭ

        isTurn = new bool[Stairs.Length]; // ��� ȸ�� ���� �迭 �ʱ�ȭ

        // ��� ����� �ʱ� ��ġ�� �̵��ϰ� ȸ�� ���¸� �ʱ�ȭ
        for (int i = 0; i < Stairs.Length; i++)
        {
            Stairs[i].transform.position = Vector3.zero;
            isTurn[i] = false;
        }

        nowScore = 0; // ���� ���� �ʱ�ȭ
        textShowScore.text = nowScore.ToString(); // ȭ�鿡 ���� ���� ǥ��
        textShowMaxScore.text = maxScore.ToString();
        UI_GameOver.SetActive(false); // ���� ���� UI ��Ȱ��ȭ
    }

    // ��� �ʱ�ȭ �޼���
    public void InitStairs()
    {
        for (int i = 0; i < Stairs.Length; i++)
        {
            switch (state)
            {
                case State.Start:
                    // ���� ������ ��, ù ��° ����� ������ ���� ��ġ
                    Stairs[i].transform.position = new Vector3(1.2f, 1.0f, 0);
                    state = State.Right; // ���� ���¸� ���������� �̵� ���·� ����
                    break;
                case State.Left:
                    // �������� �̵��ϴ� ������ ��, ���� ��ġ���� �������� �̵��� ��ġ�� ��� ��ġ
                    Stairs[i].transform.position = oldPosition + new Vector3(-1.2f, 0.7f, 0);
                    isTurn[i] = true; // �ش� ����� ȸ�������� ǥ��
                    break;
                case State.Right:
                    // ���������� �̵��ϴ� ������ ��, ���� ��ġ���� ���������� �̵��� ��ġ�� ��� ��ġ
                    Stairs[i].transform.position = oldPosition + new Vector3(1.2f, 0.7f, 0);
                    isTurn[i] = false; // �ش� ����� ȸ������ �ʾ����� ǥ��
                    break;
            }
            oldPosition = Stairs[i].transform.position; // ���� ��ġ�� ���� ����� ��ġ�� ������Ʈ

            // ù ��° ����� �����ϰ�
            if (i != 0)
            {
                int ran = Random.Range(0, 5); // 0���� 4 ������ ������ �� ����

                // ���� ���� 2 �̸��̰�, ���� ����� ������ ����� �ƴ� ���
                if (ran < 2 && i < Stairs.Length - 1)
                {
                    state = state == State.Left ? State.Right : State.Left; // �̵� ���� ����
                }
            }
        }
    }


    public void SpawnStair(int cnt)
    {
        int ran = Random.Range(0, 5); // 0���� 4 ������ ������ ���� ���� �����Ͽ� ran ������ ����

        if (ran < 2) // ���� ���� 2 �̸��� ���
        {
            state = state == State.Left ? State.Right : State.Left; // state ������ ���� ���ʰ� ������ �� �ϳ��� ��ȯ
        }

        switch (state) // state ������ ���¿� ���� ó��
        {
            case State.Left: // �������� �̵� ������ ���
                             // ���� ��ġ���� �������� �̵��� ��ġ�� ����� ��ġ�ϰ� �ش� ����� ȸ�������� ǥ��
                Stairs[cnt].transform.position = oldPosition + new Vector3(-1.2f, 0.7f, 0);
                isTurn[cnt] = true;
                break;
            case State.Right: // ���������� �̵� ������ ���
                              // ���� ��ġ���� ���������� �̵��� ��ġ�� ����� ��ġ�ϰ� �ش� ����� ȸ������ �ʾ����� ǥ��
                Stairs[cnt].transform.position = oldPosition + new Vector3(1.2f, 0.7f, 0);
                isTurn[cnt] = false;
                break;
        }

        oldPosition = Stairs[cnt].transform.position; // ����� ��ġ�� ��, ���� ��ġ�� ���� ����� ��ġ�� ������Ʈ

    }

    public void GameOver()
    {
        GetComponent<AudioSource>().Stop();
        // ���� ���� ó�� �޼���
        StartCoroutine(ShowGameOver());
    }

    IEnumerator ShowGameOver()
    {
        // ���� ���� UI ǥ�� �ڷ�ƾ

        yield return new WaitForSeconds(1f); // 1�� ���

        UI_GameOver.SetActive(true); // ���� ���� UI Ȱ��ȭ

        if (nowScore > maxScore)
        {
            maxScore = nowScore; // �ְ� ���� ����
        }

        textMaxScore.text = maxScore.ToString(); // �ְ� ���� ǥ��
        textNowScore.text = nowScore.ToString(); // ���� ���� ǥ��
    }

    public void AddScore()
    {
        // ���� �߰� �޼���
        nowScore++; // ���� ���� ����
        textShowScore.text = nowScore.ToString(); // ȭ�鿡 ���� ���� ǥ��
    }

}
