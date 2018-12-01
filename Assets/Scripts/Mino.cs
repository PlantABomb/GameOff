using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mino : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.Instance.isDestory || GameManager.Instance.invincible < 2f || !GameManager.Instance.isPlaying)
            return;

        GameManager.Instance.isDestory = true;

        GameManager.Instance.DestroyMino();

        GameManager.Instance.isDestory = false;
    }
}
