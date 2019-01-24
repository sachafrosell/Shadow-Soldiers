using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameSettingsStaticController
{
    public static float loopTimeMultiplier = 1;

    public static bool Level { get; set; }

    public static bool SplitScreen { get; set; }

    public static bool Start { get; set; }

    public static float enemySpawnRate = 1;

    public static float playerReloadRate = 0.75f;

    public static int hits = 0;

    public static bool birds = false;

    public static bool ExternalController { get; set; }

    public static bool SinglePlayer { get; set; }

    public static bool FadeOut { get; set; }

}
