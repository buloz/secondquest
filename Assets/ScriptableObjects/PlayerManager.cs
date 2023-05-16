using Assets.Scripts.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static Spawn;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerPrefab;

    public GameObject Player;

    public GameState GameState { get; set; }

    public void OnEnable()
    {
        LevelEvents.levelLoaded += Spawn;
        LevelEvents.levelExit += OnLevelExit;
    }

    private void OnDisable()
    {
        LevelEvents.levelLoaded -= Spawn;
        LevelEvents.levelExit -= OnLevelExit;
    }

    protected void Spawn()
    {
        if(GameState?.PlayerSpawn != null)
        {
            Player = Instantiate(_playerPrefab, GameState.PlayerSpawn.transform.position, Quaternion.identity);
        }
        else
        {
            Player = Instantiate(_playerPrefab, this.GetComponentInParent<LevelManager>().GetEntranceSpawn().transform.position, Quaternion.identity);
        }

        if(Player)
        {
            PlayerEvents.onPlayerSpawn?.Invoke(Player.transform);
        }
        else
        {
            throw new MissingReferenceException("No player instance. Might have failed to spawn.");
        }    
    }

    private void OnLevelExit(Spawn _)
    {
        Destroy(Player);
    }
}
