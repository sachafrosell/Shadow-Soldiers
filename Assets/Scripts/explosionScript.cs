using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionScript : MonoBehaviour
{
    
    void Start()
    {
        StartCoroutine(selfDestruct());
    }

    IEnumerator selfDestruct() 
    {
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }


}
