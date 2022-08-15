using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    private int score=0;
    
    public int GetScore()
    {
        return score;
    }
    public void  ModifyScore(int value)
    {
        score += value;
        Mathf.Clamp(score, 0, int.MaxValue);
        Debug.Log(score);
    }
    public void ResetScore()
    {
        score = 0;
    }   
}
