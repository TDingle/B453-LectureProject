using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bases : MonoBehaviour
{
    

    [SerializeField] public int color;
    [SerializeField] Sprite[] BaseHealthStages;
    [SerializeField] Sprite[] XPStages;
    private int health = 7;
    private int Hiter = 0;
    public int xp = 0;
    private int Xiter = 0;

    public int reqXP = 5;

    GameObject spawner;
    // Start is called before the first frame update
    void Start()
    {
        
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
            

            if (health > 0)
            {

                health--;
                this.transform.Find("HealthBar").GetComponent<SpriteRenderer>().sprite = BaseHealthStages[Hiter];
                
                Hiter++;

            }
            else if (health == 0)
            {
                Destroy(gameObject);
            }

            
        }
    }

    void experience()
    { 
        if (xp == reqXP) {
            if (Xiter < XPStages.Length)
            {
                this.transform.Find("XPBar").GetComponent<SpriteRenderer>().sprite = XPStages[Xiter];
                Xiter++;
                reqXP = reqXP + 2;
            }
            else
            {
                Xiter = 0;
            }
        }
        
    }


}
