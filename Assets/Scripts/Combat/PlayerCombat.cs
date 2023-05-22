using UnityEngine;

public class PlayerCombat : Combat
{
    #region CustomMethods

    protected override void Attack(GameObject target)
    {
        if (_stats.AttackTime <= 0)
        {
            _stats.AttackTime = 1.0f / _stats.AttackSpeed;
            target.TryGetComponent(out Combat targetCombat);
            targetCombat.Damage(_stats.AttackDamage);
        }
    }
    #endregion
}
