using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    //Creates an Integer called score
    int score;

    //
    public int GetScore()
    {
        //This method returns the score so it can be used in other Scripts
        return score;
    }

    //Creates a new method wich holds a temporary Variable
    public void ModifyScore(int value)
    {
        //if this method comes to use
        score += value; //score = score + value
        Mathf.Clamp(score, 0, int.MaxValue);
        Debug.Log(score);
    }
    //this method sets the score back to 0
    public void ResetScore()
    {
        score = 0;
    }
}
