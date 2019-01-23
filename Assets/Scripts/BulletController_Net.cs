using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BulletController_Net : NetworkBehaviour
{
    public float speed = 20f;
    public bool singlePlayer;
    public GameObject explosion;
    public GameObject sqwuak;
    public GameObject enemy;

    private GameObject player;
    private GameObject target;
    private Vector3 targetPos;
    private Vector3 thisPos;
    private Rigidbody2D rb;
    private float rand;
    private float angle;

    [ServerCallback]
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Target");
        player = GameObject.FindGameObjectWithTag("Player");
       
    }

    [ServerCallback]
    void Update()
    {
        rb.velocity = transform.right * speed; 
        rand = Random.Range(-10, 10);
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
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Bullet" && collision.gameObject.tag != "Target" && collision.gameObject.tag != "ExTarget")
        {
            Destroy(gameObject);
            Instantiate(explosion, rb.position, Quaternion.identity);
        }

        switch (collision.gameObject.tag)
        {
            case "Bird":
                Destroy(collision.gameObject);
                Instantiate(sqwuak, rb.position, Quaternion.identity);
                break;
            case "Enemy":
                Destroy(collision.gameObject);
                if (singlePlayer)
                {
                    print("hit");
                    Instantiate(enemy, new Vector3(player.transform.position.x + rand, 10f), Quaternion.identity);
                }
                break;
        }
    }

}
