using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarControllerP1P2 : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            transform.position = new Vector3(player.transform.position.x + 0.8f, 8.5f);
        }
    }
}
