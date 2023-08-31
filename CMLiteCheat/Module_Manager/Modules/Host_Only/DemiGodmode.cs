using CombatMaster.Battle.Gameplay.Player;
using Photon.Bolt;
using Photon.Bolt.Internal;
using UnityEngine;

namespace CMLiteCheat.Module_Manager.Modules.Host_Only
{
  public class DemiGodmode : CMLiteCheat.Module_Manager.Base.Module.Module
  {
    public DemiGodmode()
      : base("Demi-Godmode", "Host Only")
    {
    }

    public override void OnUpdate()
    {
      PlayerRoot myPlayer = PlayerRoot.MyPlayer;
      if (Object.op_Equality((Object) myPlayer, (Object) null))
        return;
      ((EntityEventListenerBase<IPlayerState>) myPlayer).state.Armor = 1000000;
    }

    protected override void OnDisable()
    {
      PlayerRoot myPlayer = PlayerRoot.MyPlayer;
      if (Object.op_Equality((Object) myPlayer, (Object) null))
        return;
      ((EntityEventListenerBase<IPlayerState>) myPlayer).state.Armor = 0;
    }
  }
}
