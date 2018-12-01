using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayTime : MonoBehaviour {

    Text playtime;

    public int index;

	// Use this for initialization
	void Start () {
        playtime = GetComponent<Text>();
        if(PlayerPrefs.GetInt("time_ranking" + (index + 1), 999) == 999)
        {
            playtime.text = "";
        }
        else
            playtime.text = (PlayerPrefs.GetInt("time_ranking" + (index + 1), 0) / 60).ToString() + ":" + (PlayerPrefs.GetInt("time_ranking" + (index + 1), 0)%60).ToString();
    }
	
	// Update is called once per frame
	void Update () {
	    	
	}
}
