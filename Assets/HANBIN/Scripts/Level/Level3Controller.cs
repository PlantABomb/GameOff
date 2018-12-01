using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Controller : MonoBehaviour {

    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;

    public Transform Generatepos1_1;
    public Transform Generatepos1_2;
    public Transform Generatepos2_1;
    public Transform Generatepos2_2;
    public Transform Generatepos3_1;
    public Transform Generatepos3_2;

    GameObject instance1;
    GameObject instance2;
    GameObject instance3;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Level3Control());
    }

    IEnumerator Level3Control()
    {
        //단계1
        instance2 = Instantiate(Enemy2, Generatepos1_1.position, Generatepos1_1.rotation);
        yield return new WaitForSeconds(1.5f);
        instance1 = Instantiate(Enemy1, Generatepos1_2.position, Generatepos1_2.rotation);
        yield return new WaitForSeconds(5f);

        //단계2
        instance1 = Instantiate(Enemy1, Generatepos2_1.position, Generatepos2_1.rotation);
        yield return new WaitForSeconds(1.5f);
        instance1 = Instantiate(Enemy1, Generatepos2_2.position, Generatepos2_2.rotation);
        yield return new WaitForSeconds(5f);

        //단계3
        instance2 = Instantiate(Enemy2, Generatepos3_1.position, Generatepos3_1.rotation);
        yield return new WaitForSeconds(1.5f);
        instance2 = Instantiate(Enemy2, Generatepos3_2.position, Generatepos3_2.rotation);
        yield return new WaitForSeconds(5f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
