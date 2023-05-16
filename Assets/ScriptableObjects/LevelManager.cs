using Assets.Scripts.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Spawn;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private Spawn[] PlayerSpawns;

    [SerializeField]
    private GameObject[] Levels;

    private GameObject _currentLevel;

    public GameState GameState { get; set; }

    public void OnEnable()
    {
        LevelEvents.levelExit += OnLevelExit;
        _currentLevel = Instantiate(Levels[0]);
    }

    private void OnDisable()
    {
        LevelEvents.levelExit -= OnLevelExit;
        Destroy(_currentLevel);
    }

    public Spawn GetEntranceSpawn()
    {
        return GetSpawns(SpawnTag.Entrance)[0];
    }

    public Spawn GetExitSpawn()
    {
        return GetSpawns(SpawnTag.Exit)[0];
    }

    public Spawn[] GetSpawns(SpawnTag tag)
    {
        Spawn[] spawns = PlayerSpawns.Where(spawn => spawn.GetComponent<Spawn>().ESpawnTag == tag).ToArray();
        return spawns;
    }

    private void OnLevelExit(Spawn nextSpawn)
    {
        GameState.PlayerSpawn = nextSpawn;
        Destroy(_currentLevel);
        if (nextSpawn == GetEntranceSpawn())
        {
            _currentLevel = Instantiate(Levels[1]);
        }
        else if (nextSpawn == GetExitSpawn())
        {
            _currentLevel = Instantiate(Levels[0]);
        }
    }

    public void TriggerLevelTransition(Spawn nextSpawn)
    {
        LevelEvents.levelExit?.Invoke(nextSpawn);
    }
}
