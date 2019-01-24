using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundPositionControllerP2 : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player2");
    }

    void Update()
    {
        if (player)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y);
        }
    }
}
