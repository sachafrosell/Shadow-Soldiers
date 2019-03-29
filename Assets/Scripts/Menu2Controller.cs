using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu2Controller : MonoBehaviour
{

    public GameObject background;
    public GameObject selectSound;


    private SpriteRenderer spriteRenderer;
    private float col;

    void Start()
    {
        GameSettingsStaticController.FadeOut = false;
        col = 0;
        spriteRenderer = background.GetComponent<SpriteRenderer>();
    }

    IEnumerator OpacitySlider2()
    {

        for (int i = 0; i < 100; i++)
        {
            spriteRenderer.color = new Color(0f, 0f, 0f, col);
            col += 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
        if (GameSettingsStaticController.SinglePlayer)
        {
            float rand = Random.Range(0, 10);
            if (GameSettingsStaticController.Level == "Level1")
            {
                print("hitting");
                SceneManager.LoadScene("NewLevel", LoadSceneMode.Single);
            }
            else if (GameSettingsStaticController.Level == "Level2")
            {
                //print("Hittingl2");
                SceneManager.LoadScene("RedLevel", LoadSceneMode.Single);
            }
            else if (GameSettingsStaticController.Level == "Level3")
            {
                //print("Hittingl2");
                SceneManager.LoadScene("BlueLevel", LoadSceneMode.Single);
            }

        }
        else
        {
            if (GameSettingsStaticController.SplitScreen)
            {
                SceneManager.LoadScene("LocalMultiPlayer", LoadSceneMode.Single);
            }
            else
            {
                SceneManager.LoadScene("LocalMultiDisplay", LoadSceneMode.Single);
            }
           
        }
        gameObject.SetActive(false);
    }

    private void StartGame()
    {

        Instantiate(selectSound, transform.position, Quaternion.identity);
        GameSettingsStaticController.Start = true;
        GameSettingsStaticController.FadeOut = true;
        StartCoroutine(OpacitySlider2());

    }

    public void ExternalController()
    {
        GameSettingsStaticController.ExternalController = true;
        StartGame();
    }

    public void ComputerController() 
    {
        GameSettingsStaticController.ExternalController = false;
        StartGame();
    }

}
