using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBillions : MonoBehaviour
{
    [SerializeField] float spawnTimer = 2f;
    float billionAmount = 60f;
    [SerializeField] GameObject billion;
    float billions = 0f;
    public int bilRank;
    

    void Update()
    {
        //var bilAmt = GameObject.FindGameObjectsWithTag("Billion");
        //if (bilAmt.Length < billionAmount)
        //{
            //Debug.Log(bilAmt.Length);
        //}
        CreateBillon();
    }
    void CreateBillon()
    {
        //makes a rando position around the Billionaire
        Vector3 randPosition = Random.insideUnitCircle;
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0 && billions < billionAmount)
        {
            bilRank = this.GetComponent<Bases>().Riter;
            Instantiate(billion, transform.position + randPosition, Quaternion.identity);
            
            spawnTimer = 2f;
            billions += 1;
        }
    }
   
    
}
