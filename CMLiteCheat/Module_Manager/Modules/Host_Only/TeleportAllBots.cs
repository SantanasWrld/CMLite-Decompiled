using CMLiteCheat.Optimization;
using CombatMaster.Battle.Gameplay.Player;
using Photon.Bolt;
using UnityEngine;

namespace CMLiteCheat.Module_Manager.Modules.Host_Only
{
  public class TeleportAllBots : CMLiteCheat.Module_Manager.Base.Module.Module
  {
    public TeleportAllBots()
      : base("Teleport All Bots", "Host Only")
    {
    }

    public override void OnUpdate()
    {
      foreach (PlayerHandler.PlayerModel player in Queer.playerHandler.GetPlayerList())
      {
        PlayerRoot myPlayer = PlayerRoot.MyPlayer;
        BoltEntity entity = ((EntityBehaviour) myPlayer)._entity;
        if (!Object.op_Equality((Object) player.PlayerEntity, (Object) ((EntityBehaviour) myPlayer)._entity) && !player.Teammate && ((Component) player.PlayerEntity).GetComponent<PlayerRoot>().IsBotInput)
        {
          Vector3 vector3 = Vector3.op_Multiply(((Component) ((EntityBehaviour) myPlayer)._entity).transform.forward, 2f);
          ((Component) player.PlayerEntity).transform.position = Vector3.op_Addition(((Component) entity).transform.position, vector3);
        }
      }
    }
  }
}
