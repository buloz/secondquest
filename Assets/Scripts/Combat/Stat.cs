using Assets.Scripts.Definitions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Combat
{
  public class Stat
  {
    private float _value;

    public float Base;

    private readonly List<StatModifier> _statModifiers;

    private bool _needUpdate = true;

    public Stat(float baseValue)
    {
      Base = baseValue;
      _statModifiers = new List<StatModifier>();
    }

    public float Value
    {
      get
      {
        if (_needUpdate)
        {
          _value = CalculateFinalValue();
          _needUpdate = false;
        }
        return _value;
      }
    }

    public void AddModifier(StatModifier mod)
    {
      _needUpdate = true;
      _statModifiers.Add(mod);
    }

    public bool RemoveModifier(StatModifier mod)
    {
      _needUpdate = true;
      return _statModifiers.Remove(mod);
    }

    private float CalculateFinalValue()
    {
      float finalValue = Base;

      float additivePercentageFactor = 1.0f;

      foreach (StatModifier mod in _statModifiers.OrderBy(mod => mod.Type))
      {
        switch (mod.Type)
        {
          case EStatModifier.Flat:
            finalValue += mod.Value;
            break;
          case EStatModifier.Percentage:
            finalValue *= 1 + mod.Value;
            break;
          case EStatModifier.AdditivePercentage:
            additivePercentageFactor += mod.Value;
            break;
          default:
            break;
        }
        finalValue *= 1 + additivePercentageFactor;
      }

      return (float)Math.Round(finalValue, 4);
    }

  }
}