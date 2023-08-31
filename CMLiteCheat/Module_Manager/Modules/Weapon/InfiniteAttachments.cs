using CombatMaster.GDI;
using System.Collections.Generic;
using UnityEngine;


#nullable enable
namespace CMLiteCheat.Module_Manager.Modules.Weapon
{
  public class InfiniteAttachments : CMLiteCheat.Module_Manager.Base.Module.Module
  {
    private readonly List<(AttachmentInfo, ModificationStatsInfo)> originalValues = new List<(AttachmentInfo, ModificationStatsInfo)>();

    public InfiniteAttachments()
      : base("Infinite Attachments", "Weapon")
    {
    }

    protected override void OnEnable()
    {
      foreach (WeaponsGdInfoSection weaponsGdInfoSection in Resources.FindObjectsOfTypeAll<WeaponsGdInfoSection>())
        weaponsGdInfoSection.AttachmentsMaximum = (ushort) 10000;
    }

    protected override void OnDisable()
    {
      foreach (WeaponsGdInfoSection weaponsGdInfoSection in Resources.FindObjectsOfTypeAll<WeaponsGdInfoSection>())
        weaponsGdInfoSection.AttachmentsMaximum = (ushort) 6;
    }
  }
}
