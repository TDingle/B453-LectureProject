using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
using static UnityEngine.GraphicsBuffer;

public class FlagPlacement : MonoBehaviour
{
    [SerializeField] List<GameObject> Flags = new List<GameObject>();
    
    public float flagCountG = 0;
    public float flagCountY = 0;
    float flagMax = 2;
    GameObject closest = null;
    float mouseCheck;

    // Update is called once per frame
    void Update()
    {
        placeFlag();
    if (flagCountG == flagMax || flagCountY == flagMax)
        {
        moveFlag();
        }
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
        

        if (Input.GetButtonDown("Fire1"))
        {
            CalculateClosestFlag();
        }

        if (Input.GetButton("Fire1") && mouseCheck < .2)
        {
            Debug.DrawLine(closest.transform.position, objectPos, Color.red);
        }
           
        if (Input.GetButtonUp("Fire1"))
        {
            closest.transform.position = objectPos;
        }
  
    }

    public GameObject CalculateClosestFlag()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
        float lowestPos = -1;

        closest = null;
        foreach (Transform child in transform)
        {
            float flagDist = Vector2.Distance(child.transform.position, objectPos);

            if (flagDist < lowestPos || lowestPos == -1)
            {
                lowestPos = flagDist;
                closest = child.gameObject;

            }
        }
        mouseCheck = Vector2.Distance(closest.transform.position, objectPos);
        return closest;

    }

}
