using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GunController_Net : NetworkBehaviour
{
    public Transform firePoint;
    public GameObject onlineBullet;
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
    private Vector3 targetPos;
    private Vector3 thisPos;
    //private Shake shake;
    private int selector;
    private int gunBurst;
    private bool active;
    private float angle;
    private string[] weapons;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Target");
        externalController = GameSettingsStaticController.ExternalController;
        active = true;
        selector = 0;
        gunBurst = 0;
        weapons = new string[4];
        weapons[0] = "gun";
        weapons[1] = "thunder";
        weapons[2] = "burst";
        weapons[3] = "rocket";
        //shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }

    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        CheckWeapon();

        if (Input.GetAxis("Fire1") > 0.5f)
        {
            CmdShoot();
        }
    }

    private void CalculateAngle()
    {
        targetPos = target.transform.position;
        thisPos = firePoint.transform.position;
        targetPos.x = targetPos.x - thisPos.x;
        targetPos.y = targetPos.y - thisPos.y;
        angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        //transform.Rotate(0f, 0f, angle);
    }

    private void CheckWeapon()
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

    [Command]
    public void CmdShoot()
    {
        switch (weapon)
        {
            case "gun":
                if (active)
                {
                    //print("sshoot");
                    CalculateAngle();
                    //print(targetPos);
                    GameObject go = Instantiate(onlineBullet, firePoint.position, Quaternion.Euler(0f, 0f, angle));
                    NetworkServer.Spawn(go);
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
        yield return new WaitForSeconds(time * GameSettingsStaticController.playerReloadRate);
        active = true;
    }


    IEnumerator Lightning()
    {
        //shake.CamShake();
        yield return new WaitForSeconds(0.7f);
        Instantiate(lightning, new Vector3(target.transform.position.x, 2f, 0f), Quaternion.identity);
    }

    IEnumerator Burst()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(onlineBullet, firePoint.position, firePoint.rotation);
            yield return new WaitForSeconds(0.025f);
        }
    }

}
