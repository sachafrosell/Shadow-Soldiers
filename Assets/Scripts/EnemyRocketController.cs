using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRocketController : MonoBehaviour
{
    public float speed = 5f;
    public float offset;
    public GameObject explosion;
    public GameObject sqwuak;
    public GameObject bigExplosionSound;
    public GameObject rocketTrailSound;
    public GameObject player;

    private GameObject target;
    private GameObject big;
    private GameObject trail;
    private Vector3 targetPos;
    private Vector3 thisPos;
    private float angle;
    private Rigidbody2D rb;
    private Vector3 mousePos;
    private float randX;
    private float randY;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        target = player;
        trail = Instantiate(rocketTrailSound, rb.position, Quaternion.identity);

    }

    void CalculateAngle()
    {
        Vector3 vectorToTarget = new Vector3(target.transform.position.x, target.transform.position.y + 0.5f) - transform.position;
        angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 360);
    }

    void FixedUpdate()
    {
        if (player)
        {
            randX = Random.Range(-1, 1);
            randY = Random.Range(-1, 1);
            CalculateAngle();
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Enemy" && collision.gameObject.tag != "Target")
        {
            Destroy(gameObject);
            Destroy(trail);
            big = Instantiate(bigExplosionSound, rb.position, Quaternion.identity);
            GameObject exp = Instantiate(explosion, rb.position, Quaternion.identity) as GameObject;
            exp.transform.localScale = new Vector3(0.5f, 0.5f, 0f);
            StartCoroutine(DestroySound());
        }
        if (collision.gameObject.tag == "Bird")
        {
            Instantiate(sqwuak, rb.position, Quaternion.identity);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Enemy" && collision.gameObject.tag != "Target")
        {
            Destroy(gameObject);
            Destroy(trail);
            big = Instantiate(bigExplosionSound, rb.position, Quaternion.identity);
            GameObject exp = Instantiate(explosion, rb.position, Quaternion.identity) as GameObject;
            exp.transform.localScale = new Vector3(0.5f, 0.5f, 0f);
            StartCoroutine(DestroySound());
        }
    }

    IEnumerator DestroySound()
    {
        yield return new WaitForSeconds(3f);
        Destroy(big);
    }
}
