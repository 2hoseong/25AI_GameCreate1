using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    bool isJumping = true;
    public float JumpPower = 10.0f;

    public GameObject text;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        if (Keyboard.current.spaceKey.wasPressedThisFrame && !isJumping)
        {
            Debug.Log("Player : มกวม(Space Bar Pressed");
            rb.linearVelocity = new Vector2(0.0f, JumpPower);
            isJumping = true;
        }
    }
}
