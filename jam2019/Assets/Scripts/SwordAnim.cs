using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAnim : MonoBehaviour
{
    public GameObject sword;
    public void SwordFinish()
    {
        sword.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void SwordStart()
    {
        sword.GetComponent<BoxCollider2D>().enabled = true;
    }
}
