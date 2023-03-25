using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BillionHealth : MonoBehaviour
{
    
    [SerializeField] Sprite[] billionHealthStages;
    private int health = 3;
    private int iter = 0;
    [SerializeField] public int color;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        
        if (collision.gameObject.GetComponent<bulletMove>().color != color)
        {
            if(collision.gameObject.tag == "BaseBullet")
            {
                Destroy(collision.gameObject);
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
                Destroy(gameObject);
            }
        }
    }
}
