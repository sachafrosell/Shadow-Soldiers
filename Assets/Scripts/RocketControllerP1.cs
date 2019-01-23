using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketControllerP1 : MonoBehaviour
{
    public float speed = 5f;
    public float offset;
    public GameObject explosion;
    public GameObject sqwuak;
    public GameObject bigExplosionSound;
    public GameObject rocketTrailSound;
    public GameObject enemy;
    public bool singlePlayer;

    private GameObject target;
    private float rand;
    private string whom;
    private GameObject big;
    private GameObject exp;
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
        singlePlayer = GameSettingsStaticController.SinglePlayer;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rb = GetComponent<Rigidbody2D>();
        rand = Random.Range(-50, 50);

        if (transform.position == enemy.transform.position)
        {
            target = enemy;
            whom = "enemy";
        }
        else
        {
            target = GameObject.FindGameObjectWithTag("Target1");
            whom = "player";
        }

        trail = Instantiate(rocketTrailSound, rb.position, Quaternion.identity);

    }

    void CalculateAngle()
    {
        Vector3 vectorToTarget = target.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 360);
    }

    void FixedUpdate()
    {
        randX = Random.Range(-1, 1);
        randY = Random.Range(-1, 1);
        CalculateAngle();
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }



    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (whom == "player")
        {
            if (collision.gameObject.tag == "Bird")
            {
                    Instantiate(sqwuak, rb.position, Quaternion.identity);

            }
            if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Bullet" && collision.gameObject.tag != "Cieling" && collision.gameObject.tag != "Target1")
            {
                Destroy(gameObject);
                Destroy(trail);
                big = Instantiate(bigExplosionSound, rb.position, Quaternion.identity);
                exp = Instantiate(explosion, rb.position, Quaternion.identity) as GameObject;
                exp.transform.localScale = new Vector3(0.5f, 0.5f, 0f);
                StartCoroutine(DestroySound());
            }
        }
        else
        {

            if (collision.gameObject.tag != "Enemy" && collision.gameObject.tag != "Bullet" && collision.gameObject.tag != "Cieling" && collision.gameObject.tag != "Target")
            {
                Destroy(gameObject);
                Destroy(trail);
                big = Instantiate(bigExplosionSound, rb.position, Quaternion.identity);
                exp = Instantiate(explosion, rb.position, Quaternion.identity) as GameObject;
                exp.transform.localScale = new Vector3(0.5f, 0.5f, 0f);
                StartCoroutine(DestroySound());
            }
            if (collision.gameObject.tag == "Bird")
            {
                Instantiate(sqwuak, rb.position, Quaternion.identity);
            }

        }
    }

    IEnumerator DestroySound()
    {
        yield return new WaitForSeconds(3f);
        Destroy(big);
        Destroy(exp);
    }
}
