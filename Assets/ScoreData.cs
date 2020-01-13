using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScoreData
{
    public float highScore;

    public ScoreData(float highScore)
    {
        this.highScore = highScore;
    }

    public float getHighScore()
    {
        return highScore;
    }
}
