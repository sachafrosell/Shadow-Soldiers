using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1DamageController : MonoBehaviour
{

    private float hits;
    private GameObject healthBar;
    private GameObject[] healthBars;
    private SpriteRenderer[] spriteRenderers;
    private Vector3 healthBarOriginalScale;
    private Vector3 newHealthBarScale;
    private GameObject player;
    private SpriteRenderer spriteRenderer;
    private Transform cam;
    private float hBY;
    private float step;
    private float col;

    void Start()
    {
        col = 0;
        hits = 0;
        healthBar = GameObject.FindGameObjectWithTag("HealthBar1");
        healthBars = GameObject.FindGameObjectsWithTag("HealthBar1");
    
        spriteRenderer = healthBar.GetComponent<SpriteRenderer>();
        healthBarOriginalScale = healthBar.transform.localScale;
        hBY = healthBarOriginalScale.y;
        step = hBY / 100;
        player = GameObject.FindGameObjectWithTag("Player");
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
    }


    private void FixedUpdate()
    {


        if (hits >= 100)
        {
            for (int i = 0; i < healthBars.Length; i++)
            {
                Destroy(healthBars[i]);
            }
            Destroy(gameObject);
        }

        if (GameSettingsStaticController.birds)
        {
            GameSettingsStaticController.birds = false;
            newHealthBarScale = new Vector3(healthBar.transform.localScale.x + (2 * step), healthBarOriginalScale.y, healthBarOriginalScale.z);
            for (int i = 0; i < healthBars.Length; i++)
            {
                healthBars[i].transform.localScale = newHealthBarScale;
            }
            hits--;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "EnemyBullet":
                hits += 2;
                newHealthBarScale = new Vector3(healthBar.transform.localScale.x - 5 * step, healthBarOriginalScale.y, healthBarOriginalScale.z);
                for (int i = 0; i < healthBars.Length; i++)
                {
                    healthBars[i].transform.localScale = newHealthBarScale;
                }
                break;
            case "EnemyRocket":
                hits += 8;
                newHealthBarScale = new Vector3(healthBar.transform.localScale.x - 17 * step, healthBarOriginalScale.y, healthBarOriginalScale.z);
                healthBar.transform.localScale = newHealthBarScale;
                break;
            case "Lightning":
                hits += 10;
                newHealthBarScale = new Vector3(healthBar.transform.localScale.x - 21 * step, healthBarOriginalScale.y, healthBarOriginalScale.z);
                healthBar.transform.localScale = newHealthBarScale;
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "EnemyBullet":
                hits += 2;
                newHealthBarScale = new Vector3(healthBar.transform.localScale.x - 5 * step, healthBarOriginalScale.y, healthBarOriginalScale.z);
                for (int i = 0; i < healthBars.Length; i++)
                {
                    healthBars[i].transform.localScale = newHealthBarScale;
                }
                break;
            case "EnemyRocket":
                hits += 8;
                newHealthBarScale = new Vector3(healthBar.transform.localScale.x - 17 * step, healthBarOriginalScale.y, healthBarOriginalScale.z);
                healthBar.transform.localScale = newHealthBarScale;
                break;
            case "Lightning":
                hits += 10;
                newHealthBarScale = new Vector3(healthBar.transform.localScale.x - 21 * step, healthBarOriginalScale.y, healthBarOriginalScale.z);
                healthBar.transform.localScale = newHealthBarScale;
                break;
        }
    }
}
