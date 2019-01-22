using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunController : MonoBehaviour
{
    public Transform firePoint;
    public GameObject enemyBullet;
    public GameObject rocket;
    public GameObject overlay;
    public GameObject lightning;
    public GameObject lightningSound;
    public string weapon;
    public bool externalController = true;

    private int selector;
    private GameObject player;
    private Vector3 mousePos;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        selector = Random.Range(0, 100);
        CheckWeapon();
    }

    void CheckWeapon()
    {
        if (selector < 45)
        {
            InvokeRepeating("LoopShoot", 4f, 4f / GameSettingsStaticController.loopTimeMultiplier);
        }
        else if (selector >= 45 && selector < 50)
        {
            InvokeRepeating("LoopShoot", 4f, 15f / GameSettingsStaticController.loopTimeMultiplier);
        }
        else if (selector >= 50 && selector < 60)
        {
            InvokeRepeating("LoopShoot", 4f, 16f / GameSettingsStaticController.loopTimeMultiplier);
        }
        else if (selector >= 60 && selector < 80)
        {
            InvokeRepeating("LoopShoot", 4f, 6f / GameSettingsStaticController.loopTimeMultiplier);
        }
        else if (selector >=80 && selector <= 100)
        {
            InvokeRepeating("LoopShoot", 4f, 12f / GameSettingsStaticController.loopTimeMultiplier);
        }
    }


    void LoopShoot()
    {
        if (player)
        {
            if (selector < 60)
            {
                Instantiate(enemyBullet, firePoint.position, firePoint.rotation);
            }
            else if (selector >= 60 && selector < 80)
            {
                StartCoroutine(Burst());
            }
            else if (selector >= 80 && selector <= 100)
            {
                Instantiate(rocket, firePoint.position, firePoint.rotation);
            }
           
        }
    }

    IEnumerator Lightning()
    {
        yield return new WaitForSeconds(0.7f);
        Instantiate(lightning, new Vector3(player.transform.position.x, 2f, 0f), Quaternion.identity);
    }

    IEnumerator Burst()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(enemyBullet, firePoint.position, firePoint.rotation);
            yield return new WaitForSeconds(0.025f);
        }
    }

}
