using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameController gameController;
    [SerializeField]
    private GameObject playerDieEffect; // 플레이어 사망 이펙트
    [SerializeField]
    private float moveSpeed = 5; // 이동 속도
    [SerializeField]
    private float jumpForce = 15; // 점프 힘

    private Rigidbody2D rb2D; // 속력 제어를 위한 Rigidbody2D

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.isKinematic = true;
        //rb2D.velocity = new Vector2(moveSpeed, jumpForce);
        //StartCoroutine(nameof(UpdateInput));
    }

    private IEnumerator Start()
    {
        float originY = transform.position.y;
        float deltaY = 0.5f;
        float moveSpeedY = 2;

        while (true)
        {
            float y = originY + deltaY * Mathf.Sin(Time.time * moveSpeedY);
            transform.position = new Vector2(transform.position.x, y);

            yield return null;
        }
    }

    public void GameStart()
    {
        rb2D.isKinematic = false;
        rb2D.velocity = new Vector2(moveSpeed, jumpForce);

        StopCoroutine(nameof(Start));
        StartCoroutine(nameof(UpdateInput));
    }

    private IEnumerator UpdateInput()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                JumpTo();
            }

            yield return null;
        }
    }

    private void ReverseXDir()
    {
        float x = -Mathf.Sign(rb2D.velocity.x); // 0or양수일 경우 1, 음수일 경우 -1 반환
        rb2D.velocity = new Vector2(x * moveSpeed, rb2D.velocity.y);
    }

    private void JumpTo()
    {
        rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            // 플레이어 x축 방향 전환
            ReverseXDir();
            // 벽과 충돌했을 때 로직 (점수 증가, 색상 변경, 가시 활성/비활성)
            gameController.CollisionWithWall();
        }
        else if (collision.CompareTag("Spike"))
        {
            // 플레이어 사망 이펙트 생성
            Instantiate(playerDieEffect, transform.position, Quaternion.identity);
            // 게임오버 처리
            gameController.GameOver();
            // 플레이어 비활성화
            gameObject.SetActive(false);
        }
    }

}
