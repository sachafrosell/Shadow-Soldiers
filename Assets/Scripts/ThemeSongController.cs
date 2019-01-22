using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeSongController : MonoBehaviour
{

    private AudioSource audioSource;
    private float vol;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(VolumeFadeIn());
        vol = 0f;
    }

    IEnumerator VolumeFadeIn()
    {
        for(int i = 0; i < 100; i++)
        {
            audioSource.volume = vol;
            vol += 0.01f;
            yield return new WaitForSeconds(0.1f);
        }
        audioSource.volume = 1f;
    }
}
