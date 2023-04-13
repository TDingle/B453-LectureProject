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
        
        int bColor = collision.gameObject.GetComponent<bulletMove>().color;
        int bRank = collision.gameObject.GetComponent<bulletMove>().rank;
        Destroy(collision.gameObject);

        if (bColor != color)
        {
            if(collision.gameObject.tag == "BaseBullet")
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
                    Debug.Log("green xp ++");
                }
                else if (bColor == 1)//yellow
                {
                    spawner.gameObject.GetComponent<xpManager>().yellowXP += 1;
                    Debug.Log("yellow xp ++");
                }
                else if (bColor == 2)//orange
                {
                    spawner.gameObject.GetComponent<xpManager>().orangeXP += 1;
                    Debug.Log("orange xp ++");
                }
                else if (bColor == 3)//blue
                {
                    spawner.gameObject.GetComponent<xpManager>().blueXP += 1;
                    Debug.Log("blue xp ++");
                }
                Destroy(gameObject);
            }
        }
    }
    
}
