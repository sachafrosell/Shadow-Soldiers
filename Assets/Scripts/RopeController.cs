using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeController : MonoBehaviour
{

    public GameObject ropeShooter;
    //public int maxRopeFrameCount;
    //private int ropeFrameCount;

    public LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("mouseX"))
        {
            Fire();
        }
    }

    void Fire()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 position = ropeShooter.transform.position;
        Vector3 direction = mousePosition - position;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, Mathf.Infinity);

        if (hit.collider != null)
        {
            SpringJoint2D newRope = ropeShooter.AddComponent<SpringJoint2D>();
            newRope.enableCollision = false;
            newRope.frequency = 0.2f;
            newRope.connectedAnchor = hit.point;
            newRope.enabled = true;
        }
    }
}
