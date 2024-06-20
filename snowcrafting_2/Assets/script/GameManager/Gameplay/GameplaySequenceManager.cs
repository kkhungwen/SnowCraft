using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplaySequenceManager : MonoBehaviour
{
    [SerializeField] private SOGameplayLevel[] levels;
    [SerializeField] private int currentLevelIndex;
    [SerializeField] private levelState currentLevelState;
    [SerializeField] private CutsceneManager cutsceneManager;
    [SerializeField] private EnemyManager enemyManager;

    private void Awake()
    {
        TestStart();
    }

    private void TestStart()
    {
        StartGameplay(0);
    }

    private void Update()
    {

    }

    public void StartGameplay(int startLevelIndex)
    {
        SetUpLevel(startLevelIndex);
        StartPreLevelCutscene();
    }

    private void StartNextLevel()
    {
        currentLevelIndex ++;
        if (currentLevelIndex <= levels.Length - 1)
        {
            SetUpLevel(currentLevelIndex);
            StartPreLevelCutscene();
        }
        else
        {
            Debug.Log("level out of range");
        }
    }

    private void SetUpLevel(int levelIndex)
    {
        currentLevelIndex = levelIndex;
        enemyManager.ResetCurrentEnemies();
    }

    private void StartLevelGameplay()
    {
        if (levels[currentLevelIndex].preSpawnEnemies.Length > 0)
        {
            enemyManager.SpawnEnemies(levels[currentLevelIndex].preSpawnEnemies);
            currentLevelState = levelState.levelGamePlay;
        }
        else
        {
            StartPostLevelCutscene();
        }
    }

    private void StartPreLevelCutscene()
    {
        if (levels[currentLevelIndex].preLevelCutscene != null)
        {
            cutsceneManager.SetTimeline(levels[currentLevelIndex].preLevelCutscene);
            cutsceneManager.PlayDirector();
            currentLevelState = levelState.preLevelCutscene;
        }
        else
        {
            StartLevelGameplay();
        }
    }

    private void StartPostLevelCutscene()
    {
        if (levels[currentLevelIndex].postLevelCutscene != null)
        {
            cutsceneManager.SetTimeline(levels[currentLevelIndex].postLevelCutscene);
            cutsceneManager.PlayDirector();
            currentLevelState = levelState.postLevelCutscene;
        }
        else
        {
            StartNextLevel();
        }
    }

    public void CutsceneFinishPlayingSignalAct()
    {
        if(currentLevelState == levelState.preLevelCutscene)
        {
            StartLevelGameplay();
        }
        else if (currentLevelState == levelState.postLevelCutscene)
        {
            StartNextLevel();
        }
    }

    public void PlayerWinSignalAct()
    {
        Debug.Log("win");
        if (currentLevelState == levelState.levelGamePlay)
        {
            StartPostLevelCutscene();
        }
    }

    public void TestPlay()
    {
        Debug.Log("play");
    }
}
