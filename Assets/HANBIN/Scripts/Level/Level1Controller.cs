using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Controller : MonoBehaviour {

    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;

    public Transform Generatepos;

    GameObject instance1;
    GameObject instance2;
    GameObject instance3;

    // Use this for initialization
    void Start () {
        StartCoroutine(Level1Control());
	}
	
    IEnumerator Level1Control()
    {
        instance1 = Instantiate(Enemy1, Generatepos.position, Generatepos.rotation);
        yield return new WaitForSeconds(5f);
        instance1 = Instantiate(Enemy2, Generatepos.position, Generatepos.rotation);
        yield return new WaitForSeconds(5f);
        instance1 = Instantiate(Enemy3, Generatepos.position, Generatepos.rotation);
        yield return new WaitForSeconds(5f);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
