using CMLiteCheat.Module_Manager.Modules;
using CMLiteCheat.Module_Manager.Modules.Combat;
using CMLiteCheat.Module_Manager.Modules.Host_Only;
using CMLiteCheat.Module_Manager.Modules.Movement;
using CMLiteCheat.Module_Manager.Modules.Visuals;
using CMLiteCheat.Module_Manager.Modules.Weapon;
using System.Collections.Generic;


#nullable enable
namespace CMLiteCheat.Module_Manager
{
  public class Loader
  {
    public static readonly List<CMLiteCheat.Module_Manager.Base.Module.Module> Modules = new List<CMLiteCheat.Module_Manager.Base.Module.Module>();
    public static readonly List<string> Category = new List<string>();

    public static void Start()
    {
      Loader.AddModule((CMLiteCheat.Module_Manager.Base.Module.Module) new Aimbot());
      Loader.AddModule((CMLiteCheat.Module_Manager.Base.Module.Module) new Esp());
      Loader.AddModule((CMLiteCheat.Module_Manager.Base.Module.Module) new RemovePlayfabId());
      Loader.AddModule((CMLiteCheat.Module_Manager.Base.Module.Module) new Fly());
      Loader.AddModule((CMLiteCheat.Module_Manager.Base.Module.Module) new JumpFly());
      Loader.AddModule((CMLiteCheat.Module_Manager.Base.Module.Module) new LowGravity());
      Loader.AddModule((CMLiteCheat.Module_Manager.Base.Module.Module) new SpeedHack());
      Loader.AddModule((CMLiteCheat.Module_Manager.Base.Module.Module) new QuickAndFastSlide());
      Loader.AddModule((CMLiteCheat.Module_Manager.Base.Module.Module) new Unlimited_Ammo());
      Loader.AddModule((CMLiteCheat.Module_Manager.Base.Module.Module) new InfiniteAttachments());
      Loader.AddModule((CMLiteCheat.Module_Manager.Base.Module.Module) new InstantScope());
      Loader.AddModule((CMLiteCheat.Module_Manager.Base.Module.Module) new NoRecoil());
      Loader.AddModule((CMLiteCheat.Module_Manager.Base.Module.Module) new NoSpread());
      Loader.AddModule((CMLiteCheat.Module_Manager.Base.Module.Module) new NoSway());
      Loader.AddModule((CMLiteCheat.Module_Manager.Base.Module.Module) new XPLobby());
      Loader.AddModule((CMLiteCheat.Module_Manager.Base.Module.Module) new DemiGodmode());
      Loader.AddModule((CMLiteCheat.Module_Manager.Base.Module.Module) new TeleportAllBots());
      Loader.AddModule((CMLiteCheat.Module_Manager.Base.Module.Module) new FreezeAll());
      Loader.AddModule((CMLiteCheat.Module_Manager.Base.Module.Module) new StartSinglePlayer());
      Loader.AddModule((CMLiteCheat.Module_Manager.Base.Module.Module) new GUI());
      if (Loader.Category.Contains("Settings"))
        return;
      Loader.Category.Add("Settings");
    }

    private static void AddModule(CMLiteCheat.Module_Manager.Base.Module.Module module)
    {
      if (!Loader.Category.Contains(module.CategoryName) && !module.Hidden)
        Loader.Category.Add(module.CategoryName);
      Loader.Modules.Add(module);
    }
  }
}
