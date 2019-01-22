using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameSettingsStaticController;

public class birdMove : MonoBehaviour
{

    private float speed;
    private Rigidbody2D rb;
    private Animator anim;
    private float randomIdleStart;
    private float rand;

    void Start()
    {
        rand = Random.Range(-5f, 2f);
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        speed = Random.Range(2f, 8f);
        randomIdleStart = Random.Range(0, anim.GetCurrentAnimatorStateInfo(0).length);
        //anim.Play("drawn_bird_animation", 0, randomIdleStart);
        transform.Translate(0f, rand, 0f);
    }

    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0f, 0f);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        birds |= collision.gameObject.tag == "Rocket";
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        birds |= (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Lightning");
    }

}
