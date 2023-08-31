using Il2CppInterop.Runtime.InteropTypes.Arrays;
using System.IO;
using System.Reflection;
using UnityEngine;


#nullable enable
namespace CMLiteCheat.Utils
{
  public class Styles
  {
    public static GUIStyle WindowStyle(Texture2D texture, GUIStyle? style = null)
    {
      if (style == null)
        style = GUI.skin.button;
      return new GUIStyle(style)
      {
        normal = {
          background = texture,
          textColor = Color.white
        },
        onNormal = {
          background = texture,
          textColor = Color.white
        },
        hover = {
          background = texture,
          textColor = Color.white
        },
        onHover = {
          background = texture,
          textColor = Color.white
        },
        active = {
          background = texture,
          textColor = Color.white
        },
        onActive = {
          background = texture,
          textColor = Color.white
        }
      };
    }

    public static GUIStyle GUIWindowStyle()
    {
      Color color1;
      // ISSUE: explicit constructor call
      ((Color) ref color1).\u002Ector(0.03529412f, 0.03529412f, 0.0431372561f, 1f);
      Color color2;
      // ISSUE: explicit constructor call
      ((Color) ref color2).\u002Ector(0.0f, 0.0f, 0.0f, 0.0f);
      Texture2D texture2D = new Texture2D(128, 128);
      for (int index1 = 0; index1 < 128; ++index1)
      {
        for (int index2 = 0; index2 < 128; ++index2)
        {
          if (index2 < 10 && index1 < 10 && (double) Mathf.Sqrt(Mathf.Pow((float) (index2 - 10), 2f) + Mathf.Pow((float) (index1 - 10), 2f)) > 10.0 || index2 > 118 && index1 < 10 && (double) Mathf.Sqrt(Mathf.Pow((float) (index2 - 118), 2f) + Mathf.Pow((float) (index1 - 10), 2f)) > 10.0 || index2 < 10 && index1 > 118 && (double) Mathf.Sqrt(Mathf.Pow((float) (index2 - 10), 2f) + Mathf.Pow((float) (index1 - 118), 2f)) > 10.0 || index2 > 118 && index1 > 118 && (double) Mathf.Sqrt(Mathf.Pow((float) (index2 - 118), 2f) + Mathf.Pow((float) (index1 - 118), 2f)) > 10.0)
            texture2D.SetPixel(index2, index1, color2);
          else
            texture2D.SetPixel(index2, index1, color1);
        }
      }
      texture2D.Apply();
      return new GUIStyle(GUI.skin.window)
      {
        fontSize = 14,
        normal = {
          background = texture2D,
          textColor = Color.white
        },
        onNormal = {
          background = texture2D,
          textColor = Color.white
        },
        active = {
          background = texture2D,
          textColor = Color.white
        },
        onActive = {
          background = texture2D,
          textColor = Color.white
        },
        focused = {
          background = texture2D,
          textColor = Color.white
        },
        onFocused = {
          background = texture2D,
          textColor = Color.white
        }
      };
    }

    public static GUIStyle GrayButtonStyle() => Styles.WindowStyle(Styles.DisabledTexture());

    public static GUIStyle BlueButtonStyle() => Styles.WindowStyle(Styles.EnabledTexture());

    public static GUIStyle GetBoxStyle() => Styles.WindowStyle(Styles.BoxTexture(), GUI.skin.box);

    public static Texture2D GetTexture(string resourceName)
    {
      Assembly executingAssembly = Assembly.GetExecutingAssembly();
      Texture2D texture = new Texture2D(2, 2);
      using (Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(resourceName))
      {
        byte[] numArray = new byte[manifestResourceStream.Length];
        manifestResourceStream.Read(numArray, 0, numArray.Length);
        ImageConversion.LoadImage(texture, Il2CppStructArray<byte>.op_Implicit(numArray));
        return texture;
      }
    }

    private static Texture2D EnabledTexture() => Styles.GetTexture("CMLiteCheat.Textures.PrimaryButton.png");

    private static Texture2D DisabledTexture() => Styles.GetTexture("CMLiteCheat.Textures.SecondaryButton.png");

    private static Texture2D BoxTexture() => Styles.GetTexture("CMLiteCheat.Textures.Box.png");

    public static GUIStyle GetHeadlineStyle() => new GUIStyle(GUI.skin.label)
    {
      fontSize = 14,
      fontStyle = (FontStyle) 1,
      alignment = (TextAnchor) 1
    };

    public static GUIStyle GetSubheadStyle() => new GUIStyle(GUI.skin.label)
    {
      fontSize = 12,
      fontStyle = (FontStyle) 1
    };

    public static GUIStyle GetToggleStyle() => new GUIStyle(GUI.skin.toggle)
    {
      fontSize = 12,
      fontStyle = (FontStyle) 1
    };
  }
}
