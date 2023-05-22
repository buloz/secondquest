using UnityEngine;
using static IObjectSetting;

public class EnnemySetting : MonoBehaviour, IObjectSetting
{
    [SerializeField ]
    private ObjectTag _eObjectTag = ObjectTag.Foe;

    public ObjectTag EObjectTag => _eObjectTag;
}
