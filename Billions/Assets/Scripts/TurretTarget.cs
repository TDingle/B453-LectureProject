using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TurretTarget : MonoBehaviour
{
    GameObject closest = null;
    GameObject[] currentBils;
    GameObject[] GBils;
    GameObject[] YBils;
    GameObject[] BBils;
    GameObject[] OBils;

    GameObject[] YGBils;
    GameObject[] BOBils;

    string parentTag;


    void Update()
    {
        if (transform.parent != null)
        {

            CalculateClosestBillion();
        }
    }
    public void CalculateClosestBillion()
    {
        float lowestPos = -1;
        float billionDist;


        GameObject[] EnemyBillions = { };
        parentTag = transform.parent.tag;
        YBils = GameObject.FindGameObjectsWithTag("BillionY");
        GBils = GameObject.FindGameObjectsWithTag("BillionG");
        BBils = GameObject.FindGameObjectsWithTag("BillionB");
        OBils = GameObject.FindGameObjectsWithTag("BillionO");

        YGBils = YBils.Concat(GBils).ToArray();
        BOBils = BBils.Concat(OBils).ToArray();

        currentBils = YGBils.Concat(BOBils).ToArray();
        EnemyBillions = currentBils.Where(e => !e.CompareTag(parentTag)).ToArray();


       

        foreach (GameObject billion in EnemyBillions)
        {
            billionDist = Vector2.Distance(transform.position, billion.transform.position);
            
            if (billionDist < lowestPos || lowestPos == -1)
            {
                lowestPos = billionDist;
                closest = billion;
               
                
            }
        }
       
        
        Vector3 dir = closest.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }
}