using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerCombat : Combat
{
    #region CustomMethods

    protected override void Init()
    {
    }

    protected override void Attack(GameObject target)
    {
        if (_stats.AttackTime <= 0)
        {
            _stats.AttackTime = 1.0f / _stats.AttackSpeed;
            target.TryGetComponent(out Combat targetCombat);
            targetCombat.Damage(_stats.AttackDamage);
        }
    }

    protected override void Die()
    {
    }
    #endregion
}
