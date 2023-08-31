using CombatMaster.Battle.Gameplay.Player;
using Photon.Bolt;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;


#nullable enable
namespace CMLiteCheat.Utils
{
  public class Methods
  {
    public static readonly string[] PlayerBones = new string[2]
    {
      "soldier:Head_M",
      "soldier:HeadEnd_M"
    };

    public static bool isTeammate(PlayerRoot playerRoot)
    {
      try
      {
        return ((EntityBehaviour) PlayerRoot.MyPlayer)._entity.GetState<PlayerState>().Team == ((EntityBehaviour) playerRoot)._entity.GetState<PlayerState>().Team;
      }
      catch
      {
        return false;
      }
    }

    public static List<Transform> FindChildInObject(GameObject parentObject, string[] childName)
    {
      List<Transform> childInObject = new List<Transform>();
      foreach (Transform componentsInChild in ((Component) parentObject.transform).GetComponentsInChildren<Transform>())
      {
        if (((IEnumerable<string>) childName).Contains<string>(((Object) componentsInChild).name))
          childInObject.Add(componentsInChild);
      }
      return childInObject;
    }

    public class Render : MonoBehaviour
    {
      [field: DebuggerBrowsable]
      private static GUIStyle StringStyle { get; } = new GUIStyle();

      public static void DrawString(Vector2 position, string label)
      {
        position.y += -8f;
        GUIContent guiContent = new GUIContent(label);
        Vector2 vector2 = Methods.Render.StringStyle.CalcSize(guiContent);
        GUI.Label(new Rect(position, vector2), guiContent);
      }

      public static void DrawBoxGUI(Rect rect, Color color, float thickness)
      {
        Texture2D texture2D = new Texture2D(1, 1);
        texture2D.SetPixel(0, 0, color);
        texture2D.Apply();
        Color color1 = GUI.color;
        GUI.color = color;
        GUI.DrawTexture(new Rect(((Rect) ref rect).x, ((Rect) ref rect).y, ((Rect) ref rect).width, thickness), (Texture) texture2D);
        GUI.DrawTexture(new Rect(((Rect) ref rect).x, ((Rect) ref rect).y, thickness, ((Rect) ref rect).height), (Texture) texture2D);
        GUI.DrawTexture(new Rect(((Rect) ref rect).x + ((Rect) ref rect).width - thickness, ((Rect) ref rect).y, thickness, ((Rect) ref rect).height), (Texture) texture2D);
        GUI.DrawTexture(new Rect(((Rect) ref rect).x, ((Rect) ref rect).y + ((Rect) ref rect).height - thickness, ((Rect) ref rect).width, thickness), (Texture) texture2D);
        GUI.color = color1;
      }

      public static void DrawHealthBarGUI(
        Rect rect,
        int playerHealth,
        float healthBarWidth,
        float healthBarThickness)
      {
        if (true)
          ;
        Color color1 = playerHealth > 80 ? Color.green : (playerHealth > 50 ? Color.yellow : Color.red);
        if (true)
          ;
        Color color2 = color1;
        float num1 = ((Rect) ref rect).height * ((float) playerHealth / 100f);
        Vector2 vector2;
        // ISSUE: explicit constructor call
        ((Vector2) ref vector2).\u002Ector(((Rect) ref rect).xMax + 5f, ((Rect) ref rect).yMax - num1);
        Rect rect1;
        // ISSUE: explicit constructor call
        ((Rect) ref rect1).\u002Ector(vector2.x, vector2.y, healthBarWidth, num1);
        Color color3 = GUI.color;
        GUI.color = Color.black;
        GUI.DrawTexture(rect1, (Texture) Texture2D.whiteTexture);
        GUI.color = color2;
        float num2 = num1 - 2f * healthBarThickness;
        Rect rect2;
        // ISSUE: explicit constructor call
        ((Rect) ref rect2).\u002Ector(vector2.x + healthBarThickness, (float) ((double) vector2.y + (double) healthBarThickness + ((double) num1 - (double) num2)), healthBarWidth - 2f * healthBarThickness, num2);
        GUI.DrawTexture(rect2, (Texture) Texture2D.whiteTexture);
        GUI.color = color3;
      }

      public static float GetTextWidth(string text) => Methods.Render.StringStyle.CalcSize(new GUIContent(text)).x;
    }
  }
}
