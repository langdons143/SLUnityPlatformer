using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 12f;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;

    private Rigidbody2D rb;
    private bool isGrounded = false;
    private int health = 100;
    private int score = 0;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UpdateUI();
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
            health -= 10;
            UpdateUI();

            if (health <= 0)
            {
                GameOver();
            }
        }
    }

    public void GameOver()
    {
        // Save score before loading GameOver scene
        PlayerPrefs.SetInt("FinalScore", score);
        PlayerPrefs.Save(); // Force write to disk

        SceneManager.LoadScene(3);
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
        if (other.CompareTag("Coin"))
        {
            score += 10;
            Destroy(other.gameObject);
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        healthText.text = "Health: " + health;
        scoreText.text = "Score: " + score;
    }

}