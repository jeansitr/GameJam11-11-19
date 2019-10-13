using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    public void QuitApplication()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        EditorSceneManager.LoadScene(1);
    }
}
