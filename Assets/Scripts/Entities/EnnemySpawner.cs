using System.Collections.Generic;
using UnityEngine;

public class EnnemySpawner : MonoBehaviour
{
    public List<Spawn> Spawners;
    
    public GameObject[] EnnemyPrefabs;

    void Start()
    {
        List<Spawn> availableSpawners = Spawners;

        int ennemiesNumber = Random.Range(1,6);

        for (int i=0; i<ennemiesNumber; i++)
        {
            GameObject prefab = EnnemyPrefabs[Random.Range(0, EnnemyPrefabs.Length)];
            Spawn spawn = availableSpawners[Random.Range(0, availableSpawners.Count)];
            Instantiate(prefab, spawn.SpawnPoint);
            availableSpawners.Remove(spawn);        
        }
    }
}
