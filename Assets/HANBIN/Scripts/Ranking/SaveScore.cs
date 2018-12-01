using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScore : MonoBehaviour {


    

    

	// Use this for initialization
	void Start () {
        
        //Debug.Log(System.DateTime.Now);
        //date = System.DateTime.Now.ToString("MM/dd hh:mm");
        //Debug.Log(date);



    }



    static public void scoresave(int clrtime)
    {
        string date; // 랭킹 date 정보

        int[] timearr;
        timearr = new int[6];


        string[] datearr;
        datearr = new string[6];

        //기존의 랭킹 가져옴
        for (int i = 0; i < 6; i++)
        {
            if(PlayerPrefs.GetInt("time_ranking" + (i + 1), 0)==0)
            {
                timearr[i] = 999;
            }
            else
                timearr[i] = PlayerPrefs.GetInt("time_ranking" + (i + 1), 999);

            datearr[i] = PlayerPrefs.GetString("date_ranking" + (i + 1), "");
        }

        //time = clrtime; // 클리어타임 저장
        date = System.DateTime.Now.ToString("MM/dd hh:mm");

        timearr[5] = clrtime;
        datearr[5] = date;

        for(int i =0; i<6; i++)
        {
            for(int j=0; j<6-(i+1); j++)
            {
                if (timearr[j] > timearr[j+1])
                {
                    int tmp;
                    tmp = timearr[j+1];
                    timearr[j+1] = timearr[j];
                    timearr[j] = tmp;
                    string tmps;
                    tmps = datearr[j+1];
                    datearr[j + 1] = datearr[j];
                    datearr[j] = tmps;
                }

            }
        }

        for(int i =0; i<5; i++)
        {
            Debug.Log(timearr[i]);
            PlayerPrefs.SetInt("time_ranking" + (i + 1), timearr[i]);
            PlayerPrefs.SetString("date_ranking" + (i + 1), datearr[i]);
        }
           
        PlayerPrefs.Save();
        //PlayerPrefs.DeleteAll();
    }

	// Update is called once per frame
	void Update () {
		
	}
}
