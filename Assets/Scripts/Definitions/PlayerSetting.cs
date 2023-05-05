using UnityEngine;
using static IObjectSetting;

public class PlayerSetting : MonoBehaviour, IObjectSetting
{
    [SerializeField ]
    private ObjectTag _eObjectTag = ObjectTag.Player;

    public ObjectTag EObjectTag => _eObjectTag;
}
