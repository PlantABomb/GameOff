using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemy : MonoBehaviour
{

    //public float speed;
    private float waitTime;
    public float startWaitTime;

    public Transform[] moveSpots;
   // private Transform generatespot;

    public GameObject[] Enemy;

    private int randomindex;
    // int currentspotindex=0;
    //private int randomSpot;

    // Use this for initialization
    void Start()
    {
       
       
        //waitTime = startWaitTime;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (waitTime <= 0)
        {
            randomindex = Random.Range(0, 3);
            transform.position = new Vector2(Random.Range(moveSpots[0].position.x, moveSpots[1].position.x), Random.Range(moveSpots[0].position.y, moveSpots[1].position.y));
            GameObject instance = Instantiate(Enemy[randomindex], transform.position, transform.rotation);
            waitTime = startWaitTime;
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}
