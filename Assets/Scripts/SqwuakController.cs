using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SqwuakController : MonoBehaviour
{
    public AudioSource audioSource;

    private float rand;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rand = Random.Range(0.7f, 1.2f);
        audioSource.pitch = rand;
        StartCoroutine(DestroySelf());
    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

}
