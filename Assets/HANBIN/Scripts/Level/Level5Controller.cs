using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5Controller : MonoBehaviour {

    public float lvltime=0;

    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;

    public Transform Generatepos1_1;
    public Transform Generatepos1_2;
    public Transform Generatepos1_3;
    public Transform Generatepos2_1;
    public Transform Generatepos2_2;
    public Transform Generatepos2_3;
    public Transform Generatepos3_1;
    public Transform Generatepos3_2;
    public Transform Generatepos3_3;

    GameObject instance1;
    GameObject instance2;
    GameObject instance3;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Level5Control());
    }

    IEnumerator Level5Control()
    {
        //단계1
        instance3 = Instantiate(Enemy3, Generatepos1_1.position, Generatepos1_1.rotation);
        instance3 = Instantiate(Enemy3, Generatepos1_2.position, Generatepos1_2.rotation);
        yield return new WaitForSeconds(1.5f);
        lvltime += 1.5f;
        instance1 = Instantiate(Enemy1, Generatepos1_3.position, Generatepos1_3.rotation);
        yield return new WaitForSeconds(5f);

        //단계2
        instance3 = Instantiate(Enemy3, Generatepos2_1.position, Generatepos2_1.rotation);
        instance3 = Instantiate(Enemy3, Generatepos2_2.position, Generatepos2_2.rotation);
        yield return new WaitForSeconds(1.5f);
        lvltime += 1.5f;
        instance1 = Instantiate(Enemy1, Generatepos2_3.position, Generatepos2_3.rotation);
        yield return new WaitForSeconds(5f);

        //단계3
        instance2 = Instantiate(Enemy2, Generatepos3_1.position, Generatepos3_1.rotation);
        yield return new WaitForSeconds(1.5f);
        lvltime += 1.5f;
        instance1 = Instantiate(Enemy1, Generatepos3_2.position, Generatepos3_2.rotation);
        yield return new WaitForSeconds(1.5f);
        lvltime += 1.5f;
        instance3 = Instantiate(Enemy3, Generatepos3_3.position, Generatepos3_3.rotation);
        yield return new WaitForSeconds(5f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
