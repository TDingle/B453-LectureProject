using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


public class Bases : MonoBehaviour
{
    

    [SerializeField] public int color;
    [SerializeField] Sprite[] BaseHealthStages;
    [SerializeField] Sprite[] XPStages;
    [SerializeField] Sprite[] Ranks;
    public double health = 100;
    public int xp = 0;

    public double currentHealth;
    double testHealth = 100.00;


    public int Hiter = 0;
    private int Xiter = 0;
    public int Riter = 0;
    public int reqXP = 2;

    double healthCheck = 6;
    GameObject spawner;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.Find("Rank").GetComponent<SpriteRenderer>().sprite = Ranks[Riter];
        Riter++;
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        spawner = GameObject.Find("Billionaire Spawner");
        if (color == 0)
        {
            xp = spawner.gameObject.GetComponent<xpManager>().greenXP;
        }
        else if (color == 1)
        {
            xp = spawner.gameObject.GetComponent<xpManager>().yellowXP;
        }
        else if (color == 2)
        {
            xp = spawner.gameObject.GetComponent<xpManager>().orangeXP;
        }
        else if (color == 3)
        {
            xp = spawner.gameObject.GetComponent<xpManager>().blueXP;
        }

        experience();
    }
   


    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.GetComponent<bulletMove>().color != color)
        {


            if (currentHealth > 0)
            {

                currentHealth = currentHealth - (((health / 7) % 10) + collision.GetComponent<bulletMove>().rank);
                if(healthCheck >= 0)
                {
                    
                    if (currentHealth <= testHealth * (healthCheck/7)){ 
 
                        this.transform.Find("HealthBar").GetComponent<SpriteRenderer>().sprite = BaseHealthStages[Hiter];
                        Hiter++;
                        healthCheck -= 1;
                    }

                }

            }
            else if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }

            
        }
    }

    void experience()
    { 
        if (xp >= reqXP) {
            if (Xiter < XPStages.Length)
            {
                this.transform.Find("XPBar").GetComponent<SpriteRenderer>().sprite = XPStages[Xiter];
                Xiter++;
                reqXP = reqXP + 1;
            }
            else
            {
                Xiter = 0;
                if (Riter < Ranks.Length)
                {
                    this.transform.Find("Rank").GetComponent<SpriteRenderer>().sprite = Ranks[Riter];
                    if (color == 0)//green
                    {
                        spawner.gameObject.GetComponent<xpManager>().greenRank = Riter;
                       
                    }
                    else if (color == 1)//yellow
                    {
                        spawner.gameObject.GetComponent<xpManager>().yellowRank = Riter;
                       
                    }
                    else if (color == 2)//orange
                    {
                        spawner.gameObject.GetComponent<xpManager>().orangeRank = Riter;
                        
                    }
                    else if (color == 3)//blue
                    {
                        spawner.gameObject.GetComponent<xpManager>().blueRank = Riter;
                        
                    }
                    Riter++;
                }
                
            }
        }
        
    }


}
