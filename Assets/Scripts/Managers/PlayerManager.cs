using Assets.Scripts.Events;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerPrefab;

    public GameObject Player;

    public GameState GameState { get; set; }

    public void OnEnable()
    {
        CreatePlayerInstance();
        LevelEvents.levelLoaded += Spawn;
        LevelEvents.levelExit += OnLevelExit;
    }

    private void OnDisable()
    {
        LevelEvents.levelLoaded -= Spawn;
        LevelEvents.levelExit -= OnLevelExit;
    }

    protected void CreatePlayerInstance()
    {
        if (GameState?.PlayerSpawn != null)
        {
            Player = Instantiate(_playerPrefab, GameState.PlayerSpawn.transform.position, Quaternion.identity);
        }
        else
        {
            Player = Instantiate(_playerPrefab, this.GetComponentInParent<LevelManager>().GetEntranceSpawn().transform.position, Quaternion.identity);
        }

        if (Player)
        {
            PlayerEvents.onPlayerSpawn?.Invoke(Player.transform);
        }
        else
        {
            throw new MissingReferenceException("No reference of player instance.");
        }
    }

    protected void Spawn()
    {
        Spawn spawnPoint;
        if (GameState?.PlayerSpawn != null)
        {
            spawnPoint = GameState.PlayerSpawn;
        }
        else
        {
            spawnPoint = this.GetComponentInParent<LevelManager>().GetEntranceSpawn();
        }
        Player.transform.position = spawnPoint.transform.position;
        Player.transform.rotation = spawnPoint.transform.rotation;
        Player.transform.localScale = spawnPoint.transform.localScale;
    }

    private void OnLevelExit(Spawn _)
    {

    }
}
