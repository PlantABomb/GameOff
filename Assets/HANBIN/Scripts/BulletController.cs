using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float deadTime;

    public GameObject gameob;


    // Use this for initialization
    void Start () {
        Destroy(gameob, deadTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
            Destroy(gameob);
    }

    // Update is called once per frame
    void Update () {
	}
}
