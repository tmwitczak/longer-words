using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject uiTextPrefab;
    public string command;
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    Text text;
    private Text waveText;
    
    float highScore = 0;

        // Update is called once per frame
        void Update()
    {


        if (ProgressMenu.GameIsPaused == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameIsPaused)
                {
                    Resume();
                    //text.text = "";
                }
                else
                {
                    GameplayManager gameplayManager = GameObject.FindGameObjectWithTag("GameplayManager").GetComponent<GameplayManager>();
                    Pause();
                    if (SaveSystem.LoadScore() == null)
                    {
                        SaveSystem.SaveScore(0);
                    }

                    float score = gameplayManager.getCorrectLettres();

                    if (SaveSystem.LoadScore().getHighScore() < score)
                    {
                        SaveSystem.SaveScore(score);
                    }

                    //text = FindObjectOfType<Text>().GetComponent<Text>();
                    //text.text = "Correct letters: " + gameplayManager.getCorrectLettres();
                    //text.transform.position = new Vector3(1920 / 2 + 50, 50, 0);
                    //text.fontSize = 40;
                    //text.fontStyle = FontStyle.Bold;

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
