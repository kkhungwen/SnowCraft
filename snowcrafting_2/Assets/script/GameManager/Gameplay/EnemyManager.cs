using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GridMovementManager gridMovementManager;
    [SerializeField] private VoidSOSignal playerWinSignal;
    [SerializeField] private GameObject enemyHolder;
    [SerializeField] private List<Enemy> currentEnemies;

    public void ResetCurrentEnemies()
    {
        Debug.Log("clear");
        foreach(Enemy i in currentEnemies)
        {
            Destroy(i.gameObject);
        }
        currentEnemies.Clear();
    }

    public void SpawnEnemies(PreSpawnEnemyProperties[] preSpawnEnemies)
    {
        foreach (PreSpawnEnemyProperties i in preSpawnEnemies)
        {
            Vector2 spawnPosition = gridMovementManager.GetPositionUpdateOccupiedTiles(i.spawnTile);
            Enemy thisEnemy = Instantiate(i.enemy, spawnPosition,Quaternion.identity,enemyHolder.transform);
            currentEnemies.Add(thisEnemy);
        }
    }

    public void EnemyKnockSignalAct()
    {
        if (CheckIfAllEnemiesKnock())
        {
            playerWinSignal.Raise();
        }
    }

    private bool CheckIfAllEnemiesKnock()
    {
        bool isAllKnock = true;
        foreach(Enemy i in currentEnemies)
        {
            if(i.currentState != enemyState.knock)
            {
                isAllKnock = false;
            }
        }
        if (isAllKnock)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
