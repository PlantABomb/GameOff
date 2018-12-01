using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickPlay : MonoBehaviour {

    Animator anim;
    public string buttonname;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}

    private void OnMouseEnter()
    {
        anim.SetBool("MouseExit", false);
        anim.SetBool("MouseEnter", true);
    }

    private void OnMouseExit()
    {
        anim.SetBool("MouseEnter", false);
        anim.SetBool("MouseExit", true); 
    }

    private void OnMouseDown()
    {
        if (buttonname.Equals("Quit"))
            Application.Quit();

        SceneManager.LoadScene(buttonname);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
