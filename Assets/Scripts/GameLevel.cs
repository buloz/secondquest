using Assets.Scripts.Events;
using UnityEngine;

public class GameLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LevelEvents.levelLoaded?.Invoke();
    }
}
