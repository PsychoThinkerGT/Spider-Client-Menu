using GorillaNetworking;
using Photon.Pun;
using UnityEngine;
using HarmonyLib;
using System.Reflection;
using UnityEngine.UI;
using PlayFab.ClientModels;
using UnityEngine.XR;
using BepInEx;
using System;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using System.Linq;
using StupidTemplate;
using StupidTemplate.Menu;
using StupidTemplate.Classes;

namespace SpiderUI
{
    [BepInPlugin("GhostsUI", "GhostsUI", "2.1.0")]
    public class GhostGUI : BaseUnityPlugin
    {
        public static bool showGUI = true;
        public string ModEnabled;

        void OnGUI()
        {
            if (showGUI)
            {
                GUIStyle style = new GUIStyle();
                style.normal.textColor = Settings.UICOLOR;
                style.fontSize = 15;

                foreach (ButtonInfo[] buttons in Buttons.buttons)
                {
                    foreach (ButtonInfo button in buttons)
                    {
                        if (button.enabled)
                            ModEnabled += "\n" + button.buttonText;
                    }
                }
                GUI.Label(new Rect(40, 5, 99999, 99999), ModEnabled, style);
                ModEnabled = "";
            }
        }
    }
}
