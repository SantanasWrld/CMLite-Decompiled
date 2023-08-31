using CombatMaster.GDI;
using System.Collections.Generic;
using UnityEngine;


#nullable enable
namespace CMLiteCheat.Module_Manager.Modules.Weapon
{
  public class NoSpread : CMLiteCheat.Module_Manager.Base.Module.Module
  {
    private readonly List<(AttachmentInfo, ModificationStatsInfo)> originalValues = new List<(AttachmentInfo, ModificationStatsInfo)>();

    public NoSpread()
      : base("No Spread", "Weapon")
    {
    }

    protected override void OnEnable()
    {
      foreach (AttachmentInfo attachmentInfo in Resources.FindObjectsOfTypeAll<AttachmentInfo>())
      {
        if (!Object.op_Equality((Object) attachmentInfo.Prefab, (Object) null) && ((Object) attachmentInfo.Prefab).name.ToLower().Contains("grip"))
        {
          ModificationStatsInfo modHipFireArea = attachmentInfo.ModHipFireArea;
          this.originalValues.Add((attachmentInfo, modHipFireArea));
          attachmentInfo.ModHipFireArea = new ModificationStatsInfo()
          {
            Value = float.MinValue,
            ModStatsType = (EnumPublicSealedvaZoFiRaAdMoSpAdVeSpUnique) 10
          };
        }
      }
    }

    protected override void OnDisable()
    {
      foreach ((AttachmentInfo, ModificationStatsInfo) originalValue in this.originalValues)
        originalValue.Item1.ModHipFireArea = originalValue.Item2;
      this.originalValues.Clear();
    }
  }
}
