using System;
using System.Reflection;
using UnityEngine;
using GorillaLocomotion;
using Photon.Pun;

// === OCULUS REPORT MENU OPENER ===
public static class OculusReportMenuMod
{
    private static GorillaMetaReport reportMenu;
    private static bool initialized;
    private static float nextOpenTime;

    // ====== CALL THIS ONCE IN YOUR MOD LOADER ======
    public static void InitOculusReportMod()
    {
        if (initialized) return;
        initialized = true;

        FindReportMenu();
    }

    private static void FindReportMenu()
    {
        // includeInactive = true so we can find it even if the GO is disabled
        reportMenu = UnityEngine.Object.FindObjectOfType<GorillaMetaReport>(true);

        if (reportMenu == null)
        {
            Debug.LogError("[OculusReport] Could not find GorillaMetaReport in scene!");
        }
        else
        {
            Debug.Log("[OculusReport] GorillaMetaReport found on: " + reportMenu.gameObject.name);
        }
    }

    // ====== UPDATE LOOP — CALL EVERY FRAME ======
    public static void OculusReportMenu()
    {
        if (!initialized)
            InitOculusReportMod();

        if (reportMenu == null)
        {
            // Try to re-find in case of map/scene change
            FindReportMenu();
            if (reportMenu == null) return;
        }

        if (ControllerInputPoller.instance == null || GTPlayer.Instance == null)
            return;

        // Simple cooldown so holding grip doesn't spam it
        if (Time.time < nextOpenTime)
            return;

        // Right grip pressed
        if (ControllerInputPoller.instance.rightControllerGripFloat > 0.95f &&
            !GTPlayer.Instance.InReportMenu)
        {
            OpenReportMenu();
            nextOpenTime = Time.time + 0.5f; // half-second cooldown
        }
    }

    // ====== OPEN THE REAL OCULUS REPORT MENU ======
    private static void OpenReportMenu()
    {
        try
        {
            // Call private: void StartOverlay(bool isSanction = false)
            MethodInfo startOverlay = typeof(GorillaMetaReport)
                .GetMethod("StartOverlay", BindingFlags.Instance | BindingFlags.NonPublic);

            if (startOverlay != null)
            {
                // isSanction = false
                startOverlay.Invoke(reportMenu, new object[] { false });
                Debug.Log("[OculusReport] Opened Oculus Report Menu (Right Grip)");
            }
            else
            {
                Debug.LogError("[OculusReport] Could not find StartOverlay method via reflection.");
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("[OculusReport] Failed to open Oculus Report Menu: " + ex);
        }
    }
}
