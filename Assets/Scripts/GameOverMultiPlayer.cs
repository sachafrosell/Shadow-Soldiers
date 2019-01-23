using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMultiPlayer : MonoBehaviour
{
    public GameObject background;

    private SpriteRenderer spriteRenderer;
    private float col;
    private GameObject player;
    private GameObject player2;
    private float rand;


    void Start()
    {

        col = 1;
        spriteRenderer = background.GetComponent<SpriteRenderer>();
        StartCoroutine(Dimmer());
        player = GameObject.FindGameObjectWithTag("Player");
        player2 = GameObject.FindGameObjectWithTag("Player2");

    }

    IEnumerator Dimmer()
    {
        for (int i = 0; i < 100; i++)
        {
            spriteRenderer.color = new Color(0f, 0f, 0f, col);
            col -= 0.01f;
            yield return new WaitForSeconds(0.025f * Time.deltaTime);
        }
    }



    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2f);
      
        for (int i = 0; i < 50; i++)
        {
            spriteRenderer.color = new Color(0f, 0f, 0f, col);
            col += 0.01f;
            yield return new WaitForSeconds(0.1f);
        }

        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    void Update()
    {
        rand = Random.Range(-30, 30);

        if (!player || !player2)
        {

                StartCoroutine(GameOver());
                
        }
    }
}
