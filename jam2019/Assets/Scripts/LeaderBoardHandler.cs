using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;
using SQLite4Unity3d;
using TMPro;

public class LeaderBoardHandler : MonoBehaviour
{
    public Transform scrollview;
    public GameObject scorePanel;
    public Text NameText;
    public Text ScoreText;
    public Button exitBtn;
    private GameController GC;
    public float joySens = 0.7f;
    private int activeLettre = 0;
    private int[] lettres = { 1, 1, 1, 1, 1};
    private char[] alphabet = {' ', 'A', 'a', 'B', 'b', 'C', 'c', 'D', 'd', 'E','e','F','f','G','g','H','h','I','i','J','j','K','k','L','l','M','m','N','n','O','o','P','p','Q','q','R','r','S','s','T','t','U','u','V','v','W','w','X','x','Y','y','Z','z' };
    float timer = 0;
    private void OnEnable()
    {
        ShowScore();
        GC = GameObject.FindObjectOfType<GameController>();
        ScoreText.text = GC.score.ToString();
    }

    private void Update()
    {
        if (NameText)
        {
            if (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.JoystickButton1))
            {
                activeLettre++;
                
                if (activeLettre == lettres.Length)
                {
                    SaveScore();
                    UnityEngine.SceneManagement.SceneManager.LoadScene(0);
                }
            }


            if (Input.GetKeyDown(KeyCode.JoystickButton2) || Input.GetKeyDown(KeyCode.JoystickButton3))
            {
                if (activeLettre != 0)
                {
                    activeLettre--;
                }
            }

            timer += Time.deltaTime;
            
            if (timer >= .05)
            {
                timer = 0;

                if (Input.GetAxis("Vertical") >= joySens)
                {
                    lettres[activeLettre]++;
                    if (lettres[activeLettre] > alphabet.Length - 1)
                    {
                        lettres[activeLettre] = 0;
                    }
                }

                if (Input.GetAxis("Vertical") <= -joySens)
                {
                    lettres[activeLettre]--;
                    if (lettres[activeLettre] < 0)
                    {
                        lettres[activeLettre] = alphabet.Length - 1;
                    }
                }

                ShowName();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.JoystickButton2) || Input.GetKeyDown(KeyCode.JoystickButton3))
            {
                exitBtn.onClick.Invoke();
            }
        }
    }

    public void ShowScore()
    {
        foreach (Transform child in scrollview)
        {
            Destroy(child.gameObject);
        }

        SQLiteConnection connection = new SQLiteConnection(Application.streamingAssetsPath + "/db.db", SQLiteOpenFlags.ReadWrite);
        var scores = connection.Query<Scores>("SELECT * FROM Scores ORDER BY score DESC");
        Scores[] scoresArr = scores.ToArray();

        foreach (Scores score in scoresArr)
        {
            GameObject scoreLine = Instantiate<GameObject>(scorePanel, scrollview);

            Transform nameLabel = scoreLine.transform.Find("nameTxt");
            Text nameLabelTextField = nameLabel.GetComponent<Text>();
            nameLabelTextField.text = score.name;

            Transform scoreLabel = scoreLine.transform.Find("scoreTxt");
            Text scoreLabelTextField = scoreLabel.GetComponent<Text>();
            scoreLabelTextField.text = score.score;
        }
    }

    public void ShowName()
    {
        string name = "";
        for(int i = 0; i < lettres.Length; i++)
        {
            name += alphabet[lettres[i]] + " ";
        }
        NameText.text = name;
    }

    private void SaveScore()
    {
        SQLiteConnection connection = new SQLiteConnection(Application.streamingAssetsPath + "/db.db", SQLiteOpenFlags.ReadWrite);
        connection.Insert(new Scores() { name = NameText.text.Replace(" ", ""), score = ScoreText.text });
    }
}
