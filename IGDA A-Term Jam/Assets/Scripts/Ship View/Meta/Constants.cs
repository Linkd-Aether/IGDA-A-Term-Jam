using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
    // Constants
    public static int DESPAWN_ZONE = -12;

    // Testing
    public static bool spawning = false;
    public static bool wavePhysics = false;
    public static bool oceanPhysics = false;
    public static bool randomSetLocation = false;

    // Values for Ship View pane
    public static float rockSpd = .8f;
    public static float rockDmgMultiplier = 10f;
    public static float rockLeakMultiplier = 1f;
    public static float rockSpawnTime = 3f;

    public static float oceanSpd = 1.2f;
    
    public static float waveSpd = 1.5f;
    public static float waveSpawnTime = 9f;
    public static float waveFloodMultiplier = 20f;

    public static float enemySpawnTime = 25f;
}
