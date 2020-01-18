using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    void Awake() {
        FindObjectOfType<AudioManager>().Play(null, "gui");
    }

    public void setQuality (int qualityIndex)
    {
        FindObjectOfType<AudioManager>().Play(null, "gui");

        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void setFullScreen (bool isFullScreen)
    {
        FindObjectOfType<AudioManager>().Play(null, "gui");

        Screen.fullScreen = isFullScreen; 
    }
}
