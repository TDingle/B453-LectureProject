using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TurretTarget : MonoBehaviour
{
    public GameObject closest = null;

    GameObject[] currentBils;
    public GameObject[] EnemyBillions;

    GameObject[] GBils;
    GameObject[] YBils;
    GameObject[] BBils;
    GameObject[] OBils;

    GameObject[] YGBils;
    GameObject[] BOBils;

    string parentTag;



    [SerializeField] float spawnTimer = 1.5f;
    
    float bulletSpeed = 500f;
   
    [SerializeField] GameObject bullet;
    Rigidbody2D rigidb;
    float enemyDist;

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
    void shoot()
    {
        
        Quaternion turretRot = transform.rotation;
        GameObject barrel = transform.GetChild(0).gameObject;
        Vector3 spawnPos = barrel.transform.position;
        spawnTimer -= Time.deltaTime;


        if (spawnTimer <= 0)
        {
            GameObject newBullet = Instantiate(bullet, spawnPos, turretRot);
            rigidb = newBullet.GetComponent<Rigidbody2D>();
            rigidb.AddForce((closest.transform.position - transform.position).normalized * bulletSpeed);
            spawnTimer = 1.5f;

        }
    }
}