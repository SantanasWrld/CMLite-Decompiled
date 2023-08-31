using CMLiteCheat.Module_Manager.Base.Module;
using CMLiteCheat.Module_Manager.Base.Settings;
using CMLiteCheat.Optimization;
using CMLiteCheat.Utils;
using CombatMaster.Battle.Gameplay.Player;
using Photon.Bolt;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CMLiteCheat.Module_Manager.Modules.Visuals
{
  public class Esp : CMLiteCheat.Module_Manager.Base.Module.Module
  {
    public Esp()
      : base("ESP", "Visuals", settings: new ModuleSettings())
    {
    }

    public override void OnGUI()
    {
      try
      {
        foreach (PlayerHandler.PlayerModel player in Queer.playerHandler.GetPlayerList())
        {
          if (!Object.op_Equality((Object) player.PlayerObject, (Object) null) && !Object.op_Equality((Object) player.PlayerEntity, (Object) null))
          {
            Camera main = Camera.main;
            if (!Object.op_Equality((Object) ((EntityBehaviour) PlayerRoot.MyPlayer)._entity, (Object) player.PlayerEntity) && !(LayerMask.LayerToName(player.PlayerObject.layer) == "PlayerRagdoll"))
            {
              if (!player.Teammate)
              {
                Vector3 position1 = player.PlayerObject.transform.position;
                Vector3 vector3;
                vector3.x = position1.x;
                vector3.z = position1.z;
                vector3.y = position1.y - 0.1f;
                Vector3 position2 = ((IEnumerable<Transform>) player.PlayerBones).FirstOrDefault<Transform>((Func<Transform, bool>) (transform => ((Object) transform).name == "soldier:HeadEnd_M")).position;
                Vector3 screenPoint1 = main.WorldToScreenPoint(vector3);
                Vector3 screenPoint2 = main.WorldToScreenPoint(position2);
                if ((double) screenPoint1.z > 0.0)
                {
                  int health = player.PlayerEntity.GetState<PlayerState>().Health;
                  float num1 = screenPoint2.y - screenPoint1.y;
                  float num2 = num1 / 2.8f;
                  Rect rect;
                  // ISSUE: explicit constructor call
                  ((Rect) ref rect).\u002Ector(screenPoint1.x - num2 / 2f, (float) Screen.height - screenPoint1.y - num1, num2, num1);
                  Vector3.Distance(((Component) main).transform.position, position1);
                  if (this.Settings.GetSettingValue<bool>("Show Box"))
                    Methods.Render.DrawBoxGUI(rect, Color.red, this.Settings.GetSettingValue<float>("Box Thickness"));
                  if (this.Settings.GetSettingValue<bool>("Show Health"))
                    Methods.Render.DrawHealthBarGUI(rect, health, 2f, this.Settings.GetSettingValue<float>("Health Thickness"));
                }
              }
              else if (this.Settings.GetSettingValue<bool>("Show Teammates"))
              {
                Vector3 position = player.PlayerObject.transform.position;
                Vector3 vector3_1;
                vector3_1.x = position.x;
                vector3_1.z = position.z;
                vector3_1.y = position.y - 0.1f;
                Vector3 vector3_2 = vector3_1;
                vector3_2.y += 1.7f;
                Vector3 screenPoint3 = main.WorldToScreenPoint(vector3_1);
                Vector3 screenPoint4 = main.WorldToScreenPoint(vector3_2);
                if ((double) screenPoint3.z > 0.0)
                {
                  int health = player.PlayerEntity.GetState<PlayerState>().Health;
                  float num3 = screenPoint4.y - screenPoint3.y;
                  float num4 = num3 / 2.8f;
                  Rect rect;
                  // ISSUE: explicit constructor call
                  ((Rect) ref rect).\u002Ector(screenPoint3.x - num4 / 2f, (float) Screen.height - screenPoint3.y - num3, num4, num3);
                  Vector3.Distance(((Component) main).transform.position, position);
                  if (this.Settings.GetSettingValue<bool>("Show Box"))
                    Methods.Render.DrawBoxGUI(rect, Color.cyan, this.Settings.GetSettingValue<float>("Box Thickness"));
                  if (this.Settings.GetSettingValue<bool>("Show Health"))
                    Methods.Render.DrawHealthBarGUI(rect, health, 2f, this.Settings.GetSettingValue<float>("Health Thickness"));
                }
              }
            }
          }
        }
      }
      catch
      {
      }
    }

    protected override void AddSettings()
    {
      SliderSetting sliderSetting1 = new SliderSetting(2.2f, 1f, 10f);
      SliderSetting sliderSetting2 = new SliderSetting(2f, 1f, 10f);
      ToggleBoxSetting toggleBoxSetting1 = new ToggleBoxSetting(true);
      ToggleBoxSetting toggleBoxSetting2 = new ToggleBoxSetting(true);
      ToggleBoxSetting toggleBoxSetting3 = new ToggleBoxSetting(true);
      this.Settings.AddSetting("Box Thickness", (Setting) sliderSetting1);
      this.Settings.AddSetting("Health Thickness", (Setting) sliderSetting2);
      this.Settings.AddSetting("Show Box", (Setting) toggleBoxSetting1);
      this.Settings.AddSetting("Show Health", (Setting) toggleBoxSetting2);
      this.Settings.AddSetting("Show Teammates", (Setting) toggleBoxSetting3);
    }
  }
}
