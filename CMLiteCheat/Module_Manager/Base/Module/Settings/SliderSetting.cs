#nullable enable
namespace CMLiteCheat.Module_Manager.Base.Settings
{
  public class SliderSetting : Setting
  {
    public float Value;
    public readonly float MinValue;
    public readonly float MaxValue;

    public SliderSetting(float value, float minValue, float maxValue)
    {
      this.Value = value;
      this.MinValue = minValue;
      this.MaxValue = maxValue;
    }

    public override object GetValue() => (object) this.Value;

    public override void SetValue(object value) => this.Value = (float) value;
  }
}
