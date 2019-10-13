using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text scoreText;
    public Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateScore(int score)
    {
        scoreText.text = "Score: " + score;
    }

    public void updateHealth(int health)
    {
        healthText.text = "Health: " + health;
        Debug.Log("Updated health : " + health);
    }
}
