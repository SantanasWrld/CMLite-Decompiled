using CombatMaster.GDI;
using System.Collections.Generic;
using UnityEngine;


#nullable enable
namespace CMLiteCheat.Module_Manager.Modules.Weapon
{
  public class NoRecoil : CMLiteCheat.Module_Manager.Base.Module.Module
  {
    private readonly List<(AttachmentInfo, ModificationStatsInfo, ModificationStatsInfo)> originalValues = new List<(AttachmentInfo, ModificationStatsInfo, ModificationStatsInfo)>();

    public NoRecoil()
      : base("No Recoil", "Weapon")
    {
    }

    protected override void OnEnable()
    {
      foreach (AttachmentInfo attachmentInfo1 in Resources.FindObjectsOfTypeAll<AttachmentInfo>())
      {
        if (!Object.op_Equality((Object) attachmentInfo1.Prefab, (Object) null) && ((Object) attachmentInfo1.Prefab).name.ToLower().Contains("grip"))
        {
          ModificationStatsInfo horizontalRecoil = attachmentInfo1.ModHorizontalRecoil;
          ModificationStatsInfo modVerticalRecoil = attachmentInfo1.ModVerticalRecoil;
          this.originalValues.Add((attachmentInfo1, horizontalRecoil, modVerticalRecoil));
          AttachmentInfo attachmentInfo2 = attachmentInfo1;
          ModificationStatsInfo modificationStatsInfo1 = new ModificationStatsInfo();
          modificationStatsInfo1.Value = float.MinValue;
          modificationStatsInfo1.ModStatsType = (EnumPublicSealedvaZoFiRaAdMoSpAdVeSpUnique) 9;
          ModificationStatsInfo modificationStatsInfo2 = modificationStatsInfo1;
          attachmentInfo2.ModHorizontalRecoil = modificationStatsInfo2;
          AttachmentInfo attachmentInfo3 = attachmentInfo1;
          modificationStatsInfo1 = new ModificationStatsInfo();
          modificationStatsInfo1.Value = float.MinValue;
          modificationStatsInfo1.ModStatsType = (EnumPublicSealedvaZoFiRaAdMoSpAdVeSpUnique) 8;
          ModificationStatsInfo modificationStatsInfo3 = modificationStatsInfo1;
          attachmentInfo3.ModVerticalRecoil = modificationStatsInfo3;
        }
      }
    }

    protected override void OnDisable()
    {
      foreach ((AttachmentInfo attachmentInfo, ModificationStatsInfo modificationStatsInfo1, ModificationStatsInfo modificationStatsInfo2) in this.originalValues)
      {
        attachmentInfo.ModHorizontalRecoil = modificationStatsInfo1;
        attachmentInfo.ModVerticalRecoil = modificationStatsInfo2;
      }
      this.originalValues.Clear();
    }
  }
}
