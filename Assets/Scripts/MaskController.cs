using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskController : MonoBehaviour
{
    private GameObject player;
    private float startX;
    private float thisStartX;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player)
        {
            startX = player.transform.position.x;
            thisStartX = transform.position.x;
        }
    }


    void Update()
    {
        if (player) 
        { 
            transform.position = new Vector3(thisStartX + (player.transform.position.x - startX), transform.position.y);
        }

    }
}
