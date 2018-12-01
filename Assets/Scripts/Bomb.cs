using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {
    public Animator animator;

    readonly int HashDestroy = Animator.StringToHash("Destroy");

    public void DestroyBomb()
    {
        animator.SetTrigger(HashDestroy);
    }
}
