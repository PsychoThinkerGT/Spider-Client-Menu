using StupidTemplate.Classes;
using UnityEngine;

namespace StupidTemplate
{
    public class Settings
    {
        public static Color32 TextColorOff = Color.white;
        public static Color32 NextButton = Color.black;
        public static Color32 PrevButton = Color.black;
        public static Color32 GunPointerColor = MenuColor;
        public static Color32 BackBack = Color.grey;
        public static Color32 UICOLOR = Color.white;
        public static Color32 buttonColorsOn = Color.red;
        public static Color32 TextColorOn = Color.white;
        public static Color32 ParticalColor = Color.blue;
        public static bool HomeButton = true;
        public static bool PageButtonsBottom = true;
        public static bool disconnectbuttonTop = true;
        public static Color32 Network = Color.blue;
        public static Color32 TitleColor = Color.white;
        public static bool BorderOn = true;
        public static bool ShowUIOn = true;
        public static string MenuTitle = "Spider Client V20";
        public static Color32 BorderColor = Color.black;
        public static Color32 buttonColorsOff = Color.black;
        public static Color32 MenuColor = Color.blue;
        public static Color32 NametagColor = Color.blue;
        public static Color32 DisconnectColor = Color.red;
        public static Font currentFont = (Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font);
        public static float gradientSpeed = 0.5f; // Speed of colors
        public static bool fpsCounter = true;
        public static bool disconnectButton = true;
        public static bool rightHanded = false;
        public static bool disableNotifications = false;
        public static float FPCPOV = 60f;
        public static KeyCode keyboardButton = KeyCode.Q;
        public static float Width = 0.1f; // thickness??
        public static float Height = 1.3f; // side to side
        public static float Size = 1.14f; // up down
        public static Vector3 menuSize = new Vector3(Width, Height, Size);
        public static int buttonsPerPage = 8;
    }
}
