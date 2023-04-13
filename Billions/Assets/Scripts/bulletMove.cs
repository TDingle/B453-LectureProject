using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMove : MonoBehaviour
{
    [SerializeField]float spawnTimer = 1.25f;
    [SerializeField] public int color;
    public int rank;
    GameObject spawner;
    private void Start()
    {
        spawner = GameObject.Find("Billionaire Spawner");
        if (color == 0)//green
        {
            rank = spawner.gameObject.GetComponent<xpManager>().greenRank;

        }
        else if (color == 1)//yellow
        {
            rank = spawner.gameObject.GetComponent<xpManager>().yellowRank;


        }
        else if (color == 2)//orange
        {

            rank = spawner.gameObject.GetComponent<xpManager>().orangeRank;

        }
        else if (color == 3)//blue
        {

            rank = spawner.gameObject.GetComponent<xpManager>().blueRank;

        }
    }
    void Update()
    {
        spawnTimer -= Time.deltaTime;


        if (spawnTimer <= 0)
        {
           Destroy(gameObject);

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.tag == "border")
        {
            Destroy (gameObject);
        }

        
    }
   



}
