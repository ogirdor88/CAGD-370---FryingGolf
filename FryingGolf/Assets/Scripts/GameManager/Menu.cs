using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Author(s): Jackson, Katherine
//Updated: 04/03/24
//This script executes all code relevant to switching scenes, pausing, quiting the game, etc..

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public void ExitButton()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    //The following is for the Pause Menu UI

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Home(int sceneID)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
    }
}
