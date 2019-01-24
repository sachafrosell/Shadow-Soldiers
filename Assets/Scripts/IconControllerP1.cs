using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconControllerP1 : MonoBehaviour
{
    public bool externalController;
    public GameObject single;
    public GameObject lightning;
    public GameObject automatic;
    public GameObject rocket;
    public GameObject player;

    private Vector3 nextPos;
    private float a;
    private float b;
    private float c;
    private SpriteRenderer spriteRenderer;
    private int selector = 0;


    void Update()
    {
        if (player)
        {

            if (!spriteRenderer)
            {
                spriteRenderer = single.GetComponent<SpriteRenderer>();
                b = spriteRenderer.color.a;
                StartCoroutine(OpacitySlider(single));
            }

            //transform.position = new Vector3(player.transform.position.x - 0.75f, player.transform.position.y - 4.75f);

            if (externalController)
            {
                if (Input.GetButtonDown("Switch") && selector == 0)
                {

                    single.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, b);
                    spriteRenderer = single.GetComponent<SpriteRenderer>();
                    a = spriteRenderer.color.a;

                    selector += 1;
                    single.SetActive(false);
                    lightning.SetActive(true);
                    automatic.SetActive(false);
                    rocket.SetActive(false);
                    StartCoroutine(OpacitySlider(lightning));
                }
                else if (Input.GetButtonDown("Switch") && selector == 1)
                {
                    lightning.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, b);
                    selector += 1;
                    single.SetActive(false);
                    lightning.SetActive(false);
                    automatic.SetActive(true);
                    rocket.SetActive(false);
                    StartCoroutine(OpacitySlider(automatic));
                }
                else if (Input.GetButtonDown("Switch") && selector == 2)
                {
                    automatic.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, b);
                    selector += 1;
                    single.SetActive(false);
                    lightning.SetActive(false);
                    automatic.SetActive(false);
                    rocket.SetActive(true);
                    StartCoroutine(OpacitySlider(rocket));
                }
                else if (Input.GetButtonDown("Switch") && selector == 3)
                {
                    rocket.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, b);
                    selector = 0;
                    single.SetActive(true);
                    lightning.SetActive(false);
                    automatic.SetActive(false);
                    rocket.SetActive(false);
                    StartCoroutine(OpacitySlider(single));
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.Alpha1))
                {
                    single.SetActive(true);
                    lightning.SetActive(false);
                    automatic.SetActive(false);
                    rocket.SetActive(false);

                }
                else if (Input.GetKey(KeyCode.Alpha2))
                {
                    single.SetActive(false);
                    lightning.SetActive(true);
                    automatic.SetActive(false);
                    rocket.SetActive(false);

                }
                else if (Input.GetKey(KeyCode.Alpha3))
                {
                    single.SetActive(false);
                    lightning.SetActive(false);
                    automatic.SetActive(true);
                    rocket.SetActive(false);
                }
                else if (Input.GetKey(KeyCode.Alpha4))
                {
                    single.SetActive(false);
                    lightning.SetActive(false);
                    automatic.SetActive(false);
                    rocket.SetActive(true);

                }
            }
        }
    }

    IEnumerator OpacitySlider(GameObject obj)
    {
        spriteRenderer = obj.GetComponent<SpriteRenderer>();
        a = spriteRenderer.color.a;
        for (int i = 0; i < 50; i++)
        {
            if (i == 0)
            {
                yield return new WaitForSeconds(0.5f);
            }
            else
            {
                spriteRenderer.color = new Color(1f, 1f, 1f, a);
                a -= 0.02f;
                yield return new WaitForSeconds(0.01f);
            }

        }
    }
}
