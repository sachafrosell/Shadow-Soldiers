using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GameSettingsStaticController;

public class SliderController : MonoBehaviour
{
    public Slider enemyReload;
    public Slider enemySpawn;
    public Slider playerReload;

    void Update()
    {
        enemyReload.value = loopTimeMultiplier;
        enemySpawn.value = enemySpawnRate;
        playerReload.value = playerReloadRate;
    }
}
