using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    Text text;

    private void Start()
    {
        text = GetComponent<Text>();
        text.text = "HighScore = " + SaveSystem.LoadScore().getHighScore();// SaveSystem.LoadScore().getHighScore();
        text.color = new Color(0.97f, 0.95f, 0.91f);
    }



}
