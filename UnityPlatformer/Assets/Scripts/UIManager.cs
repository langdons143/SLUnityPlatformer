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

    void OnEnable()
    {
        GameManager.Instance.onScoreChanged += UpdateScore;
        GameManager.Instance.onHealthChanged += UpdateHealth;
        GameManager.Instance.onGameOver += HandleGameOver;
    }

    void OnDisable()
    {
        GameManager.Instance.onScoreChanged -= UpdateScore;
        GameManager.Instance.onHealthChanged -= UpdateHealth;
        GameManager.Instance.onGameOver -= HandleGameOver;
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