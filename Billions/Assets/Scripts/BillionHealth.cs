using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BillionHealth : MonoBehaviour
{
    
    [SerializeField] Sprite[] billionHealthStages;
    public int health = 3;
    private int iter = 0;
    [SerializeField] public int color;
    public int xp = 0;
    GameObject spawner;

    private void Start()
    {
        spawner = GameObject.Find("Billionaire Spawner");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        int bColor = collision.gameObject.GetComponent<bulletMove>().color;
        Destroy(collision.gameObject);

        if (bColor != color)
        {
            if(collision.gameObject.tag == "BaseBullet")
            {
                if(bColor == 0)//green
                {
                    spawner.gameObject.GetComponent<xpManager>().greenXP += 1;
                    Debug.Log("green xp ++");
                }
                else if(bColor == 1)//yellow
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
                health = 0;
            }
            
           
            if (health > 0)
            {
                
                health--;
                
                this.gameObject.GetComponent<SpriteRenderer>().sprite = billionHealthStages[iter];
                iter++;
                
            }
            else if (health == 0)
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
