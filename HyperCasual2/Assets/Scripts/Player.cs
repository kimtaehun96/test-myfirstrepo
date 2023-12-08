using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameController gameController;
    [SerializeField]
    private GameObject playerDieEffect; // �÷��̾� ��� ����Ʈ
    [SerializeField]
    private float moveSpeed = 5; // �̵� �ӵ�
    [SerializeField]
    private float jumpForce = 15; // ���� ��

    private Rigidbody2D rb2D; // �ӷ� ��� ���� Rigidbody2D

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
        float x = -Mathf.Sign(rb2D.velocity.x); // 0or����� ��� 1, ������ ��� -1 ��ȯ
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
            // �÷��̾� x�� ���� ��ȯ
            ReverseXDir();
            // ���� �浹���� �� ���� (���� ����, ���� ����, ���� Ȱ��/��Ȱ��)
            gameController.CollisionWithWall();
        }
        else if (collision.CompareTag("Spike"))
        {
            // �÷��̾� ��� ����Ʈ ����
            Instantiate(playerDieEffect, transform.position, Quaternion.identity);
            // ���ӿ��� ó��
            gameController.GameOver();
            // �÷��̾� ��Ȱ��ȭ
            gameObject.SetActive(false);
        }
    }

}
