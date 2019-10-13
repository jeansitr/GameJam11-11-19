using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class ScoreScript : MonoBehaviour
{
    //Sounds
    AudioSource audioPoint;
    public AudioClip point;

    /// <summary>
    /// Total hitpoints
    /// </summary>
    public int score = 0;

    //Show Health in UI
    public Text countScore;

    public void Start()
    {
        audioPoint = GetComponent<AudioSource>();
        SetCountScore();
    }

    public void SetCountScore()
    {
        countScore.text = "Score: " + score.ToString();
        audioPoint.PlayOneShot(point, 0.7F);
    }
}
