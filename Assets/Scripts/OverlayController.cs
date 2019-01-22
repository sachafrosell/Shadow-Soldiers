using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class OverlayController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private GameObject player;
    private float col;

    void Start()
    {
        col = 0f;
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(OpacitySlide());
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    IEnumerator OpacitySlide()
    {
        for(int i = 0; i < 50; i++)
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, col);
            col += 0.01f;
            yield return new WaitForSeconds(0.0001f);
        }
        yield return new WaitForSeconds(1.2f);

        for (int i = 0; i < 50; i++)
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, col);
            col -= 0.01f;
            yield return new WaitForSeconds(0.0001f);
        }
        Destroy(gameObject);

    }

}
