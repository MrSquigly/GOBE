using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject pauseUI;
    public GameObject gameUI;
    public GameObject upgradeUI;
    public GameObject optionsUI;

    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void startMenu()
    {
        SceneManager.LoadScene("Game");
    }

    public void upgradeMenu()
    {
        pauseUI.SetActive(false);
        upgradeUI.SetActive(true);
    }
    
    public void Options()
    {
        pauseUI.SetActive(false);
        optionsUI.SetActive(true);
    }

    public void Menu()
    {
        SceneManager.LoadScene("mainMenu");
    }

    public void Resume()
    {
        pauseUI.SetActive(false);
        upgradeUI.SetActive(false);
        optionsUI.SetActive(false);
        gameUI.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        pauseUI.SetActive(true);
        gameUI.SetActive(false);
        upgradeUI.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Quit()
    {
        Application.Quit();
    }

}
