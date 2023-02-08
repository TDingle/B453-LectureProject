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
            Vector2 position = new Vector2(Random.Range(-7.0F, 7.0F), Random.Range(-4.0F, 4.0F));
            Instantiate(Billionaires[i], position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
