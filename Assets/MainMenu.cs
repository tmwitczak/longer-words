using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public void PlayGame()
    {
        FindObjectOfType<AudioManager>().Play(null, "gui");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().Play(null, "gui");

        Debug.Log("Quit");
        Application.Quit();
    }
}
