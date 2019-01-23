using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningControllerP1 : MonoBehaviour
{
    public GameObject bolt;
    public GameObject explosion;
    public GameObject sqwuak;
    public GameObject enemy;
    public bool singlePlayer;

    void Start()
    {
        StartCoroutine(DestroySelf());
    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(0.5f);

        Destroy(gameObject);
        Instantiate(bolt, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bird" || collision.gameObject.tag == "Enemy")
        {
            StartCoroutine(DestroyThings(collision.gameObject));
        }
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

}
