using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetScroller : MonoBehaviour
{

    public float parallaxAmount;
    public Vector3 startPosition;
    public GameObject sprite;
    private Rigidbody2D rb;
    private float startX;
    private float newX;

    void Start()
    {
        startPosition = transform.position;
        rb = sprite.GetComponent<Rigidbody2D>();
        startX = rb.position.x;
    }

    void Update()
    {
        newX = rb.position.x - startX;
        print(sprite);

        startPosition.x += newX / parallaxAmount;
        transform.position = startPosition;
       
    }
}
