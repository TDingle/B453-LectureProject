using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xpManager : MonoBehaviour
{
    public int greenXP = 0;
    public int yellowXP = 0;
    public int blueXP = 0;
    public int orangeXP = 0;

    public int greenRank;
    public int yellowRank;
    public int blueRank;
    public int orangeRank;

    public int greenTril = 0;
    public int yellowTril = 0;
    public int blueTril = 0;
    public int orangeTril = 0;
    GameObject[] Bases;
    void Start()
    {
      
        Bases = GameObject.FindGameObjectsWithTag("Bases");
        List<GameObject> bases = new List<GameObject>(Bases);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int GetTotalRank()
    {
        return greenRank + yellowRank + blueRank + orangeRank;
    }
}
