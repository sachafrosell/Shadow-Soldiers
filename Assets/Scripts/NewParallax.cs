using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewParallax : MonoBehaviour
{

    public float parallaxAmount;

    private GameObject player;
    private Vector3 startPos;
    private float startPosX;
    private float backStartX;
    private float pSum;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player) 
        { 
            startPos = player.transform.position;
            startPosX = startPos.x;
            backStartX = transform.position.x;
            pSum = (1 / transform.position.z) * parallaxAmount;
        }

    }

    void Update()
    {
        if (player) 
        { 
            transform.position = new Vector3(backStartX + ((player.transform.position.x - startPosX) * (pSum)), transform.position.y, transform.position.z);
        }

    }
}
