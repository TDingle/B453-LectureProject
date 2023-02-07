using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlacement : MonoBehaviour
{
    [SerializeField] List<GameObject> Billionaires = new List<GameObject>();
    
    void Start()
    {
        
        for (int i = 0; i < Billionaires.Count; i++)
        {
            Vector3 position = new Vector3(Random.Range(-10.0F, 10.0F), 1, Random.Range(-10.0F, 10.0F));
            Instantiate(Billionaires[i], position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
