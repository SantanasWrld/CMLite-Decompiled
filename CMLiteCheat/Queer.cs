using BepInEx.Core.Logging.Interpolation;
using BepInEx.Logging;
using CMLiteCheat.Module_Manager;
using CMLiteCheat.Optimization;
using HarmonyLib;
using System;
using System.Linq;
using UnityEngine;


#nullable enable
namespace CMLiteCheat
{
  public class Queer : MonoBehaviour
  {
    public static readonly Harmony Harmony = new Harmony("CMLite");
    public static PlayerHandler? playerHandler;

    public static void Gay(Plugin plugin)
    {
      Queer queer = plugin.AddComponent<Queer>();
      ((Object) queer).hideFlags = (HideFlags) 61;
      Object.DontDestroyOnLoad((Object) queer);
      Queer.playerHandler = plugin.AddComponent<PlayerHandler>();
      ((Object) Queer.playerHandler).hideFlags = (HideFlags) 61;
      Object.DontDestroyOnLoad((Object) Queer.playerHandler);
    }

    private void Start()
    {
      Loader.Start();
      foreach (CMLiteCheat.Module_Manager.Base.Module.Module module in Loader.Modules)
      {
        ManualLogSource logSource = Plugin.LogSource;
        bool flag;
        BepInExInfoLogInterpolatedStringHandler interpolatedStringHandler = new BepInExInfoLogInterpolatedStringHandler(16, 1, ref flag);
        if (flag)
        {
          ((BepInExLogInterpolatedStringHandler) interpolatedStringHandler).AppendFormatted<string>(module.ModuleName);
          ((BepInExLogInterpolatedStringHandler) interpolatedStringHandler).AppendLiteral(" was Initialized");
        }
        logSource.LogInfo(interpolatedStringHandler);
        module.OnCheatLoad();
      }
    }

    private void Update()
    {
      foreach (CMLiteCheat.Module_Manager.Base.Module.Module module in Loader.Modules.Where<CMLiteCheat.Module_Manager.Base.Module.Module>((Func<CMLiteCheat.Module_Manager.Base.Module.Module, bool>) (module => Input.GetKeyDown(module.KeyBind))))
        module.Toggle();
      foreach (CMLiteCheat.Module_Manager.Base.Module.Module module in Loader.Modules.Where<CMLiteCheat.Module_Manager.Base.Module.Module>((Func<CMLiteCheat.Module_Manager.Base.Module.Module, bool>) (m => m.Enabled)))
        module.OnUpdate();
    }

    private void OnGUI()
    {
      foreach (CMLiteCheat.Module_Manager.Base.Module.Module module in Loader.Modules.Where<CMLiteCheat.Module_Manager.Base.Module.Module>((Func<CMLiteCheat.Module_Manager.Base.Module.Module, bool>) (m => m.Enabled)))
        module.OnGUI();
      foreach (CMLiteCheat.Module_Manager.Base.Module.Module module in Loader.Modules)
        module.OnGUIAlways();
    }
  }
}
