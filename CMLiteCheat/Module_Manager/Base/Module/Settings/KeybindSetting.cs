using UnityEngine;


#nullable enable
namespace CMLiteCheat.Module_Manager.Base.Settings
{
  public class KeybindSetting : Setting
  {
    public KeyCode Value;

    public KeybindSetting(KeyCode value) => this.Value = value;

    public override object GetValue() => (object) this.Value;

    public override void SetValue(object value) => this.Value = (KeyCode) value;
  }
}
