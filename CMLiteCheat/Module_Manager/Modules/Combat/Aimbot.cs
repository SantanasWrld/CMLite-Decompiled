using CMLiteCheat.Module_Manager.Base.Module;
using CMLiteCheat.Module_Manager.Base.Settings;
using CMLiteCheat.Optimization;
using CombatMaster.Battle.Gameplay.Player;
using Photon.Bolt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;


#nullable enable
namespace CMLiteCheat.Module_Manager.Modules.Combat
{
  public class Aimbot : CMLiteCheat.Module_Manager.Base.Module.Module
  {
    private readonly Dictionary<Transform, float> foundPlayers = new Dictionary<Transform, float>();

    public Aimbot()
      : base(nameof (Aimbot), "Combat", settings: new ModuleSettings())
    {
    }

    [DllImport("user32.dll")]
    private static extern void mouse_event(
      int dwFlags,
      int dx,
      int dy,
      int dwData,
      int dwExtraInfo);

    public override void OnUpdate()
    {
      try
      {
        this.foundPlayers.Clear();
        Camera main = Camera.main;
        Vector3 position = ((Component) main).transform.position;
        foreach (PlayerHandler.PlayerModel playerModel in Queer.playerHandler.GetPlayerList().Where<PlayerHandler.PlayerModel>((Func<PlayerHandler.PlayerModel, bool>) (model => !model.Teammate)))
        {
          if (!Object.op_Equality((Object) playerModel.PlayerObject, (Object) null) && playerModel.PlayerBones != null && !Object.op_Equality((Object) playerModel.PlayerEntity, (Object) null) && !Object.op_Equality((Object) ((EntityBehaviour) PlayerRoot.MyPlayer)._entity, (Object) playerModel.PlayerEntity) && !(LayerMask.LayerToName(playerModel.PlayerObject.layer) == "PlayerRagdoll"))
          {
            Transform transform1 = ((IEnumerable<Transform>) playerModel.PlayerBones).FirstOrDefault<Transform>((Func<Transform, bool>) (transform => ((Object) transform).name == "soldier:Head_M"));
            if (!Object.op_Equality((Object) transform1, (Object) null) && (double) Vector3.Dot(Vector3.op_Subtraction(transform1.position, position), ((Component) main).transform.forward) >= 0.0)
            {
              float num1 = (float) Screen.height * 0.5f * Mathf.Tan((float) ((double) this.Settings.GetSettingValue<float>("FOV") * 0.5 * (Math.PI / 180.0)));
              Vector2 vector2;
              // ISSUE: explicit constructor call
              ((Vector2) ref vector2).\u002Ector((float) Screen.width * 0.5f, (float) Screen.height * 0.5f);
              float num2 = Vector2.Distance(vector2, Vector2.op_Implicit(main.WorldToScreenPoint(transform1.position)));
              if ((double) num2 <= (double) num1)
                this.foundPlayers.Add(((Component) transform1).transform, num2);
            }
          }
        }
        Transform transform2 = (Transform) null;
        if (this.foundPlayers.Any<KeyValuePair<Transform, float>>())
          transform2 = Enumerable.MinBy<KeyValuePair<Transform, float>, float>((IEnumerable<KeyValuePair<Transform, float>>) this.foundPlayers, (Func<KeyValuePair<Transform, float>, float>) (p => p.Value)).Key;
        if (Object.op_Equality((Object) transform2, (Object) null))
          return;
        Vector2 vector2_1 = Vector2.op_Implicit(main.WorldToScreenPoint(transform2.position));
        // ISSUE: explicit constructor call
        ((Vector2) ref vector2_1).\u002Ector(vector2_1.x, (float) Screen.height - vector2_1.y);
        double num3 = (double) vector2_1.x - (double) Screen.width / 2.0;
        double num4 = (double) vector2_1.y - (double) Screen.height / 2.0;
        double dx = num3 / (double) this.Settings.GetSettingValue<float>("Smoothing");
        double dy = num4 / (double) this.Settings.GetSettingValue<float>("Smoothing");
        if (!Input.GetKey(this.Settings.GetSettingValue<KeyCode>("Aim Key")))
          return;
        Aimbot.mouse_event(1, (int) dx, (int) dy, 0, 0);
      }
      catch
      {
      }
    }

    public override void OnGUIAlways()
    {
      if (!this.Settings.GetSettingValue<bool>("Draw FOV"))
        return;
      float num = (float) Screen.height * 0.5f * Mathf.Tan((float) ((double) this.Settings.GetSettingValue<float>("FOV") * 0.5 * (Math.PI / 180.0)));
      Vector2 center;
      // ISSUE: explicit constructor call
      ((Vector2) ref center).\u002Ector((float) Screen.width * 0.5f, (float) Screen.height * 0.5f);
      float radius1 = num + 2f;
      float radius2 = num - 2f;
      Aimbot.DrawCircle(center, radius1, 2f, Color.white);
      Aimbot.DrawCircle(center, radius2, 2f, Color.clear);
    }

    private static void DrawCircle(Vector2 center, float radius, float thickness, Color color)
    {
      Texture2D texture2D = new Texture2D(1, 1);
      texture2D.SetPixel(0, 0, color);
      texture2D.Apply();
      for (int index = 0; index < 360; ++index)
      {
        float num = (float) index * ((float) Math.PI / 180f);
        GUI.DrawTexture(new Rect(center.x + Mathf.Sin(num) * radius, center.y + Mathf.Cos(num) * radius, thickness, thickness), (Texture) texture2D);
      }
    }

    protected override void AddSettings()
    {
      SliderSetting sliderSetting1 = new SliderSetting(20f, 1f, 100f);
      SliderSetting sliderSetting2 = new SliderSetting(4f, 4f, 20f);
      KeybindSetting keybindSetting = new KeybindSetting((KeyCode) 324);
      ToggleBoxSetting toggleBoxSetting = new ToggleBoxSetting(false);
      this.Settings.AddSetting("FOV", (Setting) sliderSetting1);
      this.Settings.AddSetting("Smoothing", (Setting) sliderSetting2);
      this.Settings.AddSetting("Aim Key", (Setting) keybindSetting);
      this.Settings.AddSetting("Draw FOV", (Setting) toggleBoxSetting);
    }
  }
}
