using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using static ScoreStaticController;

public class GameOverController : MonoBehaviour
{
    public GameObject enemy;
    public float spawnRate;
    public float rate = 10;
    public bool singlePlayer;
    private SpriteRenderer spriteRenderer;
    private float col;
    private GameObject player;
    private float rand;


    void Start()
    {
        singlePlayer = GameSettingsStaticController.SinglePlayer;
        col = 1;
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(Dimmer());
        player = GameObject.FindGameObjectWithTag("Player");

        if (singlePlayer)
        {
            StartCoroutine(CreateEnemy());
        }
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

    IEnumerator CreateEnemy()
    {
        yield return new WaitForSeconds(5f);
        for (int i = 0; i < 10000; i++)
        {
            Instantiate(enemy, new Vector3(rand, 20f), Quaternion.identity);
            yield return new WaitForSeconds(rate / GameSettingsStaticController.enemySpawnRate);
            rate -= spawnRate;
        }
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2f);
        //col = 0;
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

        if (!player)
        {
            if (singlePlayer)
            {
                StartCoroutine(GameOver());
                if (Score > HighScore)
                {
                    HighScore = Score;
                    PlayerPrefs.SetInt("HighScore", HighScore);
                }
            }
        }
    }
}

