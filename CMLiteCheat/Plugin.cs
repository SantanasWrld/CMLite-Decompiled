using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;


#nullable enable
namespace CMLiteCheat
{
  [BepInPlugin("cmlite.cheat", "CMLite Cheat", "1.0.0")]
  public class Plugin : BasePlugin
  {
    public static ManualLogSource LogSource;

    public virtual void Load()
    {
      Plugin.LogSource = this.Log;
      Plugin.LogSource.LogInfo((object) "Loaded");
      Queer.Gay(this);
    }
  }
}
