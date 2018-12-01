using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ExitButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void GotoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
