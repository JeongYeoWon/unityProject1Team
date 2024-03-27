using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Player : MonoBehaviour
{
    AudioSource effectSound1;
    private Animator anim;             // ĳ������ �ִϸ����� ������Ʈ
    private SpriteRenderer spriteRenderer; // ĳ������ ��������Ʈ ������ ������Ʈ
    private Vector3 startPosition;     // ĳ������ ���� ��ġ
    private Vector3 oldPosition;       // ���� ��ġ
    private bool isTurn = false;       // ĳ���Ͱ� ȸ���ߴ��� ����

    private int MoveCnt = 0;           // �̵� Ƚ��
    private int turnCnt = 0;           // ȸ�� Ƚ��
    private int SpawnCnt = 0;          // ��� ���� Ƚ��

    private bool isDie = false;        // ��� ����

    void Start()
    {
        effectSound1 = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();                // ĳ������ Animator ������Ʈ ��������
        spriteRenderer = GetComponent<SpriteRenderer>(); // ĳ������ SpriteRenderer ������Ʈ ��������
        startPosition = transform.position;             // ĳ������ ���� ��ġ ����
        Init();                                         // �ʱ�ȭ �޼��� ȣ��
    }

    void Update()
    {
        if (isDie)
        {
            return; // ��� ������ �� �Ʒ� �ڵ���� �������� ����
        }

        /*// ���콺 ���� ��ư Ŭ�� �� CharMove() ȣ��
        if (Input.GetMouseButtonDown(0))
        {
            CharMove();
        }
        // ���콺 ������ ��ư Ŭ�� �� CharTurn() ȣ��
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

    // ���� �ʱ�ȭ �޼���
    private void Init()
    {
        transform.position = startPosition; // ĳ���� ��ġ �ʱ�ȭ
        oldPosition = startPosition;        // ���� ��ġ �ʱ�ȭ
        MoveCnt = 0;                        // �̵� Ƚ�� �ʱ�ȭ
        SpawnCnt = 0;                       // ��� ���� Ƚ�� �ʱ�ȭ
        turnCnt = 0;                        // ȸ�� Ƚ�� �ʱ�ȭ
        isTurn = false;                     // ȸ�� ���� �ʱ�ȭ
        spriteRenderer.flipX = false;       // ��������Ʈ ������ flipX �Ӽ� �ʱ�ȭ
        isDie = false;                      // ��� ���� �ʱ�ȭ
    }

    // ĳ���� ȸ�� �޼���
    private void CharTurn()
    {
        isTurn = !isTurn;                // ȸ�� ���θ� ������Ŵ

        // ĳ������ ��������Ʈ �������� ȸ����Ŵ
        spriteRenderer.flipX = isTurn;
        effectSound1.Play();
    }

    // ĳ���� �̵� �޼���
    private void CharMove()
    {
        if (isDie)
        {
            return; // ��� ������ �� �Ʒ� �ڵ���� �������� ����
        }

        MoveCnt++; // �̵� Ƚ�� ����
        MoveDirection(); // �̵� ���� ����

        if (isFailTurn()) // ȸ�� ���� �� ĳ���� ��� ó��
        {
            CharDie();
            Debug.Log("Die");
            return;
        }

        if (MoveCnt > 5) // �̵� Ƚ���� 5�� �ʰ��ϸ� ���� ��� ����
        {
            RespawnStair();
        }
        GameManager.Instance.AddScore(); // ���� �Ŵ������� ���� �߰�
    }

    // ĳ���� �̵� ���� ���� �޼���
    private void MoveDirection()
    {
        // ĳ���Ͱ� ȸ������ �� ���� ��ġ���� ���ο� ��ġ�� �̵�
        if (isTurn)
        {
            oldPosition += new Vector3(-1.2f, 0.7f, 0);
        }
        else
        {
            oldPosition += new Vector3(1.2f, 0.7f, 0);
        }
        transform.position = oldPosition; // ĳ���� ��ġ ����
        effectSound1.Play();
        anim.SetTrigger("Move"); // �ִϸ��̼� Ʈ���� ����
    }

    // ȸ�� ���� ���� Ȯ�� �޼���
    private bool isFailTurn()
    {
        bool resurt = false;

        // ���� �Ŵ����� ��� ȸ�� ������ ĳ���� ȸ�� ���� ��
        if (GameManager.Instance.isTurn[turnCnt] != isTurn)
        {
            resurt = true;
        }
        turnCnt++;

        // ȸ�� Ƚ���� ��� ������ �ʰ��ϸ� �ʱ�ȭ
        if (turnCnt > GameManager.Instance.Stairs.Length - 1)
        {
            turnCnt = 0;
        }
        return resurt;
    }

    // ���ο� ��� ���� �޼���
    private void RespawnStair()
    {
        GameManager.Instance.SpawnStair(SpawnCnt); // ���� �Ŵ������� ���ο� ��� ����
        SpawnCnt++;

        // ��� ���� Ƚ���� ��� ������ �ʰ��ϸ� �ʱ�ȭ
        if (SpawnCnt > GameManager.Instance.Stairs.Length - 1)
        {
            SpawnCnt = 0;
        }
    }

    // ĳ���� ��� ó�� �޼���
    private void CharDie()
    {
        GameManager.Instance.GameOver(); // ���� ���� ȣ��
        isDie = true; // ��� ���� ����
    }

    // ���� ����� ��ư Ŭ�� �� ȣ��Ǵ� �޼���
    public void ButtonRestart()
    {
        Init(); // �ʱ�ȭ
        GameManager.Instance.Init(); // ���� �Ŵ��� �ʱ�ȭ
        GameManager.Instance.InitStairs(); // ���� �Ŵ����� ��� �ʱ�ȭ
    }
}
