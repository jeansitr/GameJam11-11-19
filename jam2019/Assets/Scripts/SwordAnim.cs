using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class SwordAnim : MonoBehaviour
{
    public GameObject sword;
    AudioSource audioCoupEpee;
    public AudioClip impact;

    void Start()
    {
        audioCoupEpee = GetComponent<AudioSource>();
    }

    public void SwordFinish()
    {
        sword.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void SwordStart()
    {
        sword.GetComponent<BoxCollider2D>().enabled = true;
        audioCoupEpee.PlayOneShot(impact, 0.7F);
    }
}
