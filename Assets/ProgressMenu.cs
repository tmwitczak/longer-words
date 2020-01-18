using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;


public class ProgressMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject progressMenuUI;
    private Button buttonSpeed;
    private Button buttonHealth;
    private double currentLevel = 0; 
    private double previousLevel = 0; 


    void Start()
    {
        buttonSpeed = GetComponent<Button>();
        buttonHealth = GetComponent<Button>();
    }
    // Update is called once per frame
    void Update()
    {
        


        if (Input.GetKeyDown(KeyCode.Tab))
            {
            GameplayManager gameplayManager = GameObject.FindGameObjectWithTag("GameplayManager").GetComponent<GameplayManager>();
      

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
    }

    void Pause()
    {
        progressMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;


        disableButton();    
        GameplayManager gameplayManager = GameObject.FindGameObjectWithTag("GameplayManager").GetComponent<GameplayManager>();
        currentLevel = System.Math.Floor(gameplayManager.getCorrectLettres() / 10);
        Debug.Log(currentLevel);
        Debug.Log(previousLevel);
        if (currentLevel > previousLevel)
        {
            enableButton();
            Debug.Log(currentLevel);
            Debug.Log(previousLevel);
            //previousLevel++;
        }
        //else disableButton();

        
    }

    public void SpeedIncrease()
    {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<Player>().addVelocity(10.0f);
            previousLevel++;
            currentLevel--;
        if (currentLevel <= previousLevel)
        {
            disableButton();
        }
        else enableButton();

        FindObjectOfType<AudioManager>().Play(null, "gui");
    }


    public void HealthIncrease()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Player>().setHealth(player.GetComponent<Player>().getHealth() + 10, player.GetComponent<Player>().getMaxHealth() + 10);
        previousLevel++;
        currentLevel--;
        if (currentLevel <= previousLevel)
        {
            disableButton();
        }
        else enableButton();

        FindObjectOfType<AudioManager>().Play(null, "gui");
    }

    public bool IsInteger(double d)
    {
        if (d == (int)d) return true;
        else return false;
    }
}
