using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public float speed;
    public GameObject target;

    private GameObject player;
    private Rigidbody2D rb;
    private Vector3 vec;
    private Animator anim;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        CheckMove();
    }

    private void FixedUpdate()
    {
        if (player)
        {
            transform.localScale = player.transform.position.x < transform.position.x ? new Vector3(0.4f, 0.4f) : new Vector3(-0.4f, 0.4f);
        }
    }

    private void CheckMove()
    {
        if (rb.IsSleeping())
        {
            anim.SetBool("isMoving", false);
        }
        else
        {
            anim.SetBool("isMoving", true);
        }
    }

}
