using UnityEngine;
using static Spawn;

public class GameState : MonoBehaviour
{
    public enum State
    {
        Start,
        Castle,
        Level,
        Menu,
    }

    public State EState;

    public Spawn PlayerSpawn;
}