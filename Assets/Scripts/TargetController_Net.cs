using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TargetController_Net : NetworkBehaviour
{
    public float trackingSpeed;
    public bool externalController;
    public bool singlePlayer;
    public bool menu;

    private Camera cam;
    private GameObject player;
    private GameObject closestBird;
    private SpriteRenderer spriteRenderer;
    private Vector3 mousePos;
    private Vector3 transformVector;
    private Vector3 camPort;
    private Vector3 enemyPort;
    private bool enemyOnScreen;
    private float distance;
    private float horiz;
    private float vert;
    private float playerStart;
    private float targetStart;


    private void Start()
    {
        if (!isLocalPlayer)
        {
            Destroy(this);
            return;
        }

        externalController = GameSettingsStaticController.ExternalController;
        //externalController = false;
        cam = Camera.main;
        Cursor.visible = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerStart = player.transform.position.x;
        targetStart = transform.position.x;

    }

    GameObject FindClosestBird()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float d = Mathf.Infinity;
        Vector3 position = player.transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < d)
            {
                closest = go;
                d = curDistance;
            }
        }
        closestBird = closest;
        return closestBird;
    }

    void IsEnemyOnScreen()
    {
        if (closestBird)
        {
            enemyPort = cam.WorldToViewportPoint(closestBird.transform.position);

            if (enemyPort.x > 0f && enemyPort.x < 1f && enemyPort.y < 0.75f && enemyPort.y > 0.12f)
            {
                enemyOnScreen = true;
            }
            else
            {
                enemyOnScreen = false;
            }
        }
    }


    void Update()
    {
        print("blah");

        //mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        //mousePos = Camera.main.WorldToScreenPoint(Input.mousePosition);

        if (!menu && player && externalController)
        {
            FindClosestBird();
            IsEnemyOnScreen();
            //transform.position = new Vector3(targetStart + (player.transform.position.x - playerStart), transform.position.y);
        }
        if (externalController)
        {
            if (Input.GetAxis("Aim") <= 0.5f || !enemyOnScreen || !closestBird || menu)
            {
                distance = Mathf.Infinity;
                CheckController();
            }
            else
            {
                transform.position = new Vector3(closestBird.transform.position.x, closestBird.transform.position.y + 0.3f);
                horiz = Input.GetAxis("RightHorizontal");
                vert = Input.GetAxis("RightVertical");
                transform.position = new Vector3(transform.position.x + horiz * trackingSpeed * 5, transform.position.y + vert * trackingSpeed * 5);
            }
        }
        else
        {
            print("rab");
            transform.position = new Vector3(mousePos.x, mousePos.y);
        }
    }

    void CheckController()
    {
        if (externalController)
        {
            CheckAnalogXPos();
            transform.position = transformVector;
        }
        else if (!externalController)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePos.x, mousePos.y);
        }
    }


    private void FixedUpdate()
    {
        camPort = cam.WorldToViewportPoint(transform.position);

        if (camPort.x < 0)
        {
            transform.position = new Vector3(transform.position.x + 1, transform.position.y);
        }
        else if (camPort.x > 1)
        {
            transform.position = new Vector3(transform.position.x - 1, transform.position.y);
        }
    }

    private void CheckAnalogXPos()
    {
        horiz = Input.GetAxis("RightHorizontal");
        vert = Input.GetAxis("RightVertical");

        if (camPort.x < 0.95f && camPort.x > 0.05f && camPort.y < 0.8f && camPort.y > 0.25f)
        {
            transformVector = new Vector3(transform.position.x + (horiz * trackingSpeed), transform.position.y + (vert * trackingSpeed));
        }
        else
        {
            if (horiz > 0 && camPort.x < 0.95f)
            {
                transformVector = new Vector3(transform.position.x + (horiz * trackingSpeed), transform.position.y);
            }
            else if (horiz < 0 && camPort.x > 0.05f)
            {
                transformVector = new Vector3(transform.position.x + (horiz * trackingSpeed), transform.position.y);
            }

            if (vert > 0 && camPort.y < 0.8f)
            {
                transformVector = new Vector3(transform.position.x, transform.position.y + (vert * trackingSpeed));
            }
            else if (vert < 0 && camPort.y > 0.25f)
            {
                transformVector = new Vector3(transform.position.x, transform.position.y + (vert * trackingSpeed));
            }
        }
    }

}
