using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using static Spawn;

namespace Assets.Scripts.Events
{
    public class LevelEvents
    {
        public static UnityAction levelLoaded;

        public static UnityAction<Spawn> levelExit;
    }
}
