using UnityEngine.Events;

namespace Assets.Scripts.Events
{
    public class LevelEvents
    {
        public static UnityAction levelLoaded;

        public static UnityAction<Spawn> levelExit;
    }
}
