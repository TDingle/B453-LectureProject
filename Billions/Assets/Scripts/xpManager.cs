using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xpManager : MonoBehaviour
{
    public int greenXP = 0;
    public int yellowXP = 0;
    public int blueXP = 0;
    public int orangeXP = 0;
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
}
