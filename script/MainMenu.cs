using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("infinityRunner");
    }

    public void HighScores()
    {
        SceneManager.LoadScene("HighScores");
    }
}
