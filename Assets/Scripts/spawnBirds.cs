using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBirds : MonoBehaviour
{

    public GameObject bird;

    private float random;
    private float random2;

    void Start()
    {
        //print("bird");
        Instantiate(bird, new Vector3(-150f, 5f, 0f), Quaternion.identity);
        StartCoroutine(Spawn());
    }

    void Respawn()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        random = Random.Range(5f, 10f);
        random2 = Random.Range(3f, 9f);
    }

    private IEnumerator Spawn()
    {
        Instantiate(bird, new Vector3(-30f, 5f, 0f), Quaternion.identity);
        yield return new WaitForSeconds(random2);
        Respawn();
    }

}
