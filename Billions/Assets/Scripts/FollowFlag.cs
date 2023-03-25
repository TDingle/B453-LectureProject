using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowFlag : MonoBehaviour
{

    
    GameObject closest = null;
  
    GameObject spawner;
    Rigidbody2D rigidb;
 
    float speed;
    int color;
    public GameObject[] GFlags;
    public GameObject[] YFlags;

    private void Start()
    { 
        spawner = GameObject.Find("Billionaire Spawner");
        rigidb = this.GetComponent<Rigidbody2D>();
        color = GetComponent<BillionHealth>().color;
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
        
        if (color == 0)
        {
            Flags = GFlags;
        }
        else if(color == 1)
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
