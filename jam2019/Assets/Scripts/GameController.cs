using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]

public class GameController : MonoBehaviour
{
    public UIController UI;
    public GameObject Portal;
    public int enemyToKill;
    public int killCount = 0;
    public HealthScript playerHealth;
    public int score;
    public int EnemyOnDrought = 1;
    public int EnemyOnIce = 5;
    public int EnemyOnLava = 4;
    public int pointsParVillageois = 0;
    float currentScore;
    float currentLvl;
    public GameObject[] mobsListDrought = new GameObject[2];
    public GameObject[] mobsListIce = new GameObject[2];
    public GameObject[] mobsListLava = new GameObject[2];
    float currentLevel = 0;
    int nextStage = 2;
    GameObject portalLocation;
    bool portalSpawned = false;
    int nbrFollower = 0;

    AudioSource audioMort;
    public AudioClip mort;
    AudioSource audioPoint;
    public AudioClip point;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        SceneManager.sceneLoaded += OnSceneLoaded;

        audioMort = GetComponent<AudioSource>();
        audioPoint = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth.hp > 0)
        {
            UI.updateScore(score);

            int playerHP = playerHealth.hp;
            Debug.Log("HP :" + playerHealth.hp);
            UI.updateHealth(playerHP);
            if (playerHP <= 0)
            {
                audioMort.PlayOneShot(mort, 0.7F);
                SceneManager.LoadScene(6);
            }

            if (killCount >= enemyToKill)
            {
                SpawnPortal();
            }
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
                    nbrFollower = 0;
                    portalSpawned = false;
                    currentLevel += 1;
                    playerHealth.transform.position = new Vector3(0, 5, 0);
                    nextStage = 3;
                    portalLocation = GameObject.FindGameObjectWithTag("Teleport");
                    killCount = 0;
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
                    nbrFollower = 0;
                    portalSpawned = false;
                    currentLevel += 1;
                    killCount = 0;
                    playerHealth.transform.position = new Vector3(0, 2, 0);
                    nextStage = 4;
                    portalLocation = GameObject.FindGameObjectWithTag("Teleport");
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
                    nbrFollower = 0;
                    portalSpawned = false;
                    currentLevel += 1;
                    playerHealth.transform.position = new Vector3(0, 0, 0);
                    killCount = 0;
                    nextStage = 2;
                    portalLocation = GameObject.FindGameObjectWithTag("Teleport");
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
            case "Lab_afterLevel":
                {
                    Debug.Log("FINI LE LVL AVEC " + nbrFollower + " FOLLOWERS");
                    score += (pointsParVillageois * nbrFollower);
                    killCount = 0;
                    playerHealth.transform.position = new Vector3(3, 2, 0);
                    Doorhandler door = FindObjectOfType<Doorhandler>();
                    door.sceneToLoad = nextStage;
                    break;
                }
        }
    }

    public void gainPoints(int scoreToAdd)
    {
        audioPoint = GetComponent<AudioSource>();
        score += scoreToAdd;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    public void SpawnPortal()
    {
        if (!portalSpawned)
        {
            GameObject portal = portalLocation.transform.GetChild(0).gameObject;
            portal.SetActive(true);
            portalSpawned = true;
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Lab_afterLevel");
    }

    public void AddFollower()
    {
        nbrFollower += 1;
    }
}
