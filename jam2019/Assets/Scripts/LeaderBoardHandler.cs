using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Assets.Scripts;
using TMPro;

public class LeaderBoardHandler : MonoBehaviour
{
    public Transform scrollview;
    public GameObject scorePanel;
    public Text NameText;
    public Button exitBtn;
    private GameController GC;
    public float joySens = 0.7f;
    private int activeLettre = 1;
    private int[] lettres = { 1, 1, 1 };
    private char[] alphabet = {' ', 'A', 'a', 'B', 'b', 'C', 'c', 'D', 'd', 'E','e','F','f','G','g','H','h','I','i','J','j','K','k','L','l','M','m','N','n','O','o','P','p','Q','q','R','r','S','s','T','t','U','u','V','v','W','w','X','x','Y','y','Z','z' };
    float timer = 0;
    private void OnEnable()
    {
        ShowScore();
        GC = GameObject.FindObjectOfType<GameController>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= .05)
        {
            timer = 0;
            if (NameText)
            {
                if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Joystick1Button1))
                {
                    if (activeLettre == lettres.Length)
                    {
                        SaveScore();
                        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
                    }

                    activeLettre++;
                }

                if (Input.GetKeyDown(KeyCode.Joystick1Button2) || Input.GetKeyDown(KeyCode.Joystick1Button3))
                {
                    if (activeLettre != 1)
                    {
                        activeLettre--;
                    }
                }

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
            else
            {
                if (Input.GetKeyDown(KeyCode.JoystickButton2) || Input.GetKeyDown(KeyCode.JoystickButton3))
                {
                    exitBtn.onClick.Invoke();
                }
            }
        }
        
    }

    public void ShowScore()
    {
        foreach (Transform child in scrollview)
        {
            Destroy(child.gameObject);
        }

        StreamReader scoreFile = new StreamReader(Application.streamingAssetsPath + "/score.list");
        List<ScoreLine> lines = new List<ScoreLine>();
        string line;

        while ((line = scoreFile.ReadLine()) != null)
        {
            if (!string.IsNullOrEmpty(line))
            {
                string[] lineSplit = line.Split(';');
                if(double.TryParse(lineSplit[1], out double score))
                    lines.Add(new ScoreLine(lineSplit[0], score));
            }
        }

        lines.Sort((x, y) => y.Score.CompareTo(x.Score));

        lines.ForEach((ScoreLine s) => {
            GameObject scoreLine = Instantiate<GameObject>(scorePanel, scrollview);
            Transform nameLabel = scoreLine.transform.Find("nameTxt");
            Text nameLabelTextField = nameLabel.GetComponent<Text>();
            nameLabelTextField.text = s.Name;

            Transform scoreLabel = scoreLine.transform.Find("scoreTxt");
            Text scoreLabelTextField = scoreLabel.GetComponent<Text>();
            scoreLabelTextField.text = s.Score.ToString();
        });

        scoreFile.Close();
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

    public void SaveScore()
    {

    }
}
