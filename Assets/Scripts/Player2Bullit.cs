using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Bullit : MonoBehaviour
{
    public float speed = 20f;
    public GameObject explosion;
    public GameObject sqwuak;

    private GameObject target;
    private Vector3 targetPos;
    private Vector3 thisPos;
    private Rigidbody2D rb;
    private float rand;
    private float angle;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Target2");
        CalculateAngle();
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.right * speed;
        rand = Random.Range(-30, 30);
    }

    private void CalculateAngle()
    {
        targetPos = target.transform.position;
        thisPos = transform.position;
        targetPos.x = targetPos.x - thisPos.x;
        targetPos.y = targetPos.y - thisPos.y;
        angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        transform.Rotate(0f, 0f, angle);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player2" && collision.gameObject.tag != "Bullet" && collision.gameObject.tag != "Target2" && collision.gameObject.tag != "Target")
        {
            print(collision.gameObject.tag);
            Destroy(gameObject);
            Instantiate(explosion, rb.position, Quaternion.identity);
        }

        switch (collision.gameObject.tag)
        {
            case "Bird":
                Destroy(collision.gameObject);
                Instantiate(sqwuak, rb.position, Quaternion.identity);
                break;
            //case "Player":
                //Destroy(collision.gameObject);
                //break;
        }
    }

}

