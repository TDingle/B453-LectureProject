using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    public int type;
   
    // Start is called before the first frame update
    void Start()
    {
       type = Random.Range(1, 3);
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
