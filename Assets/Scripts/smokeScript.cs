using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smokeScript : MonoBehaviour
{
    private Animator anim;
    private float randomIdleStart;
    private float randomSpeed;

    void Start()
    {
        anim = GetComponent<Animator>();
        randomIdleStart = Random.Range(0, anim.GetCurrentAnimatorStateInfo(0).length);
        anim.Play("smokeanimation", 0, randomIdleStart);
        randomSpeed = Random.Range(0.2f, 1.5f);
        anim.speed = randomSpeed;

    }

}
