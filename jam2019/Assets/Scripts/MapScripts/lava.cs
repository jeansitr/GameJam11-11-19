using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lava : MonoBehaviour
{
    public Transform[] possibleSpawn = new Transform[11];
    public GameObject civil;

    // Start is called before the first frame update
    void Start()
    {

        System.Random rdn = new System.Random();
        List<int> selected = new List<int>();
        for (int i = 0; i < 3; i++)
        {
            int e;
            do
            {
                e = rdn.Next(0, 11);
            }
            while (selected.Contains(e));

            selected.Add(e);

            GameObject civilInstance = Instantiate(civil, transform);
            Transform pos = possibleSpawn[e];
            civilInstance.transform.position = new Vector3(pos.position.x, pos.position.y - (civilInstance.transform.Find("Feet").position.y - civilInstance.transform.position.y), 0);
        }
    }
}
