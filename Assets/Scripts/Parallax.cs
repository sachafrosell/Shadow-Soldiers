using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform[] backgrounds;
    public float amount;

    private float[] scales;
    private Vector3 prevCameraPos;

    void Start()
    {
        prevCameraPos = transform.position;
        scales = new float[backgrounds.Length];

        for(int i = 0; i < scales.Length; i++) 
        {
            scales[i] = backgrounds[i].position.z * -1;
        }

    }

    private void LateUpdate()
    {
         for(int i = 0; i < backgrounds.Length; i++)
        {
            Vector3 parallax = (prevCameraPos - transform.position) * (scales[i] / amount);
            backgrounds[i].position = new Vector3(backgrounds[i].position.x - parallax.x, backgrounds[i].position.y - parallax.y, 0f);     
        }

        prevCameraPos = transform.position;
    }




}
