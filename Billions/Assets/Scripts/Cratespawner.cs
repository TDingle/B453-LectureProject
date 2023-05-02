using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cratespawner : MonoBehaviour
{
    [SerializeField] GameObject crate;
    int reqRank = 3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<xpManager>().GetTotalRank() == reqRank)
        {
            Vector2 position = new Vector2(Random.Range(-7.0F, 7.0F), Random.Range(-4.0F, 4.0F));
            Instantiate(crate, position, Quaternion.identity);
            reqRank += 2;
        }
    }

    //TODO: crate types, will need to have a random pick for which will be instantiated
}
