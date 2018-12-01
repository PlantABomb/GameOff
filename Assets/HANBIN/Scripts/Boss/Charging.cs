using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charging : MonoBehaviour {


    Animator anim;

    public bool ischargeon = false;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
	}
	


	// Update is called once per frame
	void Update () {
        if (ischargeon)
        {
            ischargeon = false;
            anim.SetBool("ChargeOn", true);
        }
	}
}
