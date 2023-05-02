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
    GameObject spawner;
    int numberOfSpecialBils;
    

    void Update()
    {
        spawner = GameObject.Find("Billionaire Spawner");
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
        int color = this.GetComponent<Bases>().color;
        if (color == 0)//green
        {
            numberOfSpecialBils = spawner.gameObject.GetComponent<xpManager>().greenTril; 

        }
        else if (color == 1)//yellow
        {
            numberOfSpecialBils = spawner.gameObject.GetComponent<xpManager>().yellowTril;

        }
        else if (color == 2)//orange
        {
            numberOfSpecialBils = spawner.gameObject.GetComponent<xpManager>().orangeTril;

        }
        else if (color == 3)//blue
        {
            numberOfSpecialBils = spawner.gameObject.GetComponent<xpManager>().blueTril;

        }




        Vector3 randPosition = Random.insideUnitCircle;
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0 && billions < billionAmount)
        {
            if (numberOfSpecialBils == 0)
            {
                bilRank = this.GetComponent<Bases>().Riter;
                Instantiate(billion, transform.position + randPosition, Quaternion.identity);
            
                spawnTimer = 2f;
                billions += 1;

            }
            else if(numberOfSpecialBils > 0)
            {
                bilRank = 9;
                Instantiate(billion, transform.position + randPosition, Quaternion.identity);

                numberOfSpecialBils -= 1;

                spawnTimer = 2f;
                billions += 1;
            }
        }
    }
   
    
}
