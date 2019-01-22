using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageController : MonoBehaviour
{

    private float hits;
    private GameObject healthBar;
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
        healthBar = GameObject.FindGameObjectWithTag("HealthBar");
        spriteRenderer = healthBar.GetComponent<SpriteRenderer>();
        StartCoroutine(OpacitySlider());
        healthBarOriginalScale = healthBar.transform.localScale;
        hBY = healthBarOriginalScale.y;
        step = hBY / 100;
        player = GameObject.FindGameObjectWithTag("Player");
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
    }

    IEnumerator OpacitySlider()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < 50; i++)
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, col);
            col += 0.01f;
            yield return new WaitForSeconds(0.001f);
        }

    }

    private void FixedUpdate()
    {
        healthBar.transform.position = new Vector3(player.transform.position.x + 0.8f, -8.5f);
        if (hits >= 100)
        {
            Destroy(healthBar);
            Destroy(gameObject);
        }

        if (GameSettingsStaticController.birds)
        {
            GameSettingsStaticController.birds = false;
            newHealthBarScale = new Vector3(healthBar.transform.localScale.x + (2 * step), healthBarOriginalScale.y, healthBarOriginalScale.z);
            healthBar.transform.localScale = newHealthBarScale;
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
                healthBar.transform.localScale = newHealthBarScale;
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
                healthBar.transform.localScale = newHealthBarScale;
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
