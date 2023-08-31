using CMLiteCheat.Module_Manager.Base.Settings;
using System;
using System.Collections.Generic;


#nullable enable
namespace CMLiteCheat.Module_Manager.Base.Module
{
  public class ModuleSettings
  {
    public readonly Dictionary<string, Setting> SettingsList;

    public ModuleSettings() => this.SettingsList = new Dictionary<string, Setting>();

    public void AddSetting(string name, Setting setting) => this.SettingsList[name] = setting;

    public T GetSettingValue<T>(string name)
    {
      Setting setting;
      if (this.SettingsList.TryGetValue(name, out setting))
        return (T) setting.GetValue();
      throw new ArgumentException("Setting " + name + " does not exist");
    }

    public void SetSettingValue(string name, object value)
    {
      Setting setting;
      if (!this.SettingsList.TryGetValue(name, out setting))
        throw new ArgumentException("Setting " + name + " does not exist");
      setting.SetValue(value);
    }
  }
}
