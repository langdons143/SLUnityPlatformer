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
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        scoreText.text = "Final Score: " + finalScore;
    }

    public void Retry()
    {
        SceneManager.LoadScene(2);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(1);
    }
}