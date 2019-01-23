using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu2Controller : MonoBehaviour
{

    public GameObject background;
    //public GameObject menu2;

    private SpriteRenderer spriteRenderer;
    private float col;

    void Start()
    {
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
            SceneManager.LoadScene("NewLevel", LoadSceneMode.Single);
        }
        else
        {
            //SceneManager.LoadScene("MultiPlayer", LoadSceneMode.Single);
            SceneManager.LoadScene("LocalMultiDisplay", LoadSceneMode.Single);

        }
        gameObject.SetActive(false);
    }

    private void StartGame()
    {
        //SceneManager.LoadScene("Level1", LoadSceneMode.Single);
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
