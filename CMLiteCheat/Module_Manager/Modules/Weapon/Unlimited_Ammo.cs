using Flexy.Utils;
using HarmonyLib;
using System.Reflection;

namespace CMLiteCheat.Module_Manager.Modules.Weapon
{
  public class Unlimited_Ammo : CMLiteCheat.Module_Manager.Base.Module.Module
  {
    public Unlimited_Ammo()
      : base("Unlimited Ammo", "Weapon")
    {
    }

    protected override void OnEnable()
    {
      MethodInfo method1 = typeof (MathUtils).GetMethod("SafeSubstraction");
      MethodInfo method2 = typeof (Unlimited_Ammo.patchMathUtils).GetMethod("SafeSubPatch");
      Queer.Harmony.Patch((MethodBase) method1, (HarmonyMethod) null, new HarmonyMethod(method2), (HarmonyMethod) null, (HarmonyMethod) null, (HarmonyMethod) null);
    }

    protected override void OnDisable()
    {
      MethodInfo method = typeof (MathUtils).GetMethod("SafeSubstraction");
      Queer.Harmony.Unpatch((MethodBase) method, (HarmonyPatchType) 2, "CMLite");
    }

    private class patchMathUtils
    {
      public static void SafeSubPatch(ref uint __result) => __result = 69U;
    }
  }
}
