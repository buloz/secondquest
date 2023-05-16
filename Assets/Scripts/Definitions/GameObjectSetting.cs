using UnityEngine;
using static IObjectSetting;

public class GameObjectSetting : MonoBehaviour, IObjectSetting
{
    [SerializeField]
    private ObjectTag _eObjectTag = ObjectTag.None;

    public ObjectTag EObjectTag => _eObjectTag;
}
