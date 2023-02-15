using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FlagPlacement : MonoBehaviour
{
    [SerializeField] List<GameObject> Flags = new List<GameObject>();
    
    float flagCountG = 0;
    float flagCountY = 0;
    float flagMax = 2;
    // Update is called once per frame
    void Update()
    {
        placeFlag();
        if (Input.GetButton("Fire1"))
        {
            moveFlag();
        }


        //if (Input.GetButton("Fire1"))
        //{
        //    DateTime clickTime = DateTime.Now;
        //    Vector2 mousePos = Input.mousePosition;

        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        //    if (hit != null && hit.collider != null)
        //    {

                
        //    }

        //}

    }
    //places the first two flags for each base, stops at flagMax
    void placeFlag()
    {
        if (Input.GetKeyDown("1") && flagCountG < flagMax)
        {
            Vector2 mousePos = Input.mousePosition;
            Vector2 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
            Instantiate(Flags[0], objectPos, Quaternion.identity, transform);
            flagCountG++;

        }
        else if (Input.GetKeyDown("2") && flagCountY < flagMax)
        {
            Vector2 mousePos = Input.mousePosition;
            Vector2 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
            Instantiate(Flags[1], objectPos, Quaternion.identity, transform);
            flagCountY++;
        }
    }
    //Get closest flag position move that flag to current mouse position
    void moveFlag()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
        GameObject closest = null;
        float lowestPos = -1;
        foreach(Transform child in transform)
        {
            float flagDist = Vector2.Distance(child.transform.position, objectPos);
            if (flagDist < lowestPos || lowestPos == -1)
            {
                lowestPos = flagDist;
                closest = child.gameObject;
                

            }
        }
        
        closest.transform.position = objectPos;
    }
}
