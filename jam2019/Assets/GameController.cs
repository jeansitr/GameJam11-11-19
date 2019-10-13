﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public UIController UI;
    public HealthScript playerHealth;
    int score;
    public int EnemyOnDrought = 1;
    public int EnemyOnIce = 5;
    public int EnemyOnLava = 4;
    float currentScore;
    float currentLvl;
    public GameObject[] mobsListDrought = new GameObject[2];
    public GameObject[] mobsListIce = new GameObject[2];
    public GameObject[] mmobsListLavat = new GameObject[2];

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Update is called once per frame
    void Update()
    {
        UI.updateScore(score);
        UI.updateHealth(playerHealth.hp);
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        switch(scene.name)
        {
            case "Lab_spawn":
                {

                    break;
                }
            case "Drought":
                {
                    GameObject[] spawnLists = GameObject.FindGameObjectsWithTag("EnemySpawn");
                    List<GameObject> spawnChosen = new List<GameObject>();
                    for (int i = 0; i < EnemyOnDrought; i++)
                    {
                        GameObject spawn = spawnLists[Random.Range(0, spawnLists.Length)];
                        Debug.Log("Spawn chosen =" + Random.Range(0, spawnLists.Length));
                        if (!spawnChosen.Contains(spawn))
                        {
                            spawnChosen.Add(spawn);
                        }
                    }
                    foreach (GameObject spawnpoint in spawnChosen)
                    {
                        Instantiate(mobsListDrought[Random.Range(0,mobsListDrought.Length)], spawnpoint.transform, false);
                    }
                    break;
                }
            case "ice":
                {

                    break;
                }
            case "lava":
                {

                    break;
                }
        }
    }

    public void gainPoints(int scoreToAdd)
    {
        score += scoreToAdd;
    }
}
