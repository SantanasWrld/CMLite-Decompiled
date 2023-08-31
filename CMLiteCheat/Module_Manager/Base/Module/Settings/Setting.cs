#nullable enable
namespace CMLiteCheat.Module_Manager.Base.Settings
{
  public abstract class Setting
  {
    public abstract object GetValue();

    public abstract void SetValue(object value);
  }
}
