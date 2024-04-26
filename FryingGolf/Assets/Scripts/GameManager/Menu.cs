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
    [SerializeField] GameObject pauseInfo;
    [SerializeField] GameObject deathMenu;
    private bool _isDead;

    private void Awake()
    {
        Time.timeScale = 1f;
        _isDead = false;
    }

    private void Update()
    {
        _isDead = deathMenu.activeSelf;

        if (_isDead != true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
        }
        else
        {
            pauseMenu.SetActive(false);
            pauseInfo.SetActive(false);
        }

    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void HowToPlay(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    //Pause/Death Menu UI
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    //Pause Menu UI
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    //Pause/Death Menu UI
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    //Pause/Death Menu UI
    public void Home(int sceneID)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
    }
}
