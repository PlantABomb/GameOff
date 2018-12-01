using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
    public static LevelController Instance;

    public GameObject[] Level;
    public Transform center;
    private int levelindex;

    bool onemore = false;

    public Animator anim;
    public int bosspattern = 1;

    GameObject instance;

    // Use this for initialization

    void Start () {
        Instance = this;
        // MakeLevelFalse();
        levelindex = 0;

        StartCoroutine(animcontrol());
    }
	
    IEnumerator animcontrol()
    {
        while (GameManager.Instance.isPlaying) {  // true 는 playable 인지 아닌지
            if(levelindex == Level.Length)
            {
                if (bosspattern == 1)
                {
                    anim.SetBool("pattern1on", true);
                    bosspattern += 1;
                    yield return new WaitForSeconds(19f);
                    anim.SetBool("pattern1on", false);
                }
                else if (bosspattern == 2)
                {
                    anim.SetBool("pattern2on", true);
                    bosspattern -= 1;
                    yield return new WaitForSeconds(18f);
                    anim.SetBool("pattern2on", false);
                }
                yield return new WaitForSeconds(0.5f);
                //MakeLevelFalse();
                levelindex = 0;
                //Level[levelindex].SetActive(true);
                instance = Instantiate(Level[levelindex], center.position, center.rotation);
                yield return new WaitForSeconds(20f);
                Destroy(instance);
                //Level[levelindex].SetActive(false);
                levelindex++;
                //Instantiate(Level[levelindex], center.position, center.rotation);
            }
            else
            {
                //Level[levelindex].SetActive(true);
                instance = Instantiate(Level[levelindex], center.position, center.rotation);
                yield return new WaitForSeconds(21f);
                Destroy(instance);
                //Level[levelindex].SetActive(false);
                levelindex++;
            }
            
        }
    }

    void MakeLevelFalse()
    {
        for (int i = 0; i < Level.Length; i++)
        {
            Level[i].SetActive(false);
        }
    }

	// Update is called once per frame
	void Update () {
        if (!GameManager.Instance.isPlaying)
            onemore = true;
        if(onemore)
        {
            StartCoroutine(animcontrol());
            onemore = false;
        }
	}
}
