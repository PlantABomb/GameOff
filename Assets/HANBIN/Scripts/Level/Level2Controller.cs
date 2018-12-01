using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Controller : MonoBehaviour {

    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;

    public Transform Generatepos1;
    public Transform Generatepos2_1;
    public Transform Generatepos2_2;
    public Transform Generatepos3_1;
    public Transform Generatepos3_2;

    GameObject instance1;
    GameObject instance2;
    GameObject instance3;

    // Use this for initialization
    void Start () {
        StartCoroutine(Level2Control());
    }

    IEnumerator Level2Control()
    {
        instance1 = Instantiate(Enemy1, Generatepos1.position, Generatepos1.rotation);
        instance2 = Instantiate(Enemy2, Generatepos1.position, Generatepos1.rotation);
        yield return new WaitForSeconds(5f);
        instance3 = Instantiate(Enemy3, Generatepos2_1.position, Generatepos2_1.rotation);
        instance3 = Instantiate(Enemy3, Generatepos2_2.position, Generatepos2_2.rotation);
        yield return new WaitForSeconds(5f);
        instance3 = Instantiate(Enemy3, Generatepos3_1.position, Generatepos3_1.rotation);
        yield return new WaitForSeconds(1.5f);
        instance1 = Instantiate(Enemy1, Generatepos3_2.position, Generatepos3_2.rotation);
        yield return new WaitForSeconds(5f);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
