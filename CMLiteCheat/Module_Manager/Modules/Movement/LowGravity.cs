using CMLiteCheat.Module_Manager.Base;
using CombatMaster.GDI;
using System.Collections.Generic;
using UnityEngine;


#nullable enable
namespace CMLiteCheat.Module_Manager.Modules.Movement
{
  public class LowGravity : CMLiteCheat.Module_Manager.Base.Module.Module
  {
    private readonly Dictionary<OperatorsGdInfoSection, float> savedOperators = new Dictionary<OperatorsGdInfoSection, float>();

    public LowGravity()
      : base("Low Gravity", "Movement")
    {
    }

    protected override void OnEnable()
    {
      ModuleUtils.DisableModule<JumpFly>();
      foreach (OperatorsGdInfoSection key in Resources.FindObjectsOfTypeAll<OperatorsGdInfoSection>())
      {
        this.savedOperators.Add(key, key.GravityForce);
        key.GravityForce = 1f / 500f;
      }
    }

    protected override void OnDisable()
    {
      foreach (KeyValuePair<OperatorsGdInfoSection, float> savedOperator in this.savedOperators)
        savedOperator.Key.GravityForce = savedOperator.Value;
    }
  }
}
