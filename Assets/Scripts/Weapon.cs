using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform firePoint;
    public LineRenderer lineRenderer;
    private Rigidbody2D rb;
    private string direction;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
           StartCoroutine(Shoot());
        }

    }

    IEnumerator Shoot()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        Physics2D.Raycast(firePoint.position, firePoint.right);
        print(mousePos);
        print(rb.position);

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, mousePos);
        
        lineRenderer.enabled = true;

        yield return new WaitForSeconds(0.2f);

        lineRenderer.enabled = false;
    }
}
