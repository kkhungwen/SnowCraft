using UnityEngine;

public static class Settings
{
    //////////////////////// GAME ///////////////////////////////////////
    public static float stunTime;

    public static int enemy1MovableTilesConstrainMinY;
    public static int enemy1MovableTilesConstrainMaxY;

    public static int enemy2MovableTilesConstrainMinY;
    public static int enemy2MovableTilesConstrainMaxY;

    public static int enemy3MovableTilesConstrainMinY;
    public static int enemy3MovableTilesConstrainMaxY;

    public static float playerConfinementMinX;
    public static float playerConfinementMaxX;
    public static float playerConfinementMinY;
    public static float playerConfinementMaxY;

    public static float enemyConfinementMinX;
    public static float enemyConfinementMaxX;
    public static float enemyConfinementMinY;
    public static float enemyConfinementMaxY;

    public static float enemy1ConfinementMinX;
    public static float enemy1ConfinementMaxX;
    public static float enemy1ConfinementMinY;
    public static float enemy1ConfinementMaxY;

    public static float enemy2ConfinementMinX;
    public static float enemy2ConfinementMaxX;
    public static float enemy2ConfinementMinY;
    public static float enemy2ConfinementMaxY;

    public static float enemy3ConfinementMinX;
    public static float enemy3ConfinementMaxX;
    public static float enemy3ConfinementMinY;
    public static float enemy3ConfinementMaxY;


    //////////////////////// TAGS ///////////////////////////////////////
    public static string enemyTag;
    public static string playerTag;
    public static string playerBlockTag;
    public static string enemyBlockTag;
    public static string playerLaunchableTag;
    public static string enemyLaunchableTag;


    //////////////////////// ANIMATOR'S PARAMETERS ///////////////////////////////////////
    // UNIVERSAL //
    public static int isAttacking;
    public static int isStunning;
    public static int isKnocking;

    // ENEMY //
    public static int isMoving;

    // p1 //
    public static int isCharging;

    // Attack Phase //
    public static int isAttacking_1;

    // Block Phase //
    public static int block_hp_decrease;


    //////////////////////// TOUCH ///////////////////////////////////////
    public static float tapThreshold;



    static Settings()
    {
        //////////////////////// GAME ///////////////////////////////////////
        stunTime = 5;

        enemy1MovableTilesConstrainMinY = 3;
        enemy1MovableTilesConstrainMaxY = 4;

        enemy2MovableTilesConstrainMinY = 1;
        enemy2MovableTilesConstrainMaxY = 4;

        enemy3MovableTilesConstrainMinY = 0;
        enemy3MovableTilesConstrainMaxY = 1;

        playerConfinementMinX = -2.8f;
        playerConfinementMaxX = 2.8f;
        playerConfinementMinY = -6;
        playerConfinementMaxY = 0;

        enemyConfinementMinX = -2.8f;
        enemyConfinementMaxX = 2.8f;
        enemyConfinementMinY = 0;
        enemyConfinementMaxY = 6;

        enemy1ConfinementMinX = -2.8f;
        enemy1ConfinementMaxX = 2.8f;
        enemy1ConfinementMinY = 4;
        enemy1ConfinementMaxY = 6;

        enemy2ConfinementMinX = -2.8f;
        enemy2ConfinementMaxX = 2.8f;
        enemy2ConfinementMinY = 1;
        enemy2ConfinementMaxY = 4;

        enemy3ConfinementMinX = -2.8f;
        enemy3ConfinementMaxX = 2.8f;
        enemy3ConfinementMinY = 0;
        enemy3ConfinementMaxY = 2;

        //////////////////////// TAGS ///////////////////////////////////////
        enemyTag = "Enemy";
        playerTag = "Player";
        enemyBlockTag = "Enemy Block";
        playerBlockTag = "Player Block";
        playerLaunchableTag = "Player Launchable";
        enemyLaunchableTag = "Enemy Launchable";

        //////////////////////// ANIMATOR'S PARAMETERS ///////////////////////////////////////
        // UNIVERSAL //
        isAttacking = Animator.StringToHash("isAttacking");
        isStunning = Animator.StringToHash("isStunning");
        isKnocking = Animator.StringToHash("isKnocking");

        // ENEMY //
        isMoving = Animator.StringToHash("isMoving");

        // p1 //
        isCharging = Animator.StringToHash("isCharging");

        // attack phase //
        isAttacking_1 = Animator.StringToHash("isAttacking_1");

        // block //
        block_hp_decrease = Animator.StringToHash("block_hp_decrease");


        //////////////////////// TOUCH ///////////////////////////////////////
        tapThreshold = 0.1f;
    }
}
