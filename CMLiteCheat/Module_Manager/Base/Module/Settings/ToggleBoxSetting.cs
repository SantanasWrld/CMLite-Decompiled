#nullable enable
namespace CMLiteCheat.Module_Manager.Base.Settings
{
  public class ToggleBoxSetting : Setting
  {
    public bool Value;

    public ToggleBoxSetting(bool value) => this.Value = value;

    public override object GetValue() => (object) this.Value;

    public override void SetValue(object value) => this.Value = (bool) value;
  }
}
