using CMLiteCheat.Module_Manager.Base.Module;
using CMLiteCheat.Module_Manager.Base.Settings;
using CMLiteCheat.Utils;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


#nullable enable
namespace CMLiteCheat.Module_Manager.Modules
{
  public class GUI : CMLiteCheat.Module_Manager.Base.Module.Module
  {
    private static Rect WindowRect = new Rect(20f, 20f, 700f, 350f);
    private static bool stylesInitialized;
    private GUIStyle? WindowStyle;
    private GUIStyle? PrimaryButtonStyle;
    private GUIStyle? SecondaryButtonStyle;
    private GUIStyle? HeaderStyle;
    private GUIStyle? SubHeaderStyle;
    private GUIStyle? BoxStyles;
    private float timer;
    private const float delay = 0.2f;
    private static string CurrentCategory = Loader.Category.First<string>();
    private bool CheckedWidth;
    private static readonly GUIStyle ArrayListGUIStyle = new GUIStyle();
    private static readonly GUIStyle WatermarkGUIStyle = new GUIStyle();

    public GUI()
      : base(nameof (GUI), "Visuals", true, new ModuleSettings(), (KeyCode) 277)
    {
    }

    public override void OnGUI()
    {
      if (Input.GetKeyDown((KeyCode) (int) sbyte.MaxValue))
      {
        GUI.stylesInitialized = false;
        GUI.WindowRect = new Rect(20f, 20f, 700f, 350f);
        GUI.CurrentCategory = Loader.Category.First<string>();
      }
      if (!GUI.stylesInitialized)
      {
        this.WindowStyle = Styles.GUIWindowStyle();
        this.PrimaryButtonStyle = Styles.BlueButtonStyle();
        this.SecondaryButtonStyle = Styles.GrayButtonStyle();
        this.HeaderStyle = Styles.GetHeadlineStyle();
        this.SubHeaderStyle = Styles.GetSubheadStyle();
        this.BoxStyles = Styles.GetBoxStyle();
        GUI.stylesInitialized = true;
      }
      Color rgb = Color.HSVToRGB(Mathf.PingPong(Time.time * 0.3f, 1f), 1f, 1f);
      this.WindowStyle.normal.textColor = rgb;
      this.WindowStyle.onNormal.textColor = rgb;
      GUI.WindowRect = GUI.Window(0, GUI.WindowRect, GUI.WindowFunction.op_Implicit(new Action<int>(this.WindowFunction)), "CMLite v4 By CallMeVerity", this.WindowStyle);
      this.timer += Time.deltaTime;
      if ((double) this.timer < 0.20000000298023224)
        return;
      GUI.stylesInitialized = false;
      this.timer = 0.0f;
    }

    public override void OnGUIAlways()
    {
      GUI.Watermark();
      if (!this.Settings.GetSettingValue<bool>("Show Array List"))
        return;
      GUI.ArrayList();
    }

    private void WindowFunction(int windowId)
    {
      this.DoCategories();
      this.DoModules();
      GUI.DragWindow();
    }

    private void DoCategories()
    {
      GUILayout.BeginHorizontal((Il2CppReferenceArray<GUILayoutOption>) null);
      GUILayout.FlexibleSpace();
      GUILayout.BeginHorizontal(this.BoxStyles, new GUILayoutOption[1]
      {
        GUILayout.MaxWidth(150f)
      });
      GUILayout.Space(2f);
      foreach (string str in Loader.Category)
      {
        if (str == GUI.CurrentCategory)
        {
          if (GUILayout.Button(str, this.PrimaryButtonStyle, (Il2CppReferenceArray<GUILayoutOption>) null))
            GUI.CurrentCategory = str;
        }
        else if (GUILayout.Button(str, this.SecondaryButtonStyle, (Il2CppReferenceArray<GUILayoutOption>) null))
          GUI.CurrentCategory = str;
        GUILayout.Space(5f);
      }
      GUILayout.EndHorizontal();
      GUILayout.FlexibleSpace();
      GUILayout.EndHorizontal();
    }

    private void DoModules()
    {
      List<CMLiteCheat.Module_Manager.Base.Module.Module> list = Loader.Modules.Where<CMLiteCheat.Module_Manager.Base.Module.Module>((Func<CMLiteCheat.Module_Manager.Base.Module.Module, bool>) (module => module.CategoryName == GUI.CurrentCategory && !module.Hidden)).ToList<CMLiteCheat.Module_Manager.Base.Module.Module>();
      if (!list.Any<CMLiteCheat.Module_Manager.Base.Module.Module>())
      {
        this.DoSettings();
        GUI.DragWindow();
      }
      else
      {
        this.CheckedWidth = false;
        GUI.WindowRect = new Rect(((Rect) ref GUI.WindowRect).x, ((Rect) ref GUI.WindowRect).y, 700f, 350f);
        GUILayout.BeginVertical(this.BoxStyles, new GUILayoutOption[1]
        {
          GUILayout.ExpandHeight(true)
        });
        int num = 0;
        GUILayout.BeginHorizontal(new GUILayoutOption[1]
        {
          GUILayout.MaxWidth(200f)
        });
        foreach (CMLiteCheat.Module_Manager.Base.Module.Module module in list)
        {
          ++num;
          if (module.Enabled)
          {
            if (GUILayout.Button(module.ModuleName, this.PrimaryButtonStyle, (Il2CppReferenceArray<GUILayoutOption>) null))
              module.Toggle();
          }
          else if (GUILayout.Button(module.ModuleName, this.SecondaryButtonStyle, (Il2CppReferenceArray<GUILayoutOption>) null))
            module.Toggle();
          GUILayout.Space(10f);
          if (num % 6 == 0 && num < list.Count)
          {
            GUILayout.EndHorizontal();
            GUILayout.Space(3f);
            GUILayout.BeginHorizontal(new GUILayoutOption[1]
            {
              GUILayout.MaxWidth(200f)
            });
          }
        }
        GUILayout.EndHorizontal();
        GUILayout.EndVertical();
      }
    }

    private void DoSettings()
    {
      float num1 = 0.0f;
      float num2 = 0.0f;
      int num3 = 0;
      GUILayout.BeginHorizontal((Il2CppReferenceArray<GUILayoutOption>) null);
      foreach (CMLiteCheat.Module_Manager.Base.Module.Module module1 in Loader.Modules.Where<CMLiteCheat.Module_Manager.Base.Module.Module>((Func<CMLiteCheat.Module_Manager.Base.Module.Module, bool>) (module => module.Settings != null)))
      {
        ++num3;
        if (num3 % 4 == 0)
        {
          GUILayout.EndHorizontal();
          GUILayout.BeginHorizontal((Il2CppReferenceArray<GUILayoutOption>) null);
        }
        else if (num3 == 0)
          GUILayout.FlexibleSpace();
        CMLiteCheat.Module_Manager.Base.Module.Module module2 = module1;
        ModuleSettings settings = module1.Settings;
        Dictionary<string, Setting> settingsList = module1.Settings.SettingsList;
        GUILayout.BeginVertical(this.BoxStyles, new GUILayoutOption[1]
        {
          GUILayout.MaxWidth(250f)
        });
        this.DrawHeader(module2.ModuleName + " Settings");
        GUILayout.Space(10f);
        float num4 = 0.0f;
        foreach (KeyValuePair<string, Setting> keyValuePair in settingsList)
        {
          if (keyValuePair.Value is SliderSetting sliderSetting)
          {
            this.DrawSubHeader(keyValuePair.Key);
            float num5 = GUILayout.HorizontalSlider(settings.GetSettingValue<float>(keyValuePair.Key), sliderSetting.MinValue, sliderSetting.MaxValue, new GUILayoutOption[1]
            {
              GUILayout.MaxWidth(200f)
            });
            settings.SetSettingValue(keyValuePair.Key, (object) num5);
            GUI.DrawSliderValue(num5);
          }
          if (keyValuePair.Value is TextBoxSetting)
          {
            this.DrawSubHeader(keyValuePair.Key);
            string str = GUILayout.TextField(settings.GetSettingValue<string>(keyValuePair.Key), new GUILayoutOption[1]
            {
              GUILayout.MaxWidth(150f)
            });
            settings.SetSettingValue(keyValuePair.Key, (object) str);
          }
          if (keyValuePair.Value is KeybindSetting)
          {
            this.DrawSubHeader(keyValuePair.Key + " (click to bind)");
            KeyCode settingValue = module1.Settings.GetSettingValue<KeyCode>(keyValuePair.Key);
            if (!module1.WaitingForBind)
            {
              if (GUILayout.Button(settingValue.ToString(), this.SecondaryButtonStyle, new GUILayoutOption[1]
              {
                GUILayout.Width(150f)
              }))
                module1.WaitingForBind = true;
            }
            else if (!GUILayout.Button("Waiting for input...", this.PrimaryButtonStyle, new GUILayoutOption[1]
            {
              GUILayout.Width(150f)
            }))
              ;
            if (module1.WaitingForBind)
            {
              EventType type = Event.current.type;
              if (type != null)
              {
                if (type == 4 && Event.current.keyCode > 0)
                {
                  KeyCode keyCode = Event.current.keyCode;
                  module1.Settings.SetSettingValue(keyValuePair.Key, (object) keyCode);
                  module1.WaitingForBind = false;
                }
              }
              else if (Event.current.button >= 0 && Event.current.button <= 2)
              {
                KeyCode keyCode = (KeyCode) (323 + Event.current.button);
                module1.Settings.SetSettingValue(keyValuePair.Key, (object) keyCode);
                module1.WaitingForBind = false;
              }
            }
          }
          if (keyValuePair.Value is ToggleBoxSetting)
          {
            bool flag = GUILayout.Toggle(module1.Settings.GetSettingValue<bool>(keyValuePair.Key), keyValuePair.Key, Styles.GetToggleStyle(), Array.Empty<GUILayoutOption>());
            module1.Settings.SetSettingValue(keyValuePair.Key, (object) flag);
            double num6 = (double) num4;
            Rect lastRect = GUILayoutUtility.GetLastRect();
            double height = (double) ((Rect) ref lastRect).height;
            num4 = (float) (num6 + height);
          }
        }
        GUILayout.EndVertical();
        double num7 = (double) num4;
        Rect lastRect1 = GUILayoutUtility.GetLastRect();
        double height1 = (double) ((Rect) ref lastRect1).height;
        num2 = (float) (num7 + height1);
        if (num3 == 0)
          GUILayout.FlexibleSpace();
      }
      double num8 = (double) num1;
      Rect lastRect2 = GUILayoutUtility.GetLastRect();
      double width = (double) ((Rect) ref lastRect2).width;
      float num9 = (float) (num8 + width);
      GUILayout.EndHorizontal();
      if (this.CheckedWidth)
        return;
      float num10 = 0.0f;
      if ((double) num2 != 0.0)
        num10 = num2 * 50f;
      float num11 = num9 * 80f;
      GUI.WindowRect = new Rect(((Rect) ref GUI.WindowRect).x, ((Rect) ref GUI.WindowRect).y, ((Rect) ref GUI.WindowRect).width + num11, ((Rect) ref GUI.WindowRect).height + num10);
      this.CheckedWidth = true;
    }

    private void DrawHeader(string text)
    {
      GUILayout.BeginHorizontal((Il2CppReferenceArray<GUILayoutOption>) null);
      GUILayout.Label(text, this.HeaderStyle, (Il2CppReferenceArray<GUILayoutOption>) null);
      GUILayout.EndHorizontal();
    }

    private void DrawSubHeader(string text)
    {
      GUILayout.BeginHorizontal((Il2CppReferenceArray<GUILayoutOption>) null);
      GUILayout.Label(text, this.SubHeaderStyle, new GUILayoutOption[1]
      {
        GUILayout.ExpandWidth(true)
      });
      GUILayout.EndHorizontal();
    }

    private static void DrawSliderValue(float value)
    {
      GUILayout.BeginHorizontal((Il2CppReferenceArray<GUILayoutOption>) null);
      GUILayout.Space(190f);
      GUILayout.Label(value.ToString("0.00"), Styles.GetSubheadStyle(), new GUILayoutOption[1]
      {
        GUILayout.Width(50f)
      });
      GUILayout.EndHorizontal();
    }

    protected override void AddSettings() => this.Settings.AddSetting("Show Array List", (Setting) new ToggleBoxSetting(false));

    private static void ArrayList()
    {
      Color rgb = Color.HSVToRGB(Mathf.PingPong(Time.time * 0.3f, 1f), 1f, 1f);
      GUI.ArrayListGUIStyle.alignment = (TextAnchor) 3;
      GUI.ArrayListGUIStyle.normal.textColor = rgb;
      GUI.ArrayListGUIStyle.fontSize = 18;
      CMLiteCheat.Module_Manager.Base.Module.Module[] array = Loader.Modules.Where<CMLiteCheat.Module_Manager.Base.Module.Module>((Func<CMLiteCheat.Module_Manager.Base.Module.Module, bool>) (module => module.Enabled && module.ModuleName != nameof (GUI))).OrderByDescending<CMLiteCheat.Module_Manager.Base.Module.Module, float>((Func<CMLiteCheat.Module_Manager.Base.Module.Module, float>) (module => Methods.Render.GetTextWidth(module.ModuleName))).ToArray<CMLiteCheat.Module_Manager.Base.Module.Module>();
      int num = 0;
      foreach (CMLiteCheat.Module_Manager.Base.Module.Module module in array)
      {
        num += 20;
        GUI.Label(new Rect(15f, (float) num, 200f, 200f), module.ModuleName ?? "", GUI.ArrayListGUIStyle);
      }
    }

    private static void Watermark()
    {
      Color rgb = Color.HSVToRGB(Mathf.PingPong(Time.time * 0.3f, 1f), 1f, 1f);
      GUI.WatermarkGUIStyle.alignment = (TextAnchor) 0;
      GUI.WatermarkGUIStyle.normal.textColor = rgb;
      GUI.WatermarkGUIStyle.fontSize = 25;
      GUI.Label(new Rect(10f, 5f, 200f, 200f), "CMLite v4", GUI.WatermarkGUIStyle);
    }
  }
}
