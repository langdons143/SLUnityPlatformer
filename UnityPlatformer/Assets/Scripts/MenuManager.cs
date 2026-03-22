using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public void LoadGameScene()
    {
        // Loads scene at index 1 in Build Settings
        SceneManager.LoadScene(2);
    }

}
