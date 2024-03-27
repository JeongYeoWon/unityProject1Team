using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Player : MonoBehaviour
{
    AudioSource effectSound1;
    private Animator anim;             // 캐릭터의 애니메이터 컴포넌트
    private SpriteRenderer spriteRenderer; // 캐릭터의 스프라이트 렌더러 컴포넌트
    private Vector3 startPosition;     // 캐릭터의 시작 위치
    private Vector3 oldPosition;       // 이전 위치
    private bool isTurn = false;       // 캐릭터가 회전했는지 여부

    private int MoveCnt = 0;           // 이동 횟수
    private int turnCnt = 0;           // 회전 횟수
    private int SpawnCnt = 0;          // 계단 생성 횟수

    private bool isDie = false;        // 사망 여부

    void Start()
    {
        effectSound1 = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();                // 캐릭터의 Animator 컴포넌트 가져오기
        spriteRenderer = GetComponent<SpriteRenderer>(); // 캐릭터의 SpriteRenderer 컴포넌트 가져오기
        startPosition = transform.position;             // 캐릭터의 시작 위치 설정
        Init();                                         // 초기화 메서드 호출
    }

    void Update()
    {
        if (isDie)
        {
            return; // 사망 상태일 때 아래 코드들을 실행하지 않음
        }

        /*// 마우스 왼쪽 버튼 클릭 시 CharMove() 호출
        if (Input.GetMouseButtonDown(0))
        {
            CharMove();
        }
        // 마우스 오른쪽 버튼 클릭 시 CharTurn() 호출
        else if (Input.GetMouseButtonDown(1))
        {
            CharTurn();
        }*/
    }

    public void TurnBtn()
    {
        CharTurn();
    }

    public void UpBtn()
    {
        CharMove();
    }

    // 게임 초기화 메서드
    private void Init()
    {
        transform.position = startPosition; // 캐릭터 위치 초기화
        oldPosition = startPosition;        // 이전 위치 초기화
        MoveCnt = 0;                        // 이동 횟수 초기화
        SpawnCnt = 0;                       // 계단 생성 횟수 초기화
        turnCnt = 0;                        // 회전 횟수 초기화
        isTurn = false;                     // 회전 여부 초기화
        spriteRenderer.flipX = false;       // 스프라이트 렌더러 flipX 속성 초기화
        isDie = false;                      // 사망 여부 초기화
    }

    // 캐릭터 회전 메서드
    private void CharTurn()
    {
        isTurn = !isTurn;                // 회전 여부를 반전시킴

        // 캐릭터의 스프라이트 렌더러를 회전시킴
        spriteRenderer.flipX = isTurn;
        effectSound1.Play();
    }

    // 캐릭터 이동 메서드
    private void CharMove()
    {
        if (isDie)
        {
            return; // 사망 상태일 때 아래 코드들을 실행하지 않음
        }

        MoveCnt++; // 이동 횟수 증가
        MoveDirection(); // 이동 방향 설정

        if (isFailTurn()) // 회전 실패 시 캐릭터 사망 처리
        {
            CharDie();
            Debug.Log("Die");
            return;
        }

        if (MoveCnt > 5) // 이동 횟수가 5를 초과하면 다음 계단 생성
        {
            RespawnStair();
        }
        GameManager.Instance.AddScore(); // 게임 매니저에서 점수 추가
    }

    // 캐릭터 이동 방향 설정 메서드
    private void MoveDirection()
    {
        // 캐릭터가 회전했을 때 이전 위치에서 새로운 위치로 이동
        if (isTurn)
        {
            oldPosition += new Vector3(-1.2f, 0.7f, 0);
        }
        else
        {
            oldPosition += new Vector3(1.2f, 0.7f, 0);
        }
        transform.position = oldPosition; // 캐릭터 위치 변경
        effectSound1.Play();
        anim.SetTrigger("Move"); // 애니메이션 트리거 설정
    }

    // 회전 실패 여부 확인 메서드
    private bool isFailTurn()
    {
        bool resurt = false;

        // 게임 매니저의 계단 회전 정보와 캐릭터 회전 정보 비교
        if (GameManager.Instance.isTurn[turnCnt] != isTurn)
        {
            resurt = true;
        }
        turnCnt++;

        // 회전 횟수가 계단 개수를 초과하면 초기화
        if (turnCnt > GameManager.Instance.Stairs.Length - 1)
        {
            turnCnt = 0;
        }
        return resurt;
    }

    // 새로운 계단 생성 메서드
    private void RespawnStair()
    {
        GameManager.Instance.SpawnStair(SpawnCnt); // 게임 매니저에서 새로운 계단 생성
        SpawnCnt++;

        // 계단 생성 횟수가 계단 개수를 초과하면 초기화
        if (SpawnCnt > GameManager.Instance.Stairs.Length - 1)
        {
            SpawnCnt = 0;
        }
    }

    // 캐릭터 사망 처리 메서드
    private void CharDie()
    {
        GameManager.Instance.GameOver(); // 게임 오버 호출
        isDie = true; // 사망 상태 설정
    }

    // 게임 재시작 버튼 클릭 시 호출되는 메서드
    public void ButtonRestart()
    {
        Init(); // 초기화
        GameManager.Instance.Init(); // 게임 매니저 초기화
        GameManager.Instance.InitStairs(); // 게임 매니저의 계단 초기화
    }
}
