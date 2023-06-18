using Assets.Scripts.Definitions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Combat
{
  public class StatModifier
  {
    public readonly float Value;

    public readonly EStatModifier Type;

    public readonly object Source;

    public StatModifier(float value, EStatModifier type, object source)
    {
      Value = value;
      Type = type;
      Source = source;
    }

    public StatModifier(float value, EStatModifier type) : this(value, type, null) { }
  }
}