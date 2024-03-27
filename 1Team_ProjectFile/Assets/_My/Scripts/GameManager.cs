using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // GameManager의 인스턴스를 저장하는 변수

    [Header("계단")] // 인스펙터 창에서 변수 그룹화를 위한 헤더
    [Space(10)] // 공백 추가

    public GameObject[] Stairs; // 계단 게임 오브젝트 배열
    public bool[] isTurn; // 각 계단의 회전 여부를 나타내는 불리언 배열

    private enum State { Start, Left, Right }; // 계단 이동 상태를 나타내는 열거형
    private State state; // 현재 계단 이동 상태
    private Vector3 oldPosition; // 이전 위치를 저장하는 변수

    [Header("UI")] // 인스펙터 창에서 변수 그룹화를 위한 헤더
    [Space(10)] // 공백 추가

    public GameObject UI_GameOver; // 게임 오버 UI 오브젝트
    public TextMeshProUGUI textMaxScore; // 최고 점수를 나타내는 TMP 텍스트
    public TextMeshProUGUI textNowScore; // 현재 점수를 나타내는 TMP 텍스트
    public TextMeshProUGUI textShowScore; // 화면에 표시되는 점수를 나타내는 TMP 텍스트
    public TextMeshProUGUI textShowMaxScore; // 화면에 표시되는 최고 점수를 나타내는 TMP 텍스트
    private int maxScore = 0; // 최고 점수
    private int nowScore = 0; // 현재 점수


    void Start()
    {
        Instance = this; // GameManager의 인스턴스 설정
        Init(); // 초기화 메서드 호출
        InitStairs(); // 계단 초기화 메서드 호출
    }

    public void Init()
    {
        // 게임 초기화 메서드

        state = State.Start; // 초기 상태를 시작 상태로 설정
        oldPosition = Vector3.zero; // 이전 위치를 초기화

        isTurn = new bool[Stairs.Length]; // 계단 회전 여부 배열 초기화

        // 모든 계단을 초기 위치로 이동하고 회전 상태를 초기화
        for (int i = 0; i < Stairs.Length; i++)
        {
            Stairs[i].transform.position = Vector3.zero;
            isTurn[i] = false;
        }

        nowScore = 0; // 현재 점수 초기화
        textShowScore.text = nowScore.ToString(); // 화면에 현재 점수 표시
        textShowMaxScore.text = maxScore.ToString();
        UI_GameOver.SetActive(false); // 게임 오버 UI 비활성화
    }

    // 계단 초기화 메서드
    public void InitStairs()
    {
        for (int i = 0; i < Stairs.Length; i++)
        {
            switch (state)
            {
                case State.Start:
                    // 시작 상태일 때, 첫 번째 계단을 오른쪽 위에 배치
                    Stairs[i].transform.position = new Vector3(1.2f, 1.0f, 0);
                    state = State.Right; // 다음 상태를 오른쪽으로 이동 상태로 설정
                    break;
                case State.Left:
                    // 왼쪽으로 이동하는 상태일 때, 이전 위치에서 왼쪽으로 이동한 위치에 계단 배치
                    Stairs[i].transform.position = oldPosition + new Vector3(-1.2f, 0.7f, 0);
                    isTurn[i] = true; // 해당 계단이 회전했음을 표시
                    break;
                case State.Right:
                    // 오른쪽으로 이동하는 상태일 때, 이전 위치에서 오른쪽으로 이동한 위치에 계단 배치
                    Stairs[i].transform.position = oldPosition + new Vector3(1.2f, 0.7f, 0);
                    isTurn[i] = false; // 해당 계단이 회전하지 않았음을 표시
                    break;
            }
            oldPosition = Stairs[i].transform.position; // 이전 위치를 현재 계단의 위치로 업데이트

            // 첫 번째 계단을 제외하고
            if (i != 0)
            {
                int ran = Random.Range(0, 5); // 0부터 4 사이의 랜덤한 값 생성

                // 랜덤 값이 2 미만이고, 현재 계단이 마지막 계단이 아닌 경우
                if (ran < 2 && i < Stairs.Length - 1)
                {
                    state = state == State.Left ? State.Right : State.Left; // 이동 방향 변경
                }
            }
        }
    }


    public void SpawnStair(int cnt)
    {
        int ran = Random.Range(0, 5); // 0부터 4 사이의 랜덤한 정수 값을 생성하여 ran 변수에 저장

        if (ran < 2) // 랜덤 값이 2 미만인 경우
        {
            state = state == State.Left ? State.Right : State.Left; // state 변수의 값을 왼쪽과 오른쪽 중 하나로 전환
        }

        switch (state) // state 변수의 상태에 따라 처리
        {
            case State.Left: // 왼쪽으로 이동 상태인 경우
                             // 이전 위치에서 왼쪽으로 이동한 위치에 계단을 배치하고 해당 계단이 회전했음을 표시
                Stairs[cnt].transform.position = oldPosition + new Vector3(-1.2f, 0.7f, 0);
                isTurn[cnt] = true;
                break;
            case State.Right: // 오른쪽으로 이동 상태인 경우
                              // 이전 위치에서 오른쪽으로 이동한 위치에 계단을 배치하고 해당 계단이 회전하지 않았음을 표시
                Stairs[cnt].transform.position = oldPosition + new Vector3(1.2f, 0.7f, 0);
                isTurn[cnt] = false;
                break;
        }

        oldPosition = Stairs[cnt].transform.position; // 계단을 배치한 후, 이전 위치를 현재 계단의 위치로 업데이트

    }

    public void GameOver()
    {
        GetComponent<AudioSource>().Stop();
        // 게임 오버 처리 메서드
        StartCoroutine(ShowGameOver());
    }

    IEnumerator ShowGameOver()
    {
        // 게임 오버 UI 표시 코루틴

        yield return new WaitForSeconds(1f); // 1초 대기

        UI_GameOver.SetActive(true); // 게임 오버 UI 활성화

        if (nowScore > maxScore)
        {
            maxScore = nowScore; // 최고 점수 갱신
        }

        textMaxScore.text = maxScore.ToString(); // 최고 점수 표시
        textNowScore.text = nowScore.ToString(); // 현재 점수 표시
    }

    public void AddScore()
    {
        // 점수 추가 메서드
        nowScore++; // 현재 점수 증가
        textShowScore.text = nowScore.ToString(); // 화면에 현재 점수 표시
    }

}
