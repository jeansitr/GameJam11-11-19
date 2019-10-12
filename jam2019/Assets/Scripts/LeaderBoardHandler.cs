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
    public Button exitBtn;

    private void OnEnable()
    {
        ShowScore();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            exitBtn.onClick.Invoke();
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
}
