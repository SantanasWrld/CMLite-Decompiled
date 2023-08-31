using UnityEngine;


#nullable enable
namespace CMLiteCheat.Module_Manager.Base.Module
{
  public abstract class Module
  {
    public readonly string ModuleName;
    public readonly string CategoryName;
    public readonly KeyCode KeyBind;
    public bool WaitingForBind;
    public bool Enabled;
    public readonly bool Hidden;
    public readonly ModuleSettings? Settings;

    protected Module(
      string moduleName,
      string categoryName,
      bool hidden = false,
      ModuleSettings? settings = null,
      KeyCode keyBind = 0)
    {
      this.ModuleName = moduleName;
      this.CategoryName = categoryName;
      this.KeyBind = keyBind;
      this.Hidden = hidden;
      this.Settings = settings;
      this.WaitingForBind = false;
      if (this.Settings == null)
        return;
      this.AddSettings();
    }

    protected virtual void AddSettings()
    {
    }

    protected virtual void OnEnable()
    {
    }

    protected virtual void OnDisable()
    {
    }

    public virtual void OnCheatLoad()
    {
    }

    public virtual void OnUpdate()
    {
    }

    public virtual void OnGUI()
    {
    }

    public virtual void OnGUIAlways()
    {
    }

    public void Toggle()
    {
      this.Enabled = !this.Enabled;
      if (this.Enabled)
        this.OnEnable();
      else
        this.OnDisable();
    }
  }
}
