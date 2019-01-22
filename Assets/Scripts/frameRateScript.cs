using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frameRateScript : MonoBehaviour
{
    void Awake()
    {
        // 0 for no sync, 1 for panel refresh rate, 2 for 1/2 panel rate
        QualitySettings.vSyncCount = 1;
    }
}
