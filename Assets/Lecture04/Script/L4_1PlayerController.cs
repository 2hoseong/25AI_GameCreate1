using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class L4_1PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    bool isJumping = true;

    public float moveSpeed = 5.0f;   // ← 추가: 이동 속도
    public float JumpPower = 10.0f;

    public GameObject text;

    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        isJumping = true;
        Debug.Log("Player : isJumping = true");
        text.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
            Debug.Log("Player : isJumping = false");
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player : Game Over!");
            if (text != null)
                text.SetActive(true);
        }
    }

    void Update()
    {
        // 좌우 이동
        float move = 0f;
        if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed)
        {
            move = -1f;
        }
        else if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed)
        {
            move = 1f;
        }

        // 기존 속도는 유지하고, x축만 갱신
        rb.linearVelocity = new Vector2(move * moveSpeed, rb.linearVelocity.y);

        // 점프
        if (Keyboard.current.spaceKey.wasPressedThisFrame && !isJumping)
        {
            Debug.Log("Player : 점프(Space Bar Pressed)");
            animator.Play("PlayerJump", -1, 0f);
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, JumpPower);
            isJumping = true;
        }
    }
}
