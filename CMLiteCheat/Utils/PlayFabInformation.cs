using System.Collections.Generic;
using System.Diagnostics;


#nullable enable
namespace CMLiteCheat.Utils
{
  public class PlayFabInformation
  {
    public class BoughtShopBundle
    {
      [field: DebuggerBrowsable]
      public int _uid { get; set; }
    }

    public class Loot
    {
      [field: DebuggerBrowsable]
      public List<PlayFabInformation.BoughtShopBundle> _boughtShopBundles { get; set; }
    }

    public class Root
    {
      [field: DebuggerBrowsable]
      public PlayFabInformation.Loot Loot { get; set; }
    }
  }
}
