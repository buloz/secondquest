using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Combat : MonoBehaviour
{
    #region Properties

    protected CombatStats _stats;

    public LayerMask Enemies;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        gameObject.TryGetComponent(out _stats);

        _stats.Reset();

        Init();
    }

    // Update is called once per frame
    void Update()
    {
        _stats.AttackTime -= _stats.AttackTime > 0 ? Time.deltaTime : 0.0f;
    }

    #region EmbeddedMethods
    public void OnCollisionStay2D(Collision2D collision)
    {
        if (Enemies == (Enemies | (1 << collision.gameObject.layer)))
        {
            Attack(collision.gameObject);
        }
    }

    #endregion

    #region CustomMethods
    protected virtual void Init() { }

    protected abstract void Attack(GameObject target);

    public virtual void Damage(int value)
    {
        _stats.Damage(value);
        if(_stats.CurrentHealthPoints <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Debug.Log($"{gameObject.name} is dying.");
        Destroy(gameObject);
    }
    #endregion
}
