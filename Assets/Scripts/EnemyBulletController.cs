using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    public float speed = 10f;
    public GameObject explosion;

    private GameObject target;
    private Vector3 targetPos;
    private Vector3 thisPos;
    private float angle;
    private Rigidbody2D rb;
    private Vector3 mousePos;

    void Start()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        CalculateAngle();
    }

    void CalculateAngle()
    {
        targetPos = target.transform.position;
        thisPos = transform.position;
        targetPos.x = targetPos.x - thisPos.x;
        targetPos.y = (targetPos.y + 0.5f) - thisPos.y;
        angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        transform.Rotate(0f, 0f, angle);
    }

    void FixedUpdate()
    {
        rb.velocity = transform.right * speed;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Cieling" || collision.gameObject.tag == "Lightning")
        {
                Destroy(gameObject);
                Instantiate(explosion, rb.position, Quaternion.identity);
               
        }

    }
}
