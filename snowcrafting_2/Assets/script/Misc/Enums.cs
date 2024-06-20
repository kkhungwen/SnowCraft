public enum characterState
{
    gameplay,
    cutscene
}

public enum p1State
{
    idle,
    attack,
    stun,
    charge,
    knock
}

public enum playerState
{
    idle,
    attack,
    stun,
    charge,
    knock
}

public enum enemyState
{
    idle,
    move,
    attack,
    stun,
    knock
}

public enum snowballState
{
    defult,
    playerBall,
    enemyBall
}

public enum cutsceneState
{
    play,
    stop,
    pauseWaitForInput
}

public enum playerInputActionMapEnum
{
    UI,
    InGame,
    Cutscene,
    none
}

public enum SceneEnum
{
    MainMenu,
    InGameScene
}

public enum levelState
{
    preLevelCutscene,
    levelGamePlay,
    postLevelCutscene
}