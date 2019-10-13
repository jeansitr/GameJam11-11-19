using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

[RequireComponent(typeof(AudioSource))]

public class Doorhandler : MonoBehaviour
{
    AudioSource audioPrendrePortail;
    public AudioClip prendrePortail;

    // Start is called before the first frame update
    void Start()
    {
        audioPrendrePortail = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        audioPrendrePortail.PlayOneShot(prendrePortail, 0.7F);
        EditorSceneManager.LoadScene(1);
    }
}
