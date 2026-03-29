using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;

    void Start()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.onScoreChanged += UpdateScore;
            GameManager.Instance.onHealthChanged += UpdateHealth;
            GameManager.Instance.onGameOver += HandleGameOver;

            UpdateScore(GameManager.Instance.score);
            UpdateHealth(GameManager.Instance.health);
        }
        else
        {
            Debug.LogError("UIManager: GameManager.Instance is null");
        }
    }

    void OnDestroy()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.onScoreChanged -= UpdateScore;
            GameManager.Instance.onHealthChanged -= UpdateHealth;
            GameManager.Instance.onGameOver -= HandleGameOver;
        }
    }

    void UpdateScore(int newScore)
    {
        Debug.Log("UIManager: Score changed to " + newScore);
        scoreText.text = "Score: " + newScore;
    }

    void UpdateHealth(int newHealth)
    {
        Debug.Log("UIManager: Health changed to " + newHealth);
        healthText.text = "Health: " + newHealth;
    }

    void HandleGameOver()
    {
        Debug.Log("UIManager: Game over event fired");
        SceneManager.LoadScene("GameOver");
    }
}