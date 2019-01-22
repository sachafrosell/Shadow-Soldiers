using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningSoundController : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DestroySelf());
    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
