using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorhandler : MonoBehaviour
{
    public int sceneToLoad = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
    }

    
}
