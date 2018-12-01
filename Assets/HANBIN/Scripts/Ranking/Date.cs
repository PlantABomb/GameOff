using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Date : MonoBehaviour {

    Text datetext;

    public int index;

	// Use this for initialization
	void Start () {
        datetext = GetComponent<Text>();
        datetext.text = PlayerPrefs.GetString("date_ranking" + (index + 1), "");
     }
	
	// Update is called once per frame
	void Update () {
		
	}
}
