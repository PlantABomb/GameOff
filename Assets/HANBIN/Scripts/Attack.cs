using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
    

    public Transform Core;

    public Transform Attackpos1;
    public Transform Attackpos2;

    public GameObject bullet1;
    public GameObject bullet2;

    public GameObject gameob;

    public float deadTime;

    public float waitTime;

    public ForceMode2D mode;

    public float speed;

    bool canshoot = false;

    GameObject instance1;
    GameObject instance2;


    // Use this for initialization
    void Start () {
        instance1 = Instantiate(bullet1, Attackpos1.position, Attackpos1.rotation);
        instance2 = Instantiate(bullet2, Attackpos2.position, Attackpos2.rotation);
        Destroy(gameob, deadTime);
    }

    void FixedUpdate()
    {
        if (canshoot)
        {
            if(instance1)
            instance1.GetComponent<Rigidbody2D>().AddForce((Attackpos1.transform.position - Core.position)*speed, mode);
            if(instance2)
            instance2.GetComponent<Rigidbody2D>().AddForce((Attackpos2.transform.position - Core.position)*speed, mode);
        }
    }

    // Update is called once per frame
    void Update () {
        if (waitTime <= 0)
        {
            canshoot = true;
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}
