using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShowMyScore : MonoBehaviour {

    Text scoretext;


	// Use this for initialization
	void Start () {
        scoretext = GetComponent<Text>();


        scoretext.text = ((int)GameManager.Instance.timer / 60).ToString() + ":" + ((int)GameManager.Instance.timer % 60).ToString();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
