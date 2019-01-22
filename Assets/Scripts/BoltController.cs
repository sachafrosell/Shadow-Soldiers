using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltController : MonoBehaviour
{
    public GameObject explosion;
    public GameObject sqwuak;
    public GameObject enemy;
    public bool singlePlayer;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;
    private float col = 1f;
    private readonly float length = 0.5f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        StartCoroutine(DisplayCoroutines());
    }

    IEnumerator DisplayCoroutines()
    {
        yield return new WaitForSeconds(length);

        StartCoroutine(OpacitySlide());
        StartCoroutine(DestroySelf());
        StartCoroutine(DisableCollider());
    }

    IEnumerator DisableCollider()
    {
        yield return new WaitForSeconds(0.3f);

        boxCollider2D.enabled = false;
    }

    IEnumerator OpacitySlide()
    {
        for(int i = 0; i < 11; i++)
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, col);
            col -= 0.1f;
            yield return new WaitForSeconds(0.09f);
        }
    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(1f);

        Destroy(gameObject);
    }

    IEnumerator DestroyThings(GameObject collision)
    {
        yield return new WaitForSeconds(0.1f);

        Destroy(collision.gameObject);
        Instantiate(explosion, new Vector3(collision.transform.position.x, collision.transform.position.y), Quaternion.identity);

        switch (collision.gameObject.tag)
        {
            case "Enemy":
                if (singlePlayer)
                {
                    Instantiate(enemy, new Vector3(-20f, 10f), Quaternion.identity);
                }
                break;
            case "Bird":
                Instantiate(sqwuak, new Vector3(collision.transform.position.x, collision.transform.position.y), Quaternion.identity);
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bird" || collision.gameObject.tag == "Enemy")
        {
            StartCoroutine(DestroyThings(collision.gameObject));
        }
    }

}
