using Assets.Scripts.Events;
using UnityEngine;

public class GameLevel : MonoBehaviour
{
    void Start()
    {
        LevelEvents.levelLoaded?.Invoke();
    }
}
