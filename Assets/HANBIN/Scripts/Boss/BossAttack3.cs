using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack3 : MonoBehaviour {

    public bool attackon = false;

    public Transform Attackpos1;
    public Transform Attackpos2;
    public Transform Attackpos3;

    public Transform Attackpos1_core;
    public Transform Attackpos2_core;
    public Transform Attackpos3_core;

    public GameObject bossbullet1;
    public GameObject bossbullet2;
    public GameObject bossbullet3;

    public ForceMode2D mode;

    public float speed;

    GameObject instance;
    GameObject instance2;
    GameObject instance3;


    // Use this for initialization
    void Start()
    {
        StartCoroutine(bossattackcontrol());
    }

    public void BossAttack()
    {
        StartCoroutine(bossattackcontrol());
    }

    IEnumerator bossattackcontrol()
    {
        for (int i = 0; i < 3; i++)
        {
            instance = Instantiate(bossbullet1, Attackpos1.position, Attackpos1.rotation);
            instance.GetComponent<Rigidbody2D>().AddForce((Attackpos1.position - Attackpos1_core.position) * speed, mode);
            //yield return new WaitForSeconds(1f);
            instance2 = Instantiate(bossbullet2, Attackpos2.position, Attackpos2.rotation);
            instance2.GetComponent<Rigidbody2D>().AddForce((Attackpos2.position - Attackpos2_core.position) * speed, mode);
            instance3 = Instantiate(bossbullet3, Attackpos3.position, Attackpos3.rotation);
            instance3.GetComponent<Rigidbody2D>().AddForce((Attackpos3.position - Attackpos3_core.position) * speed, mode);
            yield return new WaitForSeconds(1f);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }
}
