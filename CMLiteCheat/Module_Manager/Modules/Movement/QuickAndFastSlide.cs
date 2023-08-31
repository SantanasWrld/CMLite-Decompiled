using CMLiteCheat.Module_Manager.Base.Module;
using CMLiteCheat.Module_Manager.Base.Settings;
using CombatMaster.GDI;
using HarmonyLib;
using Photon.Bolt;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;


#nullable enable
namespace CMLiteCheat.Module_Manager.Modules.Movement
{
  public class QuickAndFastSlide : CMLiteCheat.Module_Manager.Base.Module.Module
  {
    private readonly Dictionary<OperatorsGdInfoSection, float> savedOperators = new Dictionary<OperatorsGdInfoSection, float>();
    private static float SpeedValue;

    public QuickAndFastSlide()
      : base("Quick and Fast Slide", "Movement", settings: new ModuleSettings())
    {
    }

    public override void OnUpdate() => QuickAndFastSlide.SpeedValue = this.Settings.GetSettingValue<float>("Slide Speed");

    protected override void OnEnable()
    {
      MethodInfo methodInfo = AccessTools.PropertySetter(typeof (PlayerCommandInput), "SlideDirection");
      MethodInfo method = typeof (QuickAndFastSlide).GetMethod("SlidePatch");
      Queer.Harmony.Patch((MethodBase) methodInfo, new HarmonyMethod(method), (HarmonyMethod) null, (HarmonyMethod) null, (HarmonyMethod) null, (HarmonyMethod) null);
      foreach (OperatorsGdInfoSection key in Resources.FindObjectsOfTypeAll<OperatorsGdInfoSection>())
      {
        this.savedOperators.Add(key, key.SlideDuration);
        key.SlideDuration = 0.2f;
      }
    }

    protected override void OnDisable()
    {
      MethodInfo methodInfo = AccessTools.PropertySetter(typeof (PlayerCommandInput), "SlideDirection");
      Queer.Harmony.Unpatch((MethodBase) methodInfo, (HarmonyPatchType) 1, "CMLite");
      foreach (KeyValuePair<OperatorsGdInfoSection, float> savedOperator in this.savedOperators)
        savedOperator.Key.SlideDuration = savedOperator.Value;
    }

    public static void SlidePatch(ref Vector3 value) => value = Vector3.op_Multiply(value, QuickAndFastSlide.SpeedValue);

    protected override void AddSettings() => this.Settings.AddSetting("Slide Speed", (Setting) new SliderSetting(5f, 0.0f, 100f));
  }
}
