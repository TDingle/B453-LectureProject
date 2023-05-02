using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class BillionHealth : MonoBehaviour
{


    [SerializeField] Sprite[] billionHealthStages;
    [SerializeField] Sprite[] Ranks;
    public double health = 3;
    private int iter = 0;
    public int rIter = 0;
    [SerializeField] public int color;
    public int xp = 0;
    GameObject spawner;

    float powerUpTimer = 2f;



    double currentHealth = 0;
    private void Start()
    {
        
        spawner = GameObject.Find("Billionaire Spawner");
        if (color == 0)//green
        {
           rIter = spawner.gameObject.GetComponent<xpManager>().greenRank;
           
        }
        else if (color == 1)//yellow
        {
            rIter = spawner.gameObject.GetComponent<xpManager>().yellowRank;


        }
        else if (color == 2)//orange
        {

            rIter = spawner.gameObject.GetComponent<xpManager>().orangeRank;

        }
        else if (color == 3)//blue
        {

            rIter = spawner.gameObject.GetComponent<xpManager>().blueRank;

        }
        if (rIter >= 0)
        {
        this.transform.Find("Rank").GetComponent<SpriteRenderer>().sprite = Ranks[rIter];

        }
        health = rIter + health;
        currentHealth = health;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {


        Destroy(collision.gameObject);

        if (collision.gameObject.tag == "Crate")
        {

            int crateType = collision.gameObject.GetComponent<Crate>().type;
            if (color == 0)//green
            {
                if (crateType == 1)
                {
                    spawner.gameObject.GetComponent<xpManager>().greenTril += 5;
                    powerUpTimer -= Time.deltaTime;
                    if (powerUpTimer > 0)
                    //{
                        transform.GetChild(4).gameObject.SetActive(true);
                    //}
                    //transform.GetChild(4).gameObject.SetActive(false);

                }
                else if (crateType == 2)
                {
                    spawner.gameObject.GetComponent<xpManager>().greenXP += 8;
                    //powerUpTimer -= Time.deltaTime;
                    //if (powerUpTimer > 0)
                    //{
                        transform.GetChild(2).gameObject.SetActive(true);
                    //}
                    //transform.GetChild(2).gameObject.SetActive(false);
                }
                else if (crateType == 3)
                {
                    spawner.gameObject.GetComponent<xpManager>().greenXP += 5;
                    powerUpTimer -= Time.deltaTime;
                    //if (powerUpTimer > 0)
                    //{
                        transform.GetChild(3).gameObject.SetActive(true);
                    //}
                    //transform.GetChild(3).gameObject.SetActive(false);
                }
            }

            else if (color == 1)//yellow
            {
                if(crateType == 1)
                {
                    spawner.gameObject.GetComponent<xpManager>().yellowTril += 5;

                }
                else if (crateType == 2)
                {
                    spawner.gameObject.GetComponent<xpManager>().yellowXP += 8;
                }
                else if (crateType == 3)
                {
                    spawner.gameObject.GetComponent<xpManager>().yellowXP += 5;
                }

            }
            else if (color == 2)//orange
            {
                if(crateType == 1)
                {
                    spawner.gameObject.GetComponent<xpManager>().orangeTril += 5;

                }
                else if (crateType == 2)
                {
                    spawner.gameObject.GetComponent<xpManager>().orangeXP += 8;
                }
                else if (crateType == 3)
                {
                    spawner.gameObject.GetComponent<xpManager>().orangeXP += 5;
                }

            }
            else if (color == 3)//blue
            {
                if(crateType == 1)
                {
                    spawner.gameObject.GetComponent<xpManager>().blueTril += 5;

                }
                else if (crateType == 2)
                {
                    spawner.gameObject.GetComponent<xpManager>().blueXP += 8;
                }
                else if (crateType == 3)
                {
                    spawner.gameObject.GetComponent<xpManager>().blueXP += 5;
                }
            }
        }
        if (collision.gameObject.tag == "BaseBullet" || collision.gameObject.tag == "Bullet")
        {
            int bColor = collision.gameObject.GetComponent<bulletMove>().color;
            int bRank = collision.gameObject.GetComponent<bulletMove>().rank;

            if (bColor != color)
            {
                if (collision.gameObject.tag == "BaseBullet")
                {
                    if (bColor == 0)//green
                    {
                        spawner.gameObject.GetComponent<xpManager>().greenXP += 1;
                    }

                    else if (bColor == 1)//yellow
                    {
                        spawner.gameObject.GetComponent<xpManager>().yellowXP += 1;

                    }
                    else if (bColor == 2)//orange
                    {
                        spawner.gameObject.GetComponent<xpManager>().orangeXP += 1;

                    }
                    else if (bColor == 3)//blue
                    {
                        spawner.gameObject.GetComponent<xpManager>().blueXP += 1;

                    }
                    Destroy(gameObject);
                    health = 0;
                }


                if (currentHealth > 0)
                {

                    currentHealth = currentHealth - ((health * .25) + bRank);
                    if (iter < billionHealthStages.Length)
                    {
                        this.gameObject.GetComponent<SpriteRenderer>().sprite = billionHealthStages[iter];
                        iter++;
                    }
                }
                else if (currentHealth <= 0)
                {
                    if (bColor == 0)//green
                    {
                        spawner.gameObject.GetComponent<xpManager>().greenXP += 1;
                        
                    }
                    else if (bColor == 1)//yellow
                    {
                        spawner.gameObject.GetComponent<xpManager>().yellowXP += 1;
                        
                    }
                    else if (bColor == 2)//orange
                    {
                        spawner.gameObject.GetComponent<xpManager>().orangeXP += 1;
                        
                    }
                    else if (bColor == 3)//blue
                    {
                        spawner.gameObject.GetComponent<xpManager>().blueXP += 1;
                        
                    }
                    Destroy(gameObject);
                }
            }
        }
    }
}
