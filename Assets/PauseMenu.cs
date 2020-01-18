using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public string command;
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;


    float highScore = 0;


    //Debug.Log(gameplayManager.GetComponent<GameplayManager>().getCorrectLettres()); 


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
                GameplayManager gameplayManager = GameObject.FindGameObjectWithTag("GameplayManager").GetComponent<GameplayManager>();
                Pause();
                if(SaveSystem.LoadScore() == null)
                {
                    SaveSystem.SaveScore(0);
                }

                float score = gameplayManager.getCorrectLettres();

                if (SaveSystem.LoadScore().getHighScore() < score)
                {
                    SaveSystem.SaveScore(score);
                }
               
                Debug.Log("High Score = " + SaveSystem.LoadScore().getHighScore());
       
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
        FindObjectOfType<AudioManager>().Play(null, "gui");

        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        FindObjectOfType<AudioManager>().Play(null, "gui");

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void loadMenu()
    {
        FindObjectOfType<AudioManager>().Play(null, "gui");

        Time.timeScale = 1f;

        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().Play(null, "gui");

        Debug.Log("Quit!");
        Application.Quit();

    }

}
