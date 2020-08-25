using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } 
            else
            {
                Pause();
            }
        }
    }

    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    
    void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Resume();

        gamestate.Instance.setActiveLevel("Main Menu");
        Application.LoadLevel("Main Menu");
    }

    public void LoadShip()
    {
        Resume();
        
        gamestate.Instance.setActiveLevel("Space Ship");
        Application.LoadLevel("Space Ship");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}