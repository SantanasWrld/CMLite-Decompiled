using CMLiteCheat.Utils;
using CombatMaster.Battle.Gameplay.Player;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Photon.Bolt;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;


#nullable enable
namespace CMLiteCheat.Optimization
{
  public class PlayerHandler : MonoBehaviour
  {
    private readonly List<PlayerHandler.PlayerModel> playerList = new List<PlayerHandler.PlayerModel>();
    private float timer;
    private const float delay = 1f;

    public List<PlayerHandler.PlayerModel> GetPlayerList() => this.playerList;

    private void Update()
    {
      this.timer += Time.deltaTime;
      if ((double) this.timer < 1.0)
        return;
      this.playerList.Clear();
      foreach (GameObject playerObject in (Il2CppArrayBase<GameObject>) GameObject.FindGameObjectsWithTag("Player"))
        this.playerList.Add(new PlayerHandler.PlayerModel(playerObject));
      this.timer = 0.0f;
    }

    public class PlayerModel
    {
      [field: DebuggerBrowsable]
      public GameObject PlayerObject { get; set; } = (GameObject) null;

      [field: DebuggerBrowsable]
      public BoltEntity PlayerEntity { get; set; } = (BoltEntity) null;

      [field: DebuggerBrowsable]
      public Transform[] PlayerBones { get; set; } = (Transform[]) null;

      [field: DebuggerBrowsable]
      public bool Teammate { get; set; }

      public PlayerModel(GameObject playerObject)
      {
        if (Object.op_Equality((Object) playerObject, (Object) null))
          return;
        PlayerRoot component = playerObject.GetComponent<PlayerRoot>();
        this.PlayerObject = playerObject;
        this.PlayerEntity = ((EntityBehaviour) component)._entity;
        this.PlayerBones = Methods.FindChildInObject(this.PlayerObject, Methods.PlayerBones).ToArray();
        this.Teammate = Methods.isTeammate(component);
      }
    }
  }
}
