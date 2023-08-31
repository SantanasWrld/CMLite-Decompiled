using CMLiteCheat.Optimization;
using CombatMaster.Battle.Gameplay.Player;
using Photon.Bolt;

namespace CMLiteCheat.Module_Manager.Modules.Host_Only
{
  public class FreezeAll : CMLiteCheat.Module_Manager.Base.Module.Module
  {
    public FreezeAll()
      : base("Freeze All", "Host Only")
    {
    }

    protected override void OnEnable()
    {
      foreach (PlayerHandler.PlayerModel player in Queer.playerHandler.GetPlayerList())
      {
        if (NetworkId.op_Inequality(player.PlayerEntity.NetworkId, ((EntityBehaviour) PlayerRoot.MyPlayer)._entity.NetworkId))
          BoltNetwork.FindEntity(player.PlayerEntity.NetworkId).Freeze(true);
      }
    }

    protected override void OnDisable()
    {
      foreach (PlayerHandler.PlayerModel player in Queer.playerHandler.GetPlayerList())
      {
        if (NetworkId.op_Inequality(player.PlayerEntity.NetworkId, ((EntityBehaviour) PlayerRoot.MyPlayer)._entity.NetworkId))
          BoltNetwork.FindEntity(player.PlayerEntity.NetworkId).Freeze(false);
      }
    }
  }
}
