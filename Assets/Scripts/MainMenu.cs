using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }

    public void Instructions()
    {
        SceneManager.LoadScene("Instructions Menu");
    }

    public void GoBack()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
