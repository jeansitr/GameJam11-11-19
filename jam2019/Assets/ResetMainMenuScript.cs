using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetMainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject camera = GameObject.FindGameObjectWithTag("Camera");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject hud = GameObject.FindGameObjectWithTag("HUD");
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");

        if (camera != null)
        {
            Destroy(camera);
        }
        if (player != null)
        {
            Destroy(player);
        }
        if (hud != null)
        {
            Destroy(hud);
        }
        if (gameController != null)
        {
            Destroy(gameController);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
