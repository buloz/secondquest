using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatStats : MonoBehaviour
{
    #region Properties
    public float AttackSpeed;

    public float AttackRange;

    public float AttackTime;

    public int AttackDamage;

    public int MaxHealthPoints;
    [SerializeField] public int CurrentHealthPoints { get; private set; }
    #endregion

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Public Methods
    public void Reset()
    {
        CurrentHealthPoints = MaxHealthPoints;
        AttackTime = 0.0f;
    }

    public void Damage(int value)
    {
        CurrentHealthPoints -= value <= CurrentHealthPoints ? value : CurrentHealthPoints;
        Debug.Log($"Entity {gameObject.name} took {value} dmg. Remaining : {CurrentHealthPoints}/{MaxHealthPoints}");
    }
    #endregion

}
