using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;


public class ProgressMenu : MonoBehaviour
{
    [SerializeField] private GameObject uiTextPrefab;
    public static bool GameIsPaused = false;
    public GameObject progressMenuUI;
    private Button buttonSpeed;
    private Button buttonHealth;
    private double currentLevel = 0; 
    private double previousLevel = 0; 
    private double level = 0; 
    private double pointsUsed = 0;
    private double pointsToUse = 0;
    private Text text;
    public string command;




    void Awake()
    {
        buttonSpeed = GetComponent<Button>();
        buttonHealth = GetComponent<Button>();

    }

    public double getPoints()
    {
        return pointsToUse;
    }

        // Update is called once per frame
        void Update()
    {

        GameplayManager gameplayManager = GameObject.FindGameObjectWithTag("GameplayManager").GetComponent<GameplayManager>();
        currentLevel = System.Math.Floor(gameplayManager.getCorrectLettres() / 100);
        pointsToUse = System.Math.Floor(gameplayManager.getCorrectLettres() / 100) - pointsUsed;


        if (currentLevel > level)
        {
            if (PauseMenu.GameIsPaused == false)
            {
                if (Input.GetKeyDown(KeyCode.Tab))
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
                 
                        if (command == "speed")
                        {
                            
                            SpeedIncrease();
                        }
                        else if (command == "health")
                        {
                            HealthIncrease();
                        }
                        command = "";
                    }
                    else
                    {
                        command += c;
                    }
                }
            }
        }

    }
    public void disableButton()
    {
        buttonSpeed = GameObject.Find("Speed++").GetComponent<Button>();
        buttonHealth = GameObject.Find("Health++").GetComponent<Button>();
        buttonSpeed.interactable = false;
        buttonHealth.interactable = false;

    }
    public void enableButton()
    {
        buttonSpeed = GameObject.Find("Speed++").GetComponent<Button>();
        buttonHealth = GameObject.Find("Health++").GetComponent<Button>();
        buttonSpeed.interactable = true;
        buttonHealth.interactable = true;
    }
    public void Resume()
    {
        progressMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        currentLevel = 0;
        level++;
    }

    void Pause()
    {
        progressMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;


        disableButton();    
        GameplayManager gameplayManager = GameObject.FindGameObjectWithTag("GameplayManager").GetComponent<GameplayManager>();
        currentLevel = System.Math.Floor(gameplayManager.getCorrectLettres() / 100);
        pointsToUse = System.Math.Floor(gameplayManager.getCorrectLettres() / 100) - pointsUsed;
        //Debug.Log(currentLevel);
        //Debug.Log(previousLevel);
        if (pointsToUse >= 0)
        {
            enableButton();
            Debug.Log(currentLevel);
            Debug.Log(previousLevel);
            Debug.Log("pointsToUse = " + pointsToUse);

        }
        //else disableButton();

        
    }

    public void SpeedIncrease()
    {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<Player>().addVelocity(10.0f);
            previousLevel++;
            currentLevel--;
            pointsUsed++;
            pointsToUse--;
            if (pointsToUse <= 0)
            {
                disableButton();
            }
            else enableButton();
    }


    public void HealthIncrease()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Player>().setHealth(player.GetComponent<Player>().getHealth() + 10, player.GetComponent<Player>().getMaxHealth() + 10);
        previousLevel++;
        currentLevel--;
        pointsUsed++;
        pointsToUse--;
        if (pointsToUse <= 0)
        {
            disableButton();
        }
        else enableButton();
    }

    public bool IsInteger(double d)
    {
        if (d == (int)d) return true;
        else return false;
    }
}
