using UnityEngine;

public class Spawn : MonoBehaviour
{
    public enum SpawnTag
    {
        None = 0,
        Entrance = 1,
        Exit = 2,
        Centrer = 3,
        Ennemy = 4,
    }

    public SpawnTag ESpawnTag;

    public Transform SpawnPoint;
}
