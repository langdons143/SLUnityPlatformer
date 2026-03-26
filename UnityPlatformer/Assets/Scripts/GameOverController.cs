using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText.text = "Final Score: " + GameManager.Instance.score;
    }

    public void Retry()
    {
        GameManager.Instance.ResetGame();
        SceneManager.LoadScene(2);
    }

    public void ReturnToMenu()
    {
        GameManager.Instance.ResetGame();
        SceneManager.LoadScene(1);
    }
}