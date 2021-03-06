﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Gun : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullit;
    public GameObject rocket;
    public GameObject overlay;
    public GameObject lightning;
    public GameObject lightningSound;
    public float thunderReloadTime;
    public float burstReloadTime;
    public float gunReloadTime;
    public float rocketReloadTime;
    public string weapon;
    public bool externalController;

    private GameObject target;
    private Vector3 mousePos;
    private Shake shake;
    private int selector;
    private int gunBurst;
    private bool active;
    private string[] weapons;

    void Start()
    {
        active = true;
        selector = 0;
        gunBurst = 0;
        weapons = new string[4];
        weapons[0] = "gun";
        weapons[1] = "thunder";
        weapons[2] = "burst";
        weapons[3] = "rocket";
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
        target = GameObject.FindGameObjectWithTag("Target2");

    }

    void Update()
    {
        CheckWeapon();
        if (Input.GetAxis("Fire1") > 0.5f)
        {
            Shoot();
        }
    }

    private void CheckWeapon()
    {
        if (externalController)
        {
            if (Input.GetButtonDown("Switch") && selector < 3)
            {
                selector += 1;
                active = true;
                weapon = weapons[selector];
            }
            else if (Input.GetButtonDown("Switch") && selector >= 3)
            {
                active = true;
                weapon = "gun";
                selector = 0;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                active = true;
                weapon = "gun";
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                active = true;
                weapon = "thunder";
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                active = true;
                weapon = "burst";
            }
        }
    }


    void Shoot()
    {
        switch (weapon)
        {
            case "gun":
                if (active)
                {
                    Instantiate(bullit, firePoint.position, firePoint.rotation);
                    StartCoroutine(Reload(gunReloadTime));
                }
                break;
            case "burst":
                if (active)
                {
                    StartCoroutine(Burst());
                    StartCoroutine(Reload(burstReloadTime));
                }
                break;
            case "thunder":
                if (active)
                {
                    StartCoroutine(Reload(thunderReloadTime));
                    Instantiate(lightningSound, new Vector3(mousePos.x, mousePos.y, 0f), Quaternion.identity);
                    Instantiate(overlay, new Vector3(0f, 0f, 0f), Quaternion.identity);
                    StartCoroutine(Lightning());
                }
                break;
            case "rocket":
                if (active)
                {
                    Instantiate(rocket, firePoint.position, firePoint.rotation);
                    StartCoroutine(Reload(rocketReloadTime));
                }
                break;
        }

    }

    IEnumerator Reload(float time)
    {
        active = false;
        yield return new WaitForSeconds(time);
        active = true;
    }


    IEnumerator Lightning()
    {
        shake.CamShake();
        yield return new WaitForSeconds(0.7f);
        Instantiate(lightning, new Vector3(target.transform.position.x, 2f, 0f), Quaternion.identity);
    }

    IEnumerator Burst()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(bullit, firePoint.position, firePoint.rotation);
            yield return new WaitForSeconds(0.025f);
        }
    }

}
