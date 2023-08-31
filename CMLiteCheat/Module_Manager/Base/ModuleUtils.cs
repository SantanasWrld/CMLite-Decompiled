using System;
using System.Collections.Generic;
using System.Linq;


#nullable enable
namespace CMLiteCheat.Module_Manager.Base
{
  public class ModuleUtils
  {
    public static void DisableModule<T>() where T : CMLiteCheat.Module_Manager.Base.Module.Module
    {
      CMLiteCheat.Module_Manager.Base.Module.Module module = Loader.Modules.FirstOrDefault<CMLiteCheat.Module_Manager.Base.Module.Module>((Func<CMLiteCheat.Module_Manager.Base.Module.Module, bool>) (m => m.GetType() == typeof (T)));
      if (!module.Enabled || module == null)
        return;
      module.Toggle();
    }

    public static void DisableModules(IEnumerable<Type> types)
    {
      foreach (Type type in types)
      {
        Type moduleType = type;
        foreach (CMLiteCheat.Module_Manager.Base.Module.Module module in Loader.Modules.Where<CMLiteCheat.Module_Manager.Base.Module.Module>((Func<CMLiteCheat.Module_Manager.Base.Module.Module, bool>) (m => m.GetType() == moduleType)))
        {
          if (module.Enabled)
            module.Toggle();
        }
      }
    }
  }
}
