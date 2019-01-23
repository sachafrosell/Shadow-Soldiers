using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasOpacityController : MonoBehaviour
{

    private float alpha;
    private CanvasGroup canvasGroup;

    void Start()
    {
        alpha = 1f;
        canvasGroup = GetComponent<CanvasGroup>();
    }

    void Update()
    {
        if (GameSettingsStaticController.Start)
        {
            StartCoroutine(OpacitySlider());
        }
    }

    IEnumerator OpacitySlider()
    {
        yield return new WaitForSeconds(0.7f);
        for (int i = 0; i < 100; i++)
        {
            canvasGroup.alpha = alpha;
            yield return new WaitForSeconds(0.5f);
            alpha -= 0.1f;
        }
    }
}
