using CombatMaster.Battle.Gameplay.Player;
using CombatMaster.GDI;
using HarmonyLib;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppSystem;
using Photon.Bolt;
using Photon.Bolt.LagCompensation;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;


#nullable enable
namespace CMLiteCheat.Module_Manager.Modules.Host_Only
{
  public class XPLobby : CMLiteCheat.Module_Manager.Base.Module.Module
  {
    private readonly List<ushort> BattleXP = new List<ushort>();

    public XPLobby()
      : base("'XP Lobby'", "Host Only")
    {
    }

    protected override void OnEnable()
    {
      MethodInfo method1 = typeof (PlayerHealth).GetMethod("TakeDamage");
      MethodInfo method2 = typeof (XPLobby).GetMethod("PatchBotDamage");
      Queer.Harmony.Patch((MethodBase) method1, new HarmonyMethod(method2), (HarmonyMethod) null, (HarmonyMethod) null, (HarmonyMethod) null, (HarmonyMethod) null);
      foreach (NickNameGenerator nickNameGenerator in Resources.FindObjectsOfTypeAll<NickNameGenerator>())
      {
        nickNameGenerator._nickNames.Clear();
        nickNameGenerator._reservedNames.Clear();
        nickNameGenerator._forbiddenWord.Clear();
        nickNameGenerator._reservedNames.Add("CMLite v4.1 XP Lobby");
        nickNameGenerator._nickNames.Add("CMLite v4.1 XP Lobby");
      }
      foreach (BattleInfo battleInfo in Resources.FindObjectsOfTypeAll<BattleInfo>())
      {
        this.BattleXP.Add(battleInfo.BaseKill);
        battleInfo.BaseKill = (ushort) 60000;
        this.BattleXP.Add(battleInfo.Assist);
        battleInfo.Assist = (ushort) 60000;
        this.BattleXP.Add(battleInfo.ClearKill);
        battleInfo.ClearKill = (ushort) 60000;
        this.BattleXP.Add(battleInfo.TripleKill);
        battleInfo.TripleKill = (ushort) 60000;
        this.BattleXP.Add(battleInfo.DoubleKill);
        battleInfo.DoubleKill = (ushort) 60000;
        this.BattleXP.Add(battleInfo.HipFire);
        battleInfo.HipFire = (ushort) 60000;
        this.BattleXP.Add(battleInfo.Headshot);
        battleInfo.Headshot = (ushort) 60000;
        this.BattleXP.Add(battleInfo.MultiKill);
        battleInfo.MultiKill = (ushort) 60000;
      }
      foreach (OperatorsGdInfoSection operatorsGdInfoSection in Resources.FindObjectsOfTypeAll<OperatorsGdInfoSection>())
      {
        operatorsGdInfoSection.InvincibleTime = 0.0f;
        operatorsGdInfoSection.PlayerMaxHealth = 1;
      }
    }

    public override void OnUpdate()
    {
      foreach (PlayerRoot allPlayer in PlayerRoot.AllPlayers)
      {
        if (allPlayer.IsBotInput)
          ((Component) allPlayer).GetComponent<PlayerHealth>().DeathTime = new Nullable<float>(0.0f);
      }
    }

    protected override void OnDisable()
    {
      Il2CppArrayBase<BattleInfo> objectsOfTypeAll = Resources.FindObjectsOfTypeAll<BattleInfo>();
      for (int index = 0; index < objectsOfTypeAll.Length; ++index)
      {
        BattleInfo battleInfo = objectsOfTypeAll[index];
        battleInfo.BaseKill = this.BattleXP[index * 8];
        battleInfo.Assist = this.BattleXP[index * 8 + 1];
        battleInfo.ClearKill = this.BattleXP[index * 8 + 2];
        battleInfo.TripleKill = this.BattleXP[index * 8 + 3];
        battleInfo.DoubleKill = this.BattleXP[index * 8 + 4];
        battleInfo.HipFire = this.BattleXP[index * 8 + 5];
        battleInfo.Headshot = this.BattleXP[index * 8 + 6];
        battleInfo.MultiKill = this.BattleXP[index * 8 + 7];
      }
      foreach (OperatorsGdInfoSection operatorsGdInfoSection in Resources.FindObjectsOfTypeAll<OperatorsGdInfoSection>())
      {
        operatorsGdInfoSection.InvincibleTime = 2.5f;
        operatorsGdInfoSection.PlayerMaxHealth = 100;
      }
      MethodInfo method = typeof (PlayerHealth).GetMethod("TakeDamage");
      Queer.Harmony.Unpatch((MethodBase) method, (HarmonyPatchType) 2, "CMLite");
    }

    public static bool PatchBotDamage(
      int param_1,
      BoltEntity param_2 = null,
      BoltHitboxType param_3 = 2,
      EnumPublicSealedvaUnMeShExImBaFaPoBlUnique param_4 = 0)
    {
      return !((Component) param_2).GetComponent<PlayerRoot>().IsBotInput;
    }
  }
}
