using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTextController : MonoBehaviour
{
    private GameObject player;
    private UnityEngine.UI.Text score;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        score = GetComponent<UnityEngine.UI.Text>();
    }

    private void Update()
    {
        if (player)
        {
            score.text = "Score: " + ScoreStaticController.Score;
            gameObject.SetActive(true);
        }
        else
        {
            score.text = "Score: " + ScoreStaticController.Score;
            gameObject.SetActive(true);
        }
    }

}
