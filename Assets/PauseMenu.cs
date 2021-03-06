using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public string command;
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) )
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
        foreach (char c in Input.inputString)
        {
            if (c == '\b' && command.Length != 0)
            {
                command = command.Substring(0, command.Length - 1);
            }
            else if ((c == '\n') || (c == '\r'))
            {
                if (command == "resume")
                {
                    Resume();
                }
                else if (command == "menu")
                {
                    loadMenu();
                }
                else if (command == "quit")
                {
                    QuitGame();
                }
                command = "";
            }
            else
            {
                command += c;
              
            }
        }
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    if (GameIsPaused)
        //    {
        //        Resume();

        //    }
        //}
        //if (Input.GetKeyDown(KeyCode.M))
        //{
        //    if (GameIsPaused)
        //    {
        //        loadMenu();

        //    }
        //}

        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    if (GameIsPaused)
        //    {
        //        QuitGame();

        //    }
        //}
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void loadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();

    }

}
