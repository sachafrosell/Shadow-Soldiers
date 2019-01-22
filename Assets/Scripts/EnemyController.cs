using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float retreat;

    private float speed;

    private float distance;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        distance = Random.Range(3.5f, 6.5f);
        speed = Random.Range(1.5f, 3f);
    }

    void Update()
    {
        if (player)
        {
            if (Vector2.Distance(transform.position, player.transform.position) > distance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            } 
            else if (Vector2.Distance(transform.position, player.transform.position) < distance && Vector2.Distance(transform.position, player.transform.position) > distance)
            {
                transform.position = this.transform.position;
            } 
            else if (Vector2.Distance(transform.position, player.transform.position) < retreat)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, -speed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Rocket" || collision.gameObject.tag == "Lightning")
        {
            ScoreStaticController.Score += 1;
        }
    }
}
