using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowFlag : MonoBehaviour
{
    GameObject closest = null;
  
    GameObject spawner;
    Rigidbody2D rigidb;
    float step;
    float speed;
    public GameObject[] GFlags;
    public GameObject[] YFlags;

    FlagPlacement FlagPlacement;
    private void Start()
    { 
        spawner = GameObject.Find("Billionaire Spawner");
        rigidb = this.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //if (FlagPlacement.flagCountG.Equals(2) && FlagPlacement.flagCountY.Equals(2))
        //{
            CalculateClosestFlag();
        //}
    }
    
    public void CalculateClosestFlag()
    {
        GameObject[] Flags = {};
        GFlags = GameObject.FindGameObjectsWithTag("FlagG");
        YFlags = GameObject.FindGameObjectsWithTag("FlagY");

        float lowestPos = -1;
        float flagDist;

        if (this.tag == "BillionG")
        {
            Flags = GFlags;
        }
        else if(this.tag == "BillionY")
        {
            Flags = YFlags;
        }
     
        foreach (GameObject flag in Flags)
        {
            flagDist = Vector2.Distance(transform.position, flag.transform.position);
            
            if (flagDist < lowestPos || lowestPos == -1)
            {
                lowestPos = flagDist;
                closest = flag;
                

            }
        }
        speed = 5f;
        //transform.position = Vector2.MoveTowards(transform.position, closest.transform.position, step);
        rigidb.AddForce((closest.transform.position - transform.position).normalized * speed);
        
       
    }
}
