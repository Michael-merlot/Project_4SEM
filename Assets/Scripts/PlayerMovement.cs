using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private bool isGrounded; // �������� ���������� �� �����

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        // ������� ��� ������ ������ ���� �������� �� �����
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        // �������� �� ������� ��� ������
        if (Mathf.Abs(rb.velocity.y) > .1f)
        {
            anim.SetBool("isJumping", true);
            anim.SetBool("isFalling", rb.velocity.y < 0); // ���� �������� Y ������ 0, ������, �������� ������
        }
        else
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
        }

        // �������� ���� � ����������� ���������
        if (dirX != 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = dirX < 0f;
        }
        else
        {
            anim.SetBool("running", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // ���������, ��� � ����� ���������� ��� "Ground"
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }

    }
}