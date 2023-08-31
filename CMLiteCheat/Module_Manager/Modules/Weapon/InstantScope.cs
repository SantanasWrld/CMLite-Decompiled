// Decompiled with JetBrains decompiler
// Type: CMLiteCheat.Module_Manager.Modules.Weapon.InstantScope
// Assembly: CMLiteCheat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AE1CDB50-B03D-44B2-BD55-9FBE67DA42B2
// Assembly location: C:\Users\cwpen\Downloads\CMLiteCheat_unknowncheats.me_.dll

using CombatMaster.GDI;
using System.Collections.Generic;
using UnityEngine;


#nullable enable
namespace CMLiteCheat.Module_Manager.Modules.Weapon
{
  public class InstantScope : CMLiteCheat.Module_Manager.Base.Module.Module
  {
    private readonly List<(AttachmentInfo, ModificationStatsInfo)> originalValues = new List<(AttachmentInfo, ModificationStatsInfo)>();

    public InstantScope()
      : base("Instant Scope", "Weapon")
    {
    }

    protected override void OnEnable()
    {
      foreach (AttachmentInfo attachmentInfo in Resources.FindObjectsOfTypeAll<AttachmentInfo>())
      {
        if (!Object.op_Equality((Object) attachmentInfo.Prefab, (Object) null) && ((Object) attachmentInfo.Prefab).name.ToLower().Contains("scope"))
        {
          ModificationStatsInfo modAdsTime = attachmentInfo.ModAdsTime;
          this.originalValues.Add((attachmentInfo, modAdsTime));
          attachmentInfo.ModAdsTime = new ModificationStatsInfo()
          {
            Value = float.MinValue,
            ModStatsType = (EnumPublicSealedvaZoFiRaAdMoSpAdVeSpUnique) 3
          };
        }
      }
    }

    protected override void OnDisable()
    {
      foreach ((AttachmentInfo, ModificationStatsInfo) originalValue in this.originalValues)
        originalValue.Item1.ModAdsTime = originalValue.Item2;
      this.originalValues.Clear();
    }
  }
}
