using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public UIController UI;
    public HealthScript playerHealth;
    public int score;
    public int EnemyOnDrought = 1;
    public int EnemyOnIce = 5;
    public int EnemyOnLava = 4;
    float currentScore;
    float currentLvl;
    public GameObject[] mobsListDrought = new GameObject[2];
    public GameObject[] mobsListIce = new GameObject[2];
    public GameObject[] mobsListLava = new GameObject[2];

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

        int playerHP = playerHealth.hp;
        UI.updateHealth(playerHP);
        if (playerHP <= 0)
        {
            SceneManager.LoadScene(0);
        }
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
                    Debug.Log("BUG ?");
                    GameObject[] spawnLists = GameObject.FindGameObjectsWithTag("EnemySpawn");
                    List<GameObject> spawnChosen = new List<GameObject>();
                    for (int i = 0; i < EnemyOnDrought; i++)
                    {
                        GameObject spawn = spawnLists[Random.Range(0, spawnLists.Length)];
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
                    GameObject[] spawnLists = GameObject.FindGameObjectsWithTag("EnemySpawn");
                    List<GameObject> spawnChosen = new List<GameObject>();
                    for (int i = 0; i < EnemyOnIce; i++)
                    {
                        GameObject spawn = spawnLists[Random.Range(0, spawnLists.Length)];
                        if (!spawnChosen.Contains(spawn))
                        {
                            spawnChosen.Add(spawn);
                        }
                    }
                    foreach (GameObject spawnpoint in spawnChosen)
                    {
                        Instantiate(mobsListIce[Random.Range(0, mobsListIce.Length)], spawnpoint.transform, false);
                    }
                    break;
                }
            case "lava":
                {
                    GameObject[] spawnLists = GameObject.FindGameObjectsWithTag("EnemySpawn");
                    List<GameObject> spawnChosen = new List<GameObject>();
                    for (int i = 0; i < EnemyOnLava; i++)
                    {
                        GameObject spawn = spawnLists[Random.Range(0, spawnLists.Length)];
                        if (!spawnChosen.Contains(spawn))
                        {
                            spawnChosen.Add(spawn);
                        }
                    }
                    foreach (GameObject spawnpoint in spawnChosen)
                    {
                        Instantiate(mobsListLava[Random.Range(0, mobsListLava.Length)], spawnpoint.transform, false);
                    }
                    break;
                }
        }
    }

    public void gainPoints(int scoreToAdd)
    {
        score += scoreToAdd;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
