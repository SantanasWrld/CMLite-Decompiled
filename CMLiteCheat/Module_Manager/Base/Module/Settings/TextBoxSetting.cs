#nullable enable
namespace CMLiteCheat.Module_Manager.Base.Settings
{
  public class TextBoxSetting : Setting
  {
    public string Value;

    public TextBoxSetting(string value) => this.Value = value;

    public override object GetValue() => (object) this.Value;

    public override void SetValue(object value) => this.Value = (string) value;
  }
}
