using UnityEngine;
using static IObjectSetting;

public class PlayerCollisionTrigger : MonoBehaviour
{
    private GameManager GameManager;

    private void Awake()
    {
        GameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.GetComponent<IObjectSetting>().EObjectTag)
        {
            case ObjectTag.LevelEdges:
                Spawn nextSpawn;
                if (collision.gameObject.name.Equals("PreviousMapCollider"))
                {
                    nextSpawn = GameManager.LevelManager.GetExitSpawn();
                }
                else
                {
                    nextSpawn = GameManager.LevelManager.GetEntranceSpawn();
                }
                GameManager.LevelManager.TriggerLevelTransition(nextSpawn);
                break;
            case ObjectTag.None: break;
        }
    }
}
