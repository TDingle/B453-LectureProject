using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using System.Xml.Serialization;

public class TurretTarget : MonoBehaviour
{
    public GameObject closest = null;

    GameObject[] Bils;
    GameObject[] Bases;
    List<GameObject> enemyBils;
  
    string parentTag;
    int color;
    float enemyDist;
    float bulletSpeed = 500f;
    float baseTurretDelay = .5f;

    [SerializeField] float spawnTimer = 1.5f;
    [SerializeField] GameObject bullet;

    Rigidbody2D rigidb;
   
    private void Start()
    {
        parentTag = transform.parent.tag;
        if(parentTag == "Billion")
        {
            color = GetComponentInParent<BillionHealth>().color;
        }
        else
        {
            color = GetComponentInParent<Bases>().color;
        }
    }
    void Update()
    {
        
        if (transform.parent != null)
        {

            CalculateClosestBillion();

            enemyDist = Vector2.Distance(transform.position, closest.transform.position);
            if (enemyDist < 4)
            {
            shoot();
            }
        }
    }
    public void CalculateClosestBillion()
    {
        float lowestPos = -1;
        float billionDist;


        enemyBils = new List<GameObject>();
        parentTag = transform.parent.tag;
        Bils = GameObject.FindGameObjectsWithTag("Billion");
        Bases = GameObject.FindGameObjectsWithTag("Bases");
        foreach (GameObject bil in Bils)
        {
         
            if (bil.GetComponent<BillionHealth>().color != color)
            {
                enemyBils.Add(bil);
               
            }
        }
        if (parentTag != "Bases")
        {
            foreach (GameObject bas in Bases)
            {

                if (bas.GetComponent<Bases>().color != color)
                {
                    enemyBils.Add(bas);

                }
            }
        }

        foreach (GameObject billion in enemyBils)
        {
            billionDist = Vector2.Distance(transform.position, billion.transform.position);
            
            if (billionDist < lowestPos || lowestPos == -1)
            {
                lowestPos = billionDist;
                closest = billion;
               
                
            }
        }
        if (closest != null)
        {
            if (parentTag == "Billion")
            {
                Vector3 dir = closest.transform.position - transform.position;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
            else
            {
                Vector3 dir = closest.transform.position - transform.position;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                //baseTurretDelay -= Time.deltaTime;
                //if (baseTurretDelay <= 0)
                //{
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), baseTurretDelay * Time.deltaTime);
                //baseTurretDelay = .5f;
                //}
            }
        }

    }
    void shoot()
    {
        
        Quaternion turretRot = transform.rotation;
        GameObject barrel = transform.GetChild(0).gameObject;
        Vector3 spawnPos = barrel.transform.position;
        spawnTimer -= Time.deltaTime;


        if (spawnTimer <= 0)
        {
            GameObject newBullet = Instantiate(bullet, spawnPos, turretRot);
            newBullet.transform.parent = transform;
            rigidb = newBullet.GetComponent<Rigidbody2D>();
            rigidb.AddForce((closest.transform.position - transform.position).normalized * bulletSpeed);
            spawnTimer = 1.5f;

        }
    }
}