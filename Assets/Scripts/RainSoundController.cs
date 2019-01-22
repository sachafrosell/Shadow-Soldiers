using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainSoundController : MonoBehaviour
{
    private AudioSource audioSource;
    private float vol;
    private float c;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        vol = audioSource.volume;
    }

    void Update()
    {
        if (GameSettingsStaticController.FadeOut)
        {
            StartCoroutine(FadeOut());
        }
    }

    IEnumerator FadeOut()
    {

        for (int i = 0; i < 100; i++)
        {
            audioSource.volume = vol;
            vol -= 0.01f;
            yield return new WaitForSeconds(0.1f);
        }
    }


}
