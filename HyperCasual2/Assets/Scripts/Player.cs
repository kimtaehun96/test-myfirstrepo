using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5; // �̵� �ӵ�
    [SerializeField]
    private float jumpForce = 15; // ���� ��

    private Rigidbody2D rb2D; // �ӷ� ��� ���� Rigidbody2D

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = new Vector2(moveSpeed, jumpForce);

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
        }
    }

}
