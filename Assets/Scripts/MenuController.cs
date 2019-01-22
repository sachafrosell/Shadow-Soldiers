using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using static ScoreStaticController;
using static GameSettingsStaticController;
using UnityEngine.EventSystems;

public class MenuController : MonoBehaviour
{

    public GameObject background;
    public GameObject menu2;
    public GameObject menu1;
    public GameObject singleButton;
    public GameObject settingsMenu;
    public GameObject externalButton;
    public GameObject settingsButton;
    public EventSystem eventSystem;
    public GameObject selectSound;

    private SpriteRenderer spriteRenderer;
    private float col;
    private UnityEngine.UI.Text highScore;

    void Start()
    {
        FadeOut = false;
        highScore = GetComponent<UnityEngine.UI.Text>();
        if (HighScore != 0) 
        { 
            highScore.text = "High Score: " + HighScore;
        }

        col = 0;
        spriteRenderer = background.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            settingsMenu.SetActive(false);
            menu1.SetActive(true);
            menu2.SetActive(false);
            eventSystem.SetSelectedGameObject(singleButton);
        }
    }

    IEnumerator OpacitySlider()
    {
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < 100; i++)
        {
            spriteRenderer.color = new Color(0f, 0f, 0f, col);
            col += 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }

    public void SinglePlayer()
    {
        Instantiate(selectSound, transform.position, Quaternion.identity);
        GameSettingsStaticController.SinglePlayer = true;
        gameObject.SetActive(false);
        menu2.SetActive(true);
        eventSystem.SetSelectedGameObject(externalButton);

    }

    public void BackButton()
    {
        Instantiate(selectSound, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
        settingsMenu.SetActive(false);
        menu1.SetActive(true);
        menu2.SetActive(false);
        eventSystem.SetSelectedGameObject(singleButton);
    }

    public void Settings()
    {
        Instantiate(selectSound, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
        settingsMenu.SetActive(true);
        eventSystem.SetSelectedGameObject(settingsButton);
    }

    public void SetReloadTime(float x)
    {
        loopTimeMultiplier = x;
    }

    public void SetPlayerReloadMultiplier(float x)
    {
        playerReloadRate = x;
    }

    public void SetSpawnRate(float x)
    {
        enemySpawnRate = x;
    }

    public void Easy()
    {
        Instantiate(selectSound, transform.position, Quaternion.identity);
        loopTimeMultiplier = 0.1f;
        playerReloadRate = 0.1f;
        enemySpawnRate = 0.1f;
    }

    public void Normal()
    {
        Instantiate(selectSound, transform.position, Quaternion.identity);
        loopTimeMultiplier = 1f;
        playerReloadRate = 0.75f;
        enemySpawnRate = 1f;
    }

    public void Hard()
    {
        Instantiate(selectSound, transform.position, Quaternion.identity);
        loopTimeMultiplier = 5f;
        playerReloadRate = 1f;
        enemySpawnRate = 5f;
    }

    public void Extreme()
    {
        Instantiate(selectSound, transform.position, Quaternion.identity);
        loopTimeMultiplier = 10f;
        playerReloadRate = 2f;
        enemySpawnRate = 10f;
    }

}
