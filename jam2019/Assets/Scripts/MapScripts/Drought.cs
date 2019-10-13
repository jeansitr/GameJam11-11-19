using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drought : MonoBehaviour
{
    public Vector3[] possibleSpawn = new Vector3[18];
    public GameObject civil;

    // Start is called before the first frame update
    void Start()
    {
        System.Random rdn = new System.Random();
        List<int> selected = new List<int>();
        for(int i = 0; i < 3; i++)
        {
            int e;
            do
            {
                e = rdn.Next(0, 16);
            }
            while (selected.Contains(e));

            selected.Add(e);

            GameObject civilInstance = Instantiate(civil, transform);
            civilInstance.transform.localPosition = possibleSpawn[e];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
 