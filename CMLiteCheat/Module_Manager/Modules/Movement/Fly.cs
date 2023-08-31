using HarmonyLib;
using Photon.Bolt;
using System.Reflection;
using UnityEngine;

namespace CMLiteCheat.Module_Manager.Modules.Movement
{
  public class Fly : CMLiteCheat.Module_Manager.Base.Module.Module
  {
    public Fly()
      : base(nameof (Fly), "Movement")
    {
    }

    protected override void OnEnable()
    {
      MethodInfo methodInfo = AccessTools.PropertySetter(typeof (PlayerCommandInput), "Gravitation");
      MethodInfo method = typeof (Fly.patchMovement).GetMethod("MovementPatch");
      Queer.Harmony.Patch((MethodBase) methodInfo, new HarmonyMethod(method), (HarmonyMethod) null, (HarmonyMethod) null, (HarmonyMethod) null, (HarmonyMethod) null);
    }

    protected override void OnDisable()
    {
      MethodInfo methodInfo = AccessTools.PropertySetter(typeof (PlayerCommandInput), "Gravitation");
      Queer.Harmony.Unpatch((MethodBase) methodInfo, (HarmonyPatchType) 1, "CMLite");
    }

    private class patchMovement
    {
      public static void MovementPatch(ref float value)
      {
        if (Input.GetKey((KeyCode) 32))
          value = 1f;
        if (!Input.GetKey((KeyCode) 306))
          return;
        value = -1f;
      }
    }
  }
}
