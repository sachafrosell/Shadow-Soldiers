using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreController : MonoBehaviour
{
    private UnityEngine.UI.Text score;


    void Start()
    {
        score = GetComponent<UnityEngine.UI.Text>();
    }

    private void Update()
    {

            score.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
            gameObject.SetActive(true);

    }

}
