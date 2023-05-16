using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Events
{
    public class PlayerEvents
    {
        public static UnityAction<Transform> onPlayerSpawn;
        public static UnityAction onPlayerDestroy;
    }
}
