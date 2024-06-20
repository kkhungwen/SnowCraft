using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

[System.Serializable]
public class PreSpawnEnemyProperties
{
    public Enemy enemy;
    public Vector2Int spawnTile;
}

[CreateAssetMenu]
public class SOGameplayLevel : ScriptableObject
{
    public PreSpawnEnemyProperties[] preSpawnEnemies;
    public TimelineAsset preLevelCutscene;
    public TimelineAsset postLevelCutscene;
}
