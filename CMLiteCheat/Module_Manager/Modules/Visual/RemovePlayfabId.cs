using CombatMaster.View.UI.Gameplay;
using UnityEngine;

namespace CMLiteCheat.Module_Manager.Modules.Visuals
{
  public class RemovePlayfabId : CMLiteCheat.Module_Manager.Base.Module.Module
  {
    public RemovePlayfabId()
      : base("Remove PlayfabID", "Visuals")
    {
    }

    protected override void OnEnable()
    {
      foreach (Object @object in Resources.FindObjectsOfTypeAll<BattleInfoPanel>())
        Object.Destroy(@object);
    }
  }
}
