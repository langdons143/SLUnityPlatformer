using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 12f;

    private Rigidbody2D rb;
    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Debug.Log("PlayerController is running");

    }

    void Update()
    {
        // Horizontal movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            AudioManager.Instance.PlaySoundEffect(AudioManager.Instance.jumpSound);
        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameManager.Instance.TakeDamage(10);

            if (GameManager.Instance.health <= 0)
            {
                GameManager.Instance.TriggerGameOver();
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        //Debug.Log("Triggered with: " + other.name + " Tag: " + other.tag);

        if (other.CompareTag("Coin"))
        {
            //Debug.Log("Coin collected");
            GameManager.Instance.AddScore(10);
            CoinPoolManager.Instance.ReturnCoin(other.gameObject);
        }
    }

}