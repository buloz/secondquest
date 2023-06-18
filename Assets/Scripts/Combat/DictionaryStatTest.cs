using UnityEngine;
using Assets.Scripts.Definitions;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Reflection;

namespace Assets.Scripts.Combat
{
  public class DictionaryStatTest : MonoBehaviour
  {
    #region Properties

    public Dictionary<EStat, Stat> Stats;

    [SerializeField]
    private float AttackDamage;

    [SerializeField]
    private float AttackSpeed;

    [SerializeField]
    private float MaxHealthPoints;

    [SerializeField]
    private float CurrentHealthPoints;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
      Stats = new Dictionary<EStat, Stat>();
      foreach (PropertyInfo prop in this.GetType().GetProperties().Where(p => Enum.GetNames(typeof(EStat)).Contains(p.Name)))
      {
        if (Enum.TryParse(prop.Name, out EStat statType))
        {
          Stats.Add(statType, new Stat((float)prop.GetValue(this)));
        }
      }
    }

    // Update is called once per frame
    void Update()
    {

    }

    #region Public Methods
    public void Reset()
    {
      // CurrentHealthPoints = MaxHealthPoints;
      // AttackTime = 0.0f;
    }

    public void Damage(int value)
    {
      // CurrentHealthPoints -= value <= CurrentHealthPoints ? value : CurrentHealthPoints;
      // Debug.Log($"Entity {gameObject.name} took {value} dmg. Remaining : {CurrentHealthPoints}/{MaxHealthPoints}");
    }
    #endregion

  }
}