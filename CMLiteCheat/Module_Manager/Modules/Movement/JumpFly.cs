using CMLiteCheat.Module_Manager.Base;
using CombatMaster.GDI;
using System;
using System.Collections.Generic;
using UnityEngine;


#nullable enable
namespace CMLiteCheat.Module_Manager.Modules.Movement
{
  public class JumpFly : CMLiteCheat.Module_Manager.Base.Module.Module
  {
    private readonly Dictionary<OperatorsGdInfoSection, Tuple<float, float>> savedOperators = new Dictionary<OperatorsGdInfoSection, Tuple<float, float>>();

    public JumpFly()
      : base("Jump Fly", "Movement")
    {
    }

    protected override void OnEnable()
    {
      ModuleUtils.DisableModule<LowGravity>();
      foreach (OperatorsGdInfoSection key in Resources.FindObjectsOfTypeAll<OperatorsGdInfoSection>())
      {
        this.savedOperators.Add(key, new Tuple<float, float>(key.JumpPower, key.GravityForce));
        key.JumpPower = 0.5f;
        key.GravityForce = 1f / 1000f;
      }
    }

    protected override void OnDisable()
    {
      foreach (KeyValuePair<OperatorsGdInfoSection, Tuple<float, float>> savedOperator in this.savedOperators)
      {
        savedOperator.Key.JumpPower = savedOperator.Value.Item1;
        savedOperator.Key.GravityForce = savedOperator.Value.Item2;
      }
    }
  }
}
