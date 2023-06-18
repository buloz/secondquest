using UnityEngine;

namespace Assets.Scripts.Combat
{
  public abstract class Combat : MonoBehaviour
  {
    #region Properties

    protected CombatStats _stats;

    public LayerMask Enemies;
    #endregion

    void Start()
    {
      gameObject.TryGetComponent(out _stats);

      _stats.Reset();

      Init();
    }

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
      if (_stats.CurrentHealthPoints <= 0)
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
}