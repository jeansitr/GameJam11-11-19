using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class ScoreScript : MonoBehaviour
{
    /// <summary>
    /// Total hitpoints
    /// </summary>
    public int score = 0;

    //Show Health in UI
    public Text countScore;

    public void Start()
    {
        SetCountScore();
    }

    public void SetCountScore()
    {
        countScore.text = "Score: " + score.ToString();
    }
}
