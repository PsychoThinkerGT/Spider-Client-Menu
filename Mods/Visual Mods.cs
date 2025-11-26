using CjLib;
using ExitGames.Client.Photon;
using GorillaExtensions;
using GorillaLocomotion.Gameplay;
using GorillaNetworking;
using Photon.Pun;
using Photon.Realtime;
using StupidTemplate.Menu;
using StupidTemplate.Notifications;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Rendering.LookDev;
using static Oculus.Interaction.PointableCanvasModule;
using Object = UnityEngine.Object;

namespace StupidTemplate.Mods
{
    internal class VisualMods
    {
        #region VISUALS
        public static void Xray()
        {
            try
            {
                foreach (GameObject Xray in Resources.FindObjectsOfTypeAll(typeof(GameObject)))
                {
                    Renderer renderer = Xray.GetComponent<Renderer>();
                    if (renderer != null)
                    {
                        foreach (Material mat in renderer.materials)
                        {
                            Color color = mat.color;
                            color.a = 0.5f;
                            mat.color = color;
                            mat.SetFloat("_Mode", 3);
                            mat.SetInt("_SrcBlend", (int)(BlendMode)5);
                            mat.SetInt("_DstBlend", (int)(BlendMode)10);
                            mat.SetInt("_ZWrite", 0);
                            mat.renderQueue = 3000;
                        }
                    }
                }
            }
            catch
            {
                NotifiLib.SendNotification("Your game is broken, reload the mod/game to fix errors.");
            }
        }

        public static void DisableXray()
        {
            try
            {
                foreach (GameObject Xray in Resources.FindObjectsOfTypeAll(typeof(GameObject)))
                {
                    Renderer renderer = Xray.GetComponent<Renderer>();
                    if (renderer != null)
                    {
                        foreach (Material mat in renderer.materials)
                        {
                            Color color = mat.color;
                            color.a = 1.0f;
                            mat.color = color;
                            mat.SetFloat("_Mode", 0);
                            mat.SetInt("_SrcBlend", (int)(BlendMode)1);
                            mat.SetInt("_DstBlend", (int)(BlendMode)0);
                            mat.SetInt("_ZWrite", 1);
                            mat.renderQueue = -1;
                        }
                    }
                }
            }
            catch
            {
                NotifiLib.SendNotification("Your game is broken, reload the mod/game to fix errors.");
            }
        }

        public static void Tracers()
        {
            if (PhotonNetwork.CurrentRoom != null)
            {
                foreach (VRRig rig in GorillaParent.instance.vrrigs)
                {
                    if (!rig.isOfflineVRRig && !rig.isMyPlayer)
                    {
                        GameObject lines = new GameObject("Line");
                        LineRenderer lr = lines.AddComponent<LineRenderer>();
                        var color = Color.Lerp(new Color(0f, 1f, 0f, 0.5f), new Color(0f, 1f, 1f, 0.5f), Mathf.PingPong(Time.time, 1f));
                        lr.startColor = color;
                        lr.endColor = color;
                        lr.startWidth = 0.03f;
                        lr.endWidth = 0.03f;
                        lr.positionCount = 2;
                        lr.useWorldSpace = true;
                        lr.SetPosition(0, GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position);
                        lr.SetPosition(1, rig.transform.position);
                        lr.material.shader = Shader.Find("GUI/Text Shader");
                        UnityEngine.Object.Destroy(lr, Time.deltaTime);
                        UnityEngine.Object.Destroy(lines, Time.deltaTime);
                    }
                }
            }
        }

        public static void RemoveAllNametags()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                Transform existing = vrrig.transform.Find("NameTag");
                if (existing != null)
                {
                    GameObject.Destroy(existing.gameObject);
                }
            }
        }

        public static void Nametags()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (!vrrig.isOfflineVRRig && !vrrig.isMyPlayer)
                {
                    Transform existing = vrrig.transform.Find("NameTag");
                    GameObject tagObj;

                    if (existing == null)
                    {
                        tagObj = new GameObject("NameTag");
                        tagObj.transform.SetParent(vrrig.transform);

                        TextMeshPro tmp = tagObj.AddComponent<TextMeshPro>();
                        tmp.text = vrrig.OwningNetPlayer.NickName;
                        tmp.fontSize = 2f;
                        tmp.alignment = TextAlignmentOptions.Center;
                        tmp.font = GameObject.Find("motdtext").GetComponent<TextMeshPro>().font;

                        MeshRenderer mr = tmp.GetComponent<MeshRenderer>();
                        mr.material.shader = Shader.Find("GUI/Text Shader");
                    }
                    else
                    {
                        tagObj = existing.gameObject;
                    }

                    TextMeshPro tmpLive = tagObj.GetComponent<TextMeshPro>();
                    tmpLive.color = Settings.NametagColor;

                    tagObj.transform.localPosition = new Vector3(0f, 0.5f, 0f);

                    tagObj.transform.LookAt(Camera.main.transform.position);
                    tagObj.transform.Rotate(0f, 180f, 0f);
                }
            }
        }

        public static void InfShinyRocks()
        {
            CosmeticsController.instance.BundleShinyRocks = 9999999;
            CosmeticsController.instance.BundleShinyRocks = 9999999;
            CosmeticsController.instance.currencyBalance = 9999999;
        }

        public static void TracerOrbit()
        {
            TempLinear += 5f * Time.deltaTime;
            GameObject to = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            to.gameObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            UnityEngine.GameObject.Destroy(to.gameObject.GetComponent<SphereCollider>());
            to.gameObject.GetComponent<Renderer>().material.color = Color.Lerp(new Color(0f, 1f, 0f, 0.5f), new Color(0f, 1f, 1f, 0.5f), Mathf.PingPong(Time.time, 1f));
            float x = GorillaTagger.Instance.offlineVRRig.headConstraint.transform.position.x + 0.6f * Mathf.Cos(TempLinear);
            float y = GorillaTagger.Instance.offlineVRRig.headConstraint.transform.position.y + -1f;
            float z = GorillaTagger.Instance.offlineVRRig.headConstraint.transform.position.z + 0.6f * Mathf.Sin(TempLinear);
            to.gameObject.transform.position = new Vector3(x, y, z);
            GameObject gameObject = new GameObject("Line");
            LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
            UnityEngine.Color M = Color.Lerp(new Color(0f, 1f, 0f, 0.5f), new Color(0f, 1f, 1f, 0.5f), Mathf.PingPong(Time.time, 1f));
            UnityEngine.Color B = Color.Lerp(new Color(0f, 1f, 0f, 0.5f), new Color(0f, 1f, 1f, 0.5f), Mathf.PingPong(Time.time, 1f));
            lineRenderer.startColor = B;
            lineRenderer.endColor = M;
            lineRenderer.startWidth = 0.02f;
            lineRenderer.endWidth = 0.02f;
            lineRenderer.positionCount = 2;
            lineRenderer.useWorldSpace = true;
            lineRenderer.SetPosition(0, to.gameObject.transform.position);
            lineRenderer.SetPosition(1, GorillaTagger.Instance.headCollider.gameObject.transform.position);
            lineRenderer.material.shader = Shader.Find("GUI/Text Shader");
            UnityEngine.Object.Destroy(lineRenderer, Time.deltaTime);
            UnityEngine.Object.Destroy(gameObject, Time.deltaTime);
            UnityEngine.GameObject.Destroy(to.gameObject, 0.2f);
        }

        public static void Beacons()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (vrrig != GorillaTagger.Instance.offlineVRRig)
                {
                    GameObject gameObject = new GameObject("Line");
                    LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
                    Color playerColor = vrrig.playerColor;
                    lineRenderer.startColor = playerColor;
                    lineRenderer.endColor = playerColor;
                    lineRenderer.startWidth = 0.025f;
                    lineRenderer.endWidth = 0.025f;
                    lineRenderer.positionCount = 2;
                    lineRenderer.useWorldSpace = true;
                    lineRenderer.SetPosition(0, vrrig.transform.position + new Vector3(0f, 9999f, 0f));
                    lineRenderer.SetPosition(1, vrrig.transform.position - new Vector3(0f, 9999f, 0f));
                    lineRenderer.material.shader = Shader.Find("GUI/Text Shader");
                    UnityEngine.Object.Destroy(gameObject, Time.deltaTime);
                }
            }
        }

        public static void Esp()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (!vrrig.isOfflineVRRig && !vrrig.isMyPlayer && vrrig.mainSkin.material.name.Contains("fected"))
                {
                    vrrig.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
                    if (VisualMods.ESPColor == 0)
                    {
                        vrrig.mainSkin.material.color = new Color(9f, 0f, 0f, 0.5f);
                    }
                    else
                    {
                        vrrig.playerColor.a = 0.5f;
                        vrrig.mainSkin.material.color = vrrig.playerColor;
                        vrrig.playerColor.a = 1f;
                    }
                }
                else if (!vrrig.isOfflineVRRig && !vrrig.isMyPlayer)
                {
                    vrrig.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
                    vrrig.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
                    if (VisualMods.ESPColor == 0)
                    {
                        vrrig.mainSkin.material.color = new Color(0f, 9f, 0f, 0.5f);
                    }
                    else
                    {
                        vrrig.playerColor.a = 0.5f;
                        vrrig.mainSkin.material.color = vrrig.playerColor;
                        vrrig.playerColor.a = 1f;
                    }
                }
            }
            VisualMods.ESPStuff = true;
        }

        public static void DisableEsp()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (vrrig != GorillaTagger.Instance.offlineVRRig)
                {
                    vrrig.mainSkin.material.shader = Shader.Find("GorillaTag/UberShader");
                }
            }
        }

        public static void FixSelfEsp()
        {
            GorillaTagger.Instance.offlineVRRig.mainSkin.material.shader = Shader.Find("GorillaTag/UberShader");
        }

        public static void SelfEsp()
        {
            GorillaTagger.Instance.offlineVRRig.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
            GorillaTagger.Instance.offlineVRRig.mainSkin.material.color = (VisualMods.Infected(GorillaTagger.Instance.offlineVRRig) ? new Color32(byte.MaxValue, 0, 0, 50) : new Color32(0, byte.MaxValue, 0, 50));
        }

        public static void SnakeESP()
        {
            if (PhotonNetwork.InLobby || PhotonNetwork.InRoom)
            {
                foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                {
                    if (vrrig != GorillaTagger.Instance.offlineVRRig)
                    {
                        Vector3 position = vrrig.transform.position;
                        GameObject gameObject = new GameObject("Line");
                        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
                        Color startColor = Color.Lerp(new Color(0f, 1f, 0f, 0.5f), new Color(0f, 1f, 1f, 0.5f), Mathf.PingPong(Time.time, 1f));
                        Color endColor = new Color32(0, 0, 0, 125);
                        lineRenderer.startColor = startColor;
                        lineRenderer.endColor = endColor;
                        OVRExtensions.ToColorf(lineRenderer.endColor);
                        lineRenderer.startWidth = 0.070f;
                        lineRenderer.endWidth = 0.070f;
                        lineRenderer.transform.LookAt(GorillaTagger.Instance.headCollider.transform.position);
                        lineRenderer.useWorldSpace = true;
                        lineRenderer.positionCount = 2;
                        lineRenderer.SetPosition(0, position);
                        lineRenderer.SetPosition(1, position + new Vector3(0f, 0f, 0.1f));
                        lineRenderer.material.shader = Shader.Find("GUI/Text Shader");
                        UnityEngine.Object.Destroy(gameObject, 4f);
                    }
                }
            }
        }

        public static void BoxESP()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (vrrig != GorillaTagger.Instance.offlineVRRig)
                {
                    UnityEngine.Color thecolor = vrrig.playerColor;
                    GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    box.transform.position = vrrig.transform.position;
                    box.transform.LookAt(GorillaTagger.Instance.headCollider.transform.position);
                    box.GetComponent<Renderer>().material.color = Color.Lerp(new Color(0f, 1f, 0f, 0.5f), new Color(0f, 1f, 1f, 0.5f), Mathf.PingPong(Time.time, 1f));
                    UnityEngine.Object.Destroy(box, Time.deltaTime);
                }
            }
        }

        public static void CircleMonkeys()
        {
            if (PhotonNetwork.CurrentRoom != null)
            {
                foreach (NetPlayer player in PhotonNetwork.PlayerListOthers)
                {
                    VRRig vrrig = GorillaGameManager.instance.FindPlayerVRRig(player);
                    if (vrrig != null && !vrrig.isOfflineVRRig && !vrrig.isMyPlayer)
                    {
                        GameObject gameObject = GameObject.CreatePrimitive(0);
                        Object.Destroy(gameObject.GetComponent<BoxCollider>());
                        Object.Destroy(gameObject.GetComponent<Rigidbody>());
                        Object.Destroy(gameObject.GetComponent<Collider>());
                        gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.magenta);
                        gameObject.transform.rotation = Quaternion.identity;
                        gameObject.transform.localScale = new Vector3(2f, 2f, 2f);
                        gameObject.transform.position = vrrig.transform.position;
                        gameObject.GetComponent<MeshRenderer>().material = vrrig.mainSkin.material;
                        Object.Destroy(gameObject, Time.deltaTime);

                    }
                }
            }
        }

        public static void CubeMonkes()
        {
            if (PhotonNetwork.CurrentRoom != null)
            {
                foreach (NetPlayer player in PhotonNetwork.PlayerListOthers)
                {
                    VRRig vrrig = GorillaGameManager.instance.FindPlayerVRRig(player);
                    if (vrrig != null && !vrrig.isOfflineVRRig && !vrrig.isMyPlayer)
                    {
                        GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        Object.Destroy(gameObject.GetComponent<BoxCollider>());
                        Object.Destroy(gameObject.GetComponent<Rigidbody>());
                        Object.Destroy(gameObject.GetComponent<Collider>());
                        gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.magenta);
                        gameObject.transform.rotation = Quaternion.identity;
                        gameObject.transform.localScale = new Vector3(2f, 2f, 2f);
                        gameObject.transform.position = vrrig.transform.position;
                        gameObject.GetComponent<MeshRenderer>().material = vrrig.mainSkin.material;
                        Object.Destroy(gameObject, Time.deltaTime);

                    }
                }
            }
        }

        public static void SkeletonEsp()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (vrrig != null && !vrrig.isOfflineVRRig)
                {
                    GTExt.GetOrAddComponent<VisualMods.RGBSkeletonESPClass>(vrrig.gameObject);
                }
            }
        }

        public static void DisableSkeletonEsp()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (vrrig != null && !vrrig.isOfflineVRRig)
                {
                    UnityEngine.Object.Destroy(vrrig.gameObject.GetComponent<VisualMods.RGBSkeletonESPClass>());
                }
            }
        }

        public static void RedSky()
        {
            Renderer SkyObject = GameObject.Find("Environment Objects/LocalObjects_Prefab/Standard Sky").GetComponent<Renderer>();
            SkyObject.material.shader = Shader.Find("GorillaTag/UberShader");
            SkyObject.material.color = Color.red;
        }

        public static void WhiteSky()
        {
            Renderer SkyObject = GameObject.Find("Environment Objects/LocalObjects_Prefab/Standard Sky").GetComponent<Renderer>();
            SkyObject.material.shader = Shader.Find("GorillaTag/UberShader");
            SkyObject.material.color = Color.white;
        }

        public static void MagentaSky()
        {
            Renderer SkyObject = GameObject.Find("Environment Objects/LocalObjects_Prefab/Standard Sky").GetComponent<Renderer>();
            SkyObject.material.shader = Shader.Find("GorillaTag/UberShader");
            SkyObject.material.color = Color.magenta;
        }

        public static void CyanSky()
        {
            Renderer SkyObject = GameObject.Find("Environment Objects/LocalObjects_Prefab/Standard Sky").GetComponent<Renderer>();
            SkyObject.material.shader = Shader.Find("GorillaTag/UberShader");
            SkyObject.material.color = Color.cyan;
        }

        public static void GreySky()
        {
            Renderer SkyObject = GameObject.Find("Environment Objects/LocalObjects_Prefab/Standard Sky").GetComponent<Renderer>();
            SkyObject.material.shader = Shader.Find("GorillaTag/UberShader");
            SkyObject.material.color = Color.gray;
        }

        public static void BlackSky()
        {
            Renderer SkyObject = GameObject.Find("Environment Objects/LocalObjects_Prefab/Standard Sky").GetComponent<Renderer>();
            SkyObject.material.shader = Shader.Find("GorillaTag/UberShader");
            SkyObject.material.color = Color.black;
        }

        public static void YellowSky()
        {
            Renderer SkyObject = GameObject.Find("Environment Objects/LocalObjects_Prefab/Standard Sky").GetComponent<Renderer>();
            SkyObject.material.shader = Shader.Find("GorillaTag/UberShader");
            SkyObject.material.color = Color.yellow;
        }

        public static void BlueSky()
        {
            Renderer SkyObject = GameObject.Find("Environment Objects/LocalObjects_Prefab/Standard Sky").GetComponent<Renderer>();
            SkyObject.material.shader = Shader.Find("GorillaTag/UberShader");
            SkyObject.material.color = Color.blue;
        }

        public static void GreenSky()
        {
            Renderer SkyObject = GameObject.Find("Environment Objects/LocalObjects_Prefab/Standard Sky").GetComponent<Renderer>();
            SkyObject.material.shader = Shader.Find("GorillaTag/UberShader");
            SkyObject.material.color = Color.green;
        }
        public static void CustomSky()
        {
            Renderer SkyObject = GameObject.Find("Environment Objects/LocalObjects_Prefab/Standard Sky").GetComponent<Renderer>();
            SkyObject.material.shader = Shader.Find("GorillaTag/UberShader");
            SkyObject.material = Patches.Image.SpiderImage;
        }

        public static void FixSky()
        {
            GameObject.Find("Environment Objects/LocalObjects_Prefab/Standard Sky").GetComponent<Renderer>().material.shader = Shader.Find("Gorilla/DayNightLerpSkyMaterial");
        }

        public static void ChangeSkyColor()
        {
            {
                Sky++;
            }
            if (Sky == 1)
            {
                VisualMods.GreenSky();
            }
            if (Sky == 2)
            {
                VisualMods.WhiteSky();
            }
            if (Sky == 3)
            {
                VisualMods.MagentaSky();
            }
            if (Sky == 4)
            {
                VisualMods.CyanSky();
            }
            if (Sky == 5)
            {
                VisualMods.GreySky();
            }
            if (Sky == 6)
            {
                VisualMods.RedSky();
            }
            if (Sky == 7)
            {
                VisualMods.BlueSky();
            }
            if (Sky == 8)
            {
                VisualMods.YellowSky();
            }
            if (Sky == 9)
            {
                VisualMods.BlackSky();
            }
            if (Sky == 10)
            {
                VisualMods.CustomSky();
            }
            if (Sky == 11)
            {
                VisualMods.FixSky();
            }
            if (Sky == 12)
            {
                VisualMods.FixSky();
                Sky = 0;
            }

            string[] Sky1 = new string[] { "None", "Green", "White", "Magenta", "Cyan", "Grey", "Red", "Blue", "Yellow", "Black", "Spider", "Fix", "None", };
            Main.GetIndex("Sky Color:").overlapText = "Sky Color: <color=white>[</color><color=white>" + Sky1[Sky] + "</color><color=white>]</color>";
        }

        public static void ShowNetworkTriggers()
        {
            GameObject TriggergameObject = GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab");
            for (int i = 0; i < TriggergameObject.transform.childCount; i++)
            {
                Transform child = TriggergameObject.transform.GetChild(i);
                if (child.gameObject.activeSelf)
                {
                    Cube(child.position, child.rotation, child.localScale, Color.blue);
                }
            }
        }

        public static void SlingshotSelf()
        {
            GorillaTagger.Instance.offlineVRRig.reliableState.activeTransferrableObjectIndex[0] = 212;
            if (GorillaTagger.Instance.offlineVRRig.projectileWeapon == null)
            {
                GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/RigAnchor/rig/body/Slingshot Chest Snap/DropZoneAnchor/Slingshot").SetActive(true);
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.projectileWeapon.gameObject.SetActive(true);
            }
        }

        public static void UnslingshotSelf()
        {
            GorillaTagger.Instance.offlineVRRig.reliableState.SetIsDirty();
            if (GorillaTagger.Instance.offlineVRRig.projectileWeapon == null)
            {
                GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/RigAnchor/rig/body/Slingshot Chest Snap/DropZoneAnchor/Slingshot").SetActive(false);
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.projectileWeapon.gameObject.SetActive(false);
            }
            GorillaTagger.Instance.offlineVRRig.reliableState.SetIsNotDirty();
        }

        public static void SizeWatchSelf()
        {
            GorillaTagger.Instance.offlineVRRig.reliableState.activeTransferrableObjectIndex[0] = 212;
            if (GorillaTagger.Instance.offlineVRRig.guardianEjectWatch == null)
            {
                GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/RigAnchor/rig/body/Slingshot Chest Snap/DropZoneAnchor/Slingshot").SetActive(true);
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.guardianEjectWatch.gameObject.SetActive(true);
            }
        }

        public static void UnSizeWatchSelf()
        {
            GorillaTagger.Instance.offlineVRRig.reliableState.SetIsDirty();
            if (GorillaTagger.Instance.offlineVRRig.guardianEjectWatch == null)
            {
                GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/RigAnchor/rig/body/Slingshot Chest Snap/DropZoneAnchor/Slingshot").SetActive(false);
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.guardianEjectWatch.gameObject.SetActive(false);
            }
            GorillaTagger.Instance.offlineVRRig.reliableState.SetIsNotDirty();
        }

        public static void UnreleasedSweater()
        {
            GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/GorillaPlayerNetworkedRigAnchor/rig/body/LBACP.").SetActive(true);
        }

        public static void DisableUnreleasedSweater()
        {
            GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/GorillaPlayerNetworkedRigAnchor/rig/body/LBACP.").SetActive(false);
        }

        public static void AdminBadge()
        {
            GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/GorillaPlayerNetworkedRigAnchor/rig/body/LBAAD.").SetActive(true);
        }

        public static void DisableAdminBadge()
        {
            GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/GorillaPlayerNetworkedRigAnchor/rig/body/LBAAD.").SetActive(false);
        }

        public static void FingerPainter()
        {
            GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/GorillaPlayerNetworkedRigAnchor/rig/body/LBADE.").SetActive(true);
        }

        public static void DisableFingerPainter()
        {
            GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/GorillaPlayerNetworkedRigAnchor/rig/body/LBADE.").SetActive(false);
        }

        public static void IllustratorBadge()
        {
            GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/GorillaPlayerNetworkedRigAnchor/rig/body/LBAGS.").SetActive(true);
        }

        public static void DisableIllustratorBadge()
        {
            GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/GorillaPlayerNetworkedRigAnchor/rig/body/LBAGS.").SetActive(false);
        }

        public static void DrawGun()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Physics.Raycast(GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position, -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up, out var hitInfo);
                if (change17 == 1)
                {
                    pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    pointer.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                    pointer.transform.position = hitInfo.point;
                }
                if (change17 == 2 | change17 == 3)
                {
                    pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    if (change17 == 2)
                    {
                        UnityEngine.Object.Destroy(pointer.GetComponent<Renderer>());
                    }
                    pointer.transform.position = hitInfo.point;
                    GameObject gameObject2 = new GameObject("Line");
                    Line = gameObject2.AddComponent<LineRenderer>();
                    Line.material.shader = Shader.Find("GUI/Text Shader");
                    Line.startWidth = 0.025f;
                    Line.endWidth = 0.025f;
                    if (change8 == 1)
                    {
                        Line.startColor = Color.blue;
                        Line.endColor = Color.blue;
                    }
                    if (change8 == 2)
                    {
                        Line.startColor = Color.red;
                        Line.endColor = Color.red;
                    }
                    if (change8 == 3)
                    {
                        Line.startColor = Color.white;
                        Line.endColor = Color.white;
                    }
                    if (change8 == 4)
                    {
                        Line.startColor = Color.green;
                        Line.endColor = Color.green;
                    }
                    if (change8 == 5)
                    {
                        Line.startColor = Color.magenta;
                        Line.endColor = Color.magenta;
                    }
                    if (change8 == 6)
                    {
                        Line.startColor = Color.cyan;
                        Line.endColor = Color.cyan;
                    }
                    if (change8 == 7)
                    {
                        Line.startColor = Color.yellow;
                        Line.endColor = Color.yellow;
                    }
                    if (change8 == 8)
                    {
                        Line.startColor = Color.black;
                        Line.endColor = Color.black;
                    }
                    if (change8 == 9)
                    {
                        Line.startColor = Color.grey;
                        Line.endColor = Color.grey;
                    }
                    if (change8 == 10)
                    {
                        GradientColorKey[] array = new GradientColorKey[7];
                        array[0].color = Color.red;
                        array[0].time = 0f;
                        array[1].color = Color.yellow;
                        array[1].time = 0.2f;
                        array[2].color = Color.green;
                        array[2].time = 0.3f;
                        array[3].color = Color.cyan;
                        array[3].time = 0.5f;
                        array[4].color = Color.blue;
                        array[4].time = 0.6f;
                        array[5].color = Color.magenta;
                        array[5].time = 0.8f;
                        array[6].color = Color.red;
                        array[6].time = 1f;
                        Gradient gradient = new Gradient();
                        gradient.colorKeys = array;
                        float num = Mathf.PingPong(Time.time / 2f, 1f);
                        Color color = gradient.Evaluate(num);
                        Line.startColor = color;
                        Line.endColor = color;
                    }
                    Line.positionCount = 2;
                    Line.useWorldSpace = true;
                    Line.SetPosition(0, GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position);
                    Line.SetPosition(1, pointer.transform.position);
                    UnityEngine.Object.Destroy(gameObject2, Time.deltaTime);
                }
                if (change8 == 1)
                {
                    pointer.GetComponent<Renderer>().material.color = Color.blue;
                }
                if (change8 == 2)
                {
                    pointer.GetComponent<Renderer>().material.color = Color.red;
                }
                if (change8 == 3)
                {
                    pointer.GetComponent<Renderer>().material.color = Color.white;
                }
                if (change8 == 4)
                {
                    pointer.GetComponent<Renderer>().material.color = Color.green;
                }
                if (change8 == 5)
                {
                    pointer.GetComponent<Renderer>().material.color = Color.magenta;
                }
                if (change8 == 6)
                {
                    pointer.GetComponent<Renderer>().material.color = Color.cyan;
                }
                if (change8 == 7)
                {
                    pointer.GetComponent<Renderer>().material.color = Color.yellow;
                }
                if (change8 == 8)
                {
                    pointer.GetComponent<Renderer>().material.color = Color.black;
                }
                if (change8 == 9)
                {
                    pointer.GetComponent<Renderer>().material.color = Color.grey;
                }
                if (change8 == 10)
                {
                    GradientColorKey[] array = new GradientColorKey[7];
                    array[0].color = Color.red;
                    array[0].time = 0f;
                    array[1].color = Color.yellow;
                    array[1].time = 0.2f;
                    array[2].color = Color.green;
                    array[2].time = 0.3f;
                    array[3].color = Color.cyan;
                    array[3].time = 0.5f;
                    array[4].color = Color.blue;
                    array[4].time = 0.6f;
                    array[5].color = Color.magenta;
                    array[5].time = 0.8f;
                    array[6].color = Color.red;
                    array[6].time = 1f;
                    Gradient gradient = new Gradient();
                    gradient.colorKeys = array;
                    float num = Mathf.PingPong(Time.time / 2f, 1f);
                    Color color = gradient.Evaluate(num);
                    pointer.GetComponent<Renderer>().material.color = color;
                }
                UnityEngine.Object.Destroy(pointer.GetComponent<BoxCollider>());
                UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(pointer.GetComponent<Collider>());
                if (ControllerInputPoller.instance.rightControllerIndexFloat == 1f)
                {
                    GameObject.Find("Dont Find Anything pls").transform.position = pointer.transform.position;
                }
            }
            if (pointer != null)
            {
                UnityEngine.Object.Destroy(pointer, Time.deltaTime);
            }
        }

        public static void Draw()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                DrawCube = GameObject.CreatePrimitive(0);
                UnityEngine.Object.Destroy(DrawCube.GetComponent<SphereCollider>());
                UnityEngine.Object.Destroy(DrawCube.GetComponent<Rigidbody>());
                DrawCube.GetComponent<Renderer>().material.color = Settings.MenuColor;
                DrawCube.transform.position = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position;
                DrawCube.transform.localScale = new Vector3(DrawSize, DrawSize, DrawSize);
            }
        }

        public static void Drawbig()
        {
            DrawSize += 0.1f;
        }

        public static void DrawSmall()
        {
            if (DrawSize > 0.0)
            {
                DrawSize -= 0.1f;
            }
        }

        public static void ClearDrawing()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                for (int num24 = 1; num24 > 0; num24++)
                {
                    GameObject.Find("Sphere").SetActive(false);
                    GameObject.Find("Sphere").SetActive(false);
                    GameObject.Find("Sphere").SetActive(false);
                    GameObject.Find("Sphere").SetActive(false);
                    GameObject.Find("Sphere").SetActive(false);
                    GameObject.Find("Sphere").SetActive(false);
                }
                for (int num25 = 1; num25 > 0; num25++)
                {
                    GameObject.Find("Sphere").SetActive(false);
                    GameObject.Find("Sphere").SetActive(false);
                    GameObject.Find("Sphere").SetActive(false);
                    GameObject.Find("Sphere").SetActive(false);
                    GameObject.Find("Sphere").SetActive(false);
                    GameObject.Find("Sphere").SetActive(false);
                }
                for (int num26 = 1; num26 > 0; num26++)
                {
                    GameObject.Find("Sphere").SetActive(false);
                    GameObject.Find("Sphere").SetActive(false);
                    GameObject.Find("Sphere").SetActive(false);
                    GameObject.Find("Sphere").SetActive(false);
                    GameObject.Find("Sphere").SetActive(false);
                    GameObject.Find("Sphere").SetActive(false);
                }
                for (int num27 = 1; num27 > 0; num27++)
                {
                    GameObject.Find("Sphere").SetActive(false);
                    GameObject.Find("Sphere").SetActive(false);
                    GameObject.Find("Sphere").SetActive(false);
                    GameObject.Find("Sphere").SetActive(false);
                    GameObject.Find("Sphere").SetActive(false);
                    GameObject.Find("Sphere").SetActive(false);
                }
                for (int num28 = 1; num28 > 0; num28++)
                {
                    GameObject.Find("Sphere").SetActive(false);
                    GameObject.Find("Sphere").SetActive(false);
                    GameObject.Find("Sphere").SetActive(false);
                    GameObject.Find("Sphere").SetActive(false);
                    GameObject.Find("Sphere").SetActive(false);
                    GameObject.Find("Sphere").SetActive(false);
                }
                for (int num29 = 1; num29 > 0; num29++)
                {
                    GameObject.Find("Sphere").SetActive(false);
                    GameObject.Find("Sphere").SetActive(false);
                    GameObject.Find("Sphere").SetActive(false);
                    GameObject.Find("Sphere").SetActive(false);
                    GameObject.Find("Sphere").SetActive(false);
                    GameObject.Find("Sphere").SetActive(false);
                }
                for (int num30 = 1; num30 > 0; num30++)
                {
                    GameObject.Find("Sphere").SetActive(false);
                    GameObject.Find("Sphere").SetActive(false);
                    GameObject.Find("Sphere").SetActive(false);
                    GameObject.Find("Sphere").SetActive(false);
                    GameObject.Find("Sphere").SetActive(false);
                    GameObject.Find("Sphere").SetActive(false);
                }
                for (int num31 = 1; num31 > 0; num31++)
                {
                    GameObject.Find("Sphere").SetActive(false);
                    GameObject.Find("Sphere").SetActive(false);
                    GameObject.Find("Sphere").SetActive(false);
                    GameObject.Find("Sphere").SetActive(false);
                    GameObject.Find("Sphere").SetActive(false);
                    GameObject.Find("Sphere").SetActive(false);
                }
                for (int num32 = 1; num32 > 0; num32++)
                {
                    GameObject.Find("Sphere").SetActive(false);
                    GameObject.Find("Sphere").SetActive(false);
                    GameObject.Find("Sphere").SetActive(false);
                    GameObject.Find("Sphere").SetActive(false);
                    GameObject.Find("Sphere").SetActive(false);
                    GameObject.Find("Sphere").SetActive(false);
                }
                for (int num33 = 1; num33 > 0; num33++)
                {
                    GameObject.Find("Sphere").SetActive(false);
                    GameObject.Find("Sphere").SetActive(false);
                    GameObject.Find("Sphere").SetActive(false);
                    GameObject.Find("Sphere").SetActive(false);
                    GameObject.Find("Sphere").SetActive(false);
                    GameObject.Find("Sphere").SetActive(false);
                }
            }
        }

        public static void PlatGun()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Physics.Raycast(GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position, -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up, out var hitInfo);
                if (change17 == 1)
                {
                    pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    pointer.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                    pointer.transform.position = hitInfo.point;
                }
                if (change17 == 2 | change17 == 3)
                {
                    pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    if (change17 == 2)
                    {
                        UnityEngine.Object.Destroy(pointer.GetComponent<Renderer>());
                    }
                    pointer.transform.position = hitInfo.point;
                    GameObject gameObject2 = new GameObject("Line");
                    Line = gameObject2.AddComponent<LineRenderer>();
                    Line.material.shader = Shader.Find("GUI/Text Shader");
                    Line.startWidth = 0.025f;
                    Line.endWidth = 0.025f;
                    if (change8 == 1)
                    {
                        Line.startColor = Color.blue;
                        Line.endColor = Color.blue;
                    }
                    if (change8 == 2)
                    {
                        Line.startColor = Color.red;
                        Line.endColor = Color.red;
                    }
                    if (change8 == 3)
                    {
                        Line.startColor = Color.white;
                        Line.endColor = Color.white;
                    }
                    if (change8 == 4)
                    {
                        Line.startColor = Color.green;
                        Line.endColor = Color.green;
                    }
                    if (change8 == 5)
                    {
                        Line.startColor = Color.magenta;
                        Line.endColor = Color.magenta;
                    }
                    if (change8 == 6)
                    {
                        Line.startColor = Color.cyan;
                        Line.endColor = Color.cyan;
                    }
                    if (change8 == 7)
                    {
                        Line.startColor = Color.yellow;
                        Line.endColor = Color.yellow;
                    }
                    if (change8 == 8)
                    {
                        Line.startColor = Color.black;
                        Line.endColor = Color.black;
                    }
                    if (change8 == 9)
                    {
                        Line.startColor = Color.grey;
                        Line.endColor = Color.grey;
                    }
                    if (change8 == 10)
                    {
                        GradientColorKey[] array = new GradientColorKey[7];
                        array[0].color = Color.red;
                        array[0].time = 0f;
                        array[1].color = Color.yellow;
                        array[1].time = 0.2f;
                        array[2].color = Color.green;
                        array[2].time = 0.3f;
                        array[3].color = Color.cyan;
                        array[3].time = 0.5f;
                        array[4].color = Color.blue;
                        array[4].time = 0.6f;
                        array[5].color = Color.magenta;
                        array[5].time = 0.8f;
                        array[6].color = Color.red;
                        array[6].time = 1f;
                        Gradient gradient = new Gradient();
                        gradient.colorKeys = array;
                        float num = Mathf.PingPong(Time.time / 2f, 1f);
                        Color color = gradient.Evaluate(num);
                        Line.startColor = color;
                        Line.endColor = color;
                    }
                    Line.positionCount = 2;
                    Line.useWorldSpace = true;
                    Line.SetPosition(0, GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position);
                    Line.SetPosition(1, pointer.transform.position);
                    UnityEngine.Object.Destroy(gameObject2, Time.deltaTime);
                }
                if (change8 == 1)
                {
                    pointer.GetComponent<Renderer>().material.color = Color.blue;
                }
                if (change8 == 2)
                {
                    pointer.GetComponent<Renderer>().material.color = Color.red;
                }
                if (change8 == 3)
                {
                    pointer.GetComponent<Renderer>().material.color = Color.white;
                }
                if (change8 == 4)
                {
                    pointer.GetComponent<Renderer>().material.color = Color.green;
                }
                if (change8 == 5)
                {
                    pointer.GetComponent<Renderer>().material.color = Color.magenta;
                }
                if (change8 == 6)
                {
                    pointer.GetComponent<Renderer>().material.color = Color.cyan;
                }
                if (change8 == 7)
                {
                    pointer.GetComponent<Renderer>().material.color = Color.yellow;
                }
                if (change8 == 8)
                {
                    pointer.GetComponent<Renderer>().material.color = Color.black;
                }
                if (change8 == 9)
                {
                    pointer.GetComponent<Renderer>().material.color = Color.grey;
                }
                if (change8 == 10)
                {
                    GradientColorKey[] array = new GradientColorKey[7];
                    array[0].color = Color.red;
                    array[0].time = 0f;
                    array[1].color = Color.yellow;
                    array[1].time = 0.2f;
                    array[2].color = Color.green;
                    array[2].time = 0.3f;
                    array[3].color = Color.cyan;
                    array[3].time = 0.5f;
                    array[4].color = Color.blue;
                    array[4].time = 0.6f;
                    array[5].color = Color.magenta;
                    array[5].time = 0.8f;
                    array[6].color = Color.red;
                    array[6].time = 1f;
                    Gradient gradient = new Gradient();
                    gradient.colorKeys = array;
                    float num = Mathf.PingPong(Time.time / 2f, 1f);
                    Color color = gradient.Evaluate(num);
                    pointer.GetComponent<Renderer>().material.color = color;
                }
                UnityEngine.Object.Destroy(pointer.GetComponent<BoxCollider>());
                UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(pointer.GetComponent<Collider>());
                if (ControllerInputPoller.instance.rightControllerIndexFloat == 1f)
                {
                    AntiRepeat = false;
                    return;
                }
                GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                gameObject.name = "plat";
                gameObject.GetComponent<Renderer>().material.color = Settings.MenuColor;
                gameObject.transform.localScale = new Vector3(0.025f, 0.3f, 0.4f);
                gameObject.transform.position = hitInfo.point;
                gameObject.transform.LookAt(GorillaLocomotion.GTPlayer.Instance.headCollider.transform);
                object[] eventContent = new object[]
                {
        gameObject.transform.position,
        gameObject.transform.rotation
                };
                RaiseEventOptions raiseEventOptions = new RaiseEventOptions
                {
                    Receivers = ReceiverGroup.Others
                };
                PhotonNetwork.RaiseEvent(69, eventContent, raiseEventOptions, SendOptions.SendReliable);
            }
            if (pointer != null)
            {
                UnityEngine.Object.Destroy(pointer, Time.deltaTime);
            }
        }

        public static void RemovePlatforms()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                for (int j = 1; j > 0; j++)
                {
                    GameObject.Find("plat").SetActive(false);
                    GameObject.Find("plat").SetActive(false);
                    GameObject.Find("plat").SetActive(false);
                    GameObject.Find("plat").SetActive(false);
                    GameObject.Find("plat").SetActive(false);
                    GameObject.Find("plat").SetActive(false);
                }
                for (int k = 1; k > 0; k++)
                {
                    GameObject.Find("plat").SetActive(false);
                    GameObject.Find("plat").SetActive(false);
                    GameObject.Find("plat").SetActive(false);
                    GameObject.Find("plat").SetActive(false);
                    GameObject.Find("plat").SetActive(false);
                    GameObject.Find("plat").SetActive(false);
                }
                for (int l = 1; l > 0; l++)
                {
                    GameObject.Find("plat").SetActive(false);
                    GameObject.Find("plat").SetActive(false);
                    GameObject.Find("plat").SetActive(false);
                    GameObject.Find("plat").SetActive(false);
                    GameObject.Find("plat").SetActive(false);
                    GameObject.Find("plat").SetActive(false);
                }
                for (int m = 1; m > 0; m++)
                {
                    GameObject.Find("plat").SetActive(false);
                    GameObject.Find("plat").SetActive(false);
                    GameObject.Find("plat").SetActive(false);
                    GameObject.Find("plat").SetActive(false);
                    GameObject.Find("plat").SetActive(false);
                    GameObject.Find("plat").SetActive(false);
                }
                for (int n = 1; n > 0; n++)
                {
                    GameObject.Find("plat").SetActive(false);
                    GameObject.Find("plat").SetActive(false);
                    GameObject.Find("plat").SetActive(false);
                    GameObject.Find("plat").SetActive(false);
                    GameObject.Find("plat").SetActive(false);
                    GameObject.Find("plat").SetActive(false);
                }
                for (int num = 1; num > 0; num++)
                {
                    GameObject.Find("plat").SetActive(false);
                    GameObject.Find("plat").SetActive(false);
                    GameObject.Find("plat").SetActive(false);
                    GameObject.Find("plat").SetActive(false);
                    GameObject.Find("plat").SetActive(false);
                    GameObject.Find("plat").SetActive(false);
                }
                for (int num2 = 1; num2 > 0; num2++)
                {
                    GameObject.Find("plat").SetActive(false);
                    GameObject.Find("plat").SetActive(false);
                    GameObject.Find("plat").SetActive(false);
                    GameObject.Find("plat").SetActive(false);
                    GameObject.Find("plat").SetActive(false);
                    GameObject.Find("plat").SetActive(false);
                }
                for (int num3 = 1; num3 > 0; num3++)
                {
                    GameObject.Find("plat").SetActive(false);
                    GameObject.Find("plat").SetActive(false);
                    GameObject.Find("plat").SetActive(false);
                    GameObject.Find("plat").SetActive(false);
                    GameObject.Find("plat").SetActive(false);
                    GameObject.Find("plat").SetActive(false);
                }
            }
        }

        public static void Horror()
        {
            BetterDayNightManager.instance.SetTimeOfDay(0);
            Camera.main.farClipPlane = 7f;
        }

        public static void DisableHorror()
        {
            BetterDayNightManager.instance.SetTimeOfDay(3);
            Camera.main.farClipPlane = VisualMods.farClipPlane;
        }

        public static void MakeAllBlack()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                vrrig.mainSkin.material.color = Color.black;
            }
        }

        public static void MakeAllRGB()
        {
            float time = Time.time;
            float Red = Mathf.Sin(time * 2f) * 0.5f + 0.5f;
            float Green = Mathf.Sin(time * 1.5f) * 0.5f + 0.5f;
            float Blue = Mathf.Sin(time * 2.5f) * 0.5f + 0.5f;
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                vrrig.mainSkin.material.color = new Color(Red, Green, Blue);
            }
        }

        public static void MakeAllStrobe()
        {
            float time = Time.time;
            float Red = Mathf.Sin(time * 2f) * 0.5f + 0.5f;
            float Green = Mathf.Sin(time * 10f) * 0.5f + 0.5f;
            float Blue = Mathf.Sin(time * 10f) * 0.5f + 0.5f;
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                vrrig.mainSkin.material.color = new Color(Red, Green, Blue);
            }
        }

        public static void RigLerping()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (vrrig != GorillaTagger.Instance.offlineVRRig)
                {
                    vrrig.lerpValueBody = 1f;
                    vrrig.lerpValueFingers = 1f;
                }
            }
        }

        public static void FixRigLerping()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (vrrig != GorillaTagger.Instance.offlineVRRig)
                {
                    vrrig.lerpValueBody = GorillaTagger.Instance.offlineVRRig.lerpValueBody;
                    vrrig.lerpValueFingers = GorillaTagger.Instance.offlineVRRig.lerpValueFingers;
                }
            }
        }

        public static void ChangeTirgerSkinColor()
        {
            if (PhotonNetwork.InRoom)
            {
                foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                {
                    if (vrrig.mainSkin.sharedMaterials[0].name.Contains("TigerSkinBody"))
                    {
                        vrrig.mainSkin.sharedMaterials[0].color = vrrig.playerColor;
                    }
                }
            }
            else
            {
                VRRig offlineVRRig = GorillaTagger.Instance.offlineVRRig;
                if (offlineVRRig.mainSkin.sharedMaterials[0].name.Contains("TigerSkinBody"))
                {
                    offlineVRRig.mainSkin.sharedMaterials[0].color = offlineVRRig.playerColor;
                }
            }
        }

        public static void BreakLights()
        {
            BetterDayNightManager.instance.AnimateLightFlash(2, 0f, 0f, 2f);
        }

        public static void FixLights()
        {
            BetterDayNightManager.instance.AnimateLightFlash(2, 2f, 2f, 2f);
        }

        public static void TapAllCrystals()//WIP
        {
            if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.9f)
            {
                if (Time.time >= CrystalDelay)
                {
                    GorillaCaveCrystal[] crystals = Object.FindObjectsOfType<GorillaCaveCrystal>();

                    foreach (GorillaCaveCrystal crystal in crystals)
                    {
                        if (crystal == null)
                            continue;

                        if (crystal.tapScript == null)
                            crystal.tapScript = crystal.GetComponent<TapInnerGlow>();

                        crystal.OnTapLocal(
                            tapStrength: 1f,
                            tapTime: Time.time,
                            info: default
                        );

                        if (crystal.visuals != null)
                            crystal.visuals.ForceUpdate();
                    }

                    CrystalDelay = Time.time + 0.1f;
                }
            }
        }

        [Obsolete]
        public static void FPSboost()
        {
            Fps = true;
            if (Fps)
            {
                QualitySettings.masterTextureLimit = 999999999;
                QualitySettings.masterTextureLimit = 999999999;
                QualitySettings.globalTextureMipmapLimit = 999999999;
                QualitySettings.maxQueuedFrames = 60;
            }
        }

        [Obsolete]
        public static void FixFPSBoost()
        {
            if (Fps)
            {
                QualitySettings.masterTextureLimit = default;
                QualitySettings.masterTextureLimit = default;
                QualitySettings.globalTextureMipmapLimit = default;
                QualitySettings.maxQueuedFrames = default;
                Fps = false;
            }
        }

        public static void BreakBoards()
        {
            GorillaScoreBoard[] array = Object.FindObjectsOfType<GorillaScoreBoard>();
            for (int i = 0; i < array.Length; i++)
            {
                array[i].boardText.text = "SPIDER ON TOP SPIDER ON TOP SPIDER ON TOP SPIDER ON TOP SPIDER ON TOP SPIDER ON TOP SPIDER ON TOP SPIDER ON TOP SPIDER ON TOP SPIDER ON TOP SPIDER ON TOP SPIDER ON TOP SPIDER ON TOP SPIDER ON TOP SPIDER ON TOP SPIDER ON TOP SPIDER ON TOP SPIDER ON TOP SPIDER ON TOP SPIDER ON TOP SPIDER ON TOP SPIDER ON TOP";
            }
        }

        public static void FixBreakBoards()
        {
            GorillaScoreBoard[] array = Object.FindObjectsOfType<GorillaScoreBoard>();
            for (int i = 0; i < array.Length; i++)
            {
                array[i].boardText.text = "";
            }
        }

        public static void GroundColors()
        {
            if (Ground == 1)
            {
                Mat.color = new Color32(255, 255, 255, byte.MaxValue);
            }

            GameObject forestboard = GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Terrain");
            forestboard.GetComponent<Renderer>().material = Mat;
        }

        public static void CaseohMonke()
        {
            GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/GorillaPlayerNetworkedRigAnchor/rig/body/LBAPE.").SetActive(true);
        }
        public static void FixCaseohMonke()
        {
            GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/GorillaPlayerNetworkedRigAnchor/rig/body/LBAPE.").SetActive(false);
        }

        public static void SmokeEffects()
        {
            GameObject.Find("Environment Objects/05Maze_PersistentObjects/RocketShip_Prefab/RocketShip_FX").transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
            UnityEngine.GameObject.Find("Environment Objects/05Maze_PersistentObjects/RocketShip_Prefab/RocketShip_FX").gameObject.SetActive(true);
            UnityEngine.GameObject.Find("Environment Objects/05Maze_PersistentObjects/RocketShip_Prefab/RocketShip_FX").gameObject.GetComponent<ParticleSystem>().Play();
            UnityEngine.GameObject.Find("Environment Objects/05Maze_PersistentObjects/RocketShip_Prefab/RocketShip_FX").gameObject.transform.position = GorillaTagger.Instance.headCollider.gameObject.transform.position;
        }

        public static void GrabRocket()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                GameObject.Find("RocketShip_Prefab").transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
                GameObject.Find("RocketShip_Prefab").transform.position = new Vector3(0f, -0.0075f, 0f);
                GameObject.Find("RocketShip_Prefab").transform.position = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position;
            }
        }

        public static void LaunchRocket()
        {
            GameObject.Find("Environment Objects/05Maze_PersistentObjects/RocketShip_Prefab").GetComponent<ScheduledTimelinePlayer>().timeline.Stop();
            GameObject.Find("Environment Objects/05Maze_PersistentObjects/RocketShip_Prefab").GetComponent<ScheduledTimelinePlayer>().timeline.Play();
        }

        public static void VelocityCounter()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                NotifiLib.SendNotification("<color=yellow> INFO </color> <color=cyan>Current Velocity [ </color>" + GorillaLocomotion.GTPlayer.Instance.InstantaneousVelocity + "<color=cyan> ] </color>");
            }
        }

        public static void MasterCheck()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                if (PhotonNetwork.IsMasterClient)
                {
                    NotifiLib.SendNotification("<color=grey>[</color><color=green>SUCCESS</color><color=grey>]</color> <color=white>You are master client.</color>");
                }
                else
                {
                    NotifiLib.SendNotification("<color=grey>[</color><color=red>ERROR</color><color=grey>]</color> <color=white>You are not master client.</color>");
                }
            }
        }

        public static void GrabBraclets()
        {
            if (ControllerInputPoller.instance.leftGrab)
            {
                GorillaTagger.Instance.myVRRig.SendRPC("EnableNonCosmeticHandItemRPC", RpcTarget.All, new object[]
                {
                    false,
                    false
                });
                GorillaTagger.Instance.myVRRig.SendRPC("EnableNonCosmeticHandItemRPC", RpcTarget.All, new object[]
                {
                    true,
                    true
                });
                FlushRpcs();
            }
            if (ControllerInputPoller.instance.rightGrab)
            {
                GorillaTagger.Instance.myVRRig.SendRPC("EnableNonCosmeticHandItemRPC", RpcTarget.All, new object[]
                {
                    false,
                    true
                });
                GorillaTagger.Instance.myVRRig.SendRPC("EnableNonCosmeticHandItemRPC", RpcTarget.All, new object[]
                {
                    true,
                    false
                });
                FlushRpcs();
            }
        }

        public static void RemoveBracelet()
        {
            GorillaTagger.Instance.myVRRig.SendRPC("EnableNonCosmeticHandItemRPC", RpcTarget.All, new object[]
            {
                false,
                true
            });
            GorillaTagger.Instance.myVRRig.SendRPC("EnableNonCosmeticHandItemRPC", RpcTarget.All, new object[]
            {
                false,
                false
            });
            FlushRpcs();
        }

        public static void ShowHandHitboxes()
        {
            if (VisualMods.RightIndicatorCircle == null)
            {
                VisualMods.RightIndicatorCircle = GameObject.CreatePrimitive(0);
                Object.Destroy(VisualMods.RightIndicatorCircle.GetComponent<Rigidbody>());
                Object.Destroy(VisualMods.RightIndicatorCircle.GetComponent<Collider>());
                Object.Destroy(VisualMods.RightIndicatorCircle.GetComponent<SphereCollider>());
                VisualMods.RightIndicatorCircle.transform.localScale = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.localScale - new Vector3(0.72f, 0.72f, 0.72f);
                VisualMods.RightIndicatorCircle.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                VisualMods.RightIndicatorCircle.GetComponent<Renderer>().material.color = Settings.MenuColor;
            }
            if (VisualMods.LeftIndicatorCircle == null)
            {
                VisualMods.LeftIndicatorCircle = GameObject.CreatePrimitive(0);
                Object.Destroy(VisualMods.LeftIndicatorCircle.GetComponent<Rigidbody>());
                Object.Destroy(VisualMods.LeftIndicatorCircle.GetComponent<Collider>());
                Object.Destroy(VisualMods.LeftIndicatorCircle.GetComponent<SphereCollider>());
                VisualMods.LeftIndicatorCircle.transform.localScale = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.localScale - new Vector3(0.72f, 0.72f, 0.72f);
                VisualMods.LeftIndicatorCircle.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                VisualMods.LeftIndicatorCircle.GetComponent<Renderer>().material.color = Settings.MenuColor;
            }
            VisualMods.RightIndicatorCircle.transform.position = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position;
            VisualMods.LeftIndicatorCircle.transform.position = GorillaLocomotion.GTPlayer.Instance.LeftHand.controllerTransform.position;
        }

        public static void Lowhz()
        {
            GorillaZiplineSettings[] ziplineSettings = UnityEngine.Object.FindObjectsOfType<GorillaZiplineSettings>();
            GorillaZipline[] gorillaZiplines = UnityEngine.Object.FindObjectsOfType<GorillaZipline>();
            foreach (GorillaZiplineSettings gorillaZiplineSettings in ziplineSettings)
            {
                gorillaZiplineSettings.minSlidePitch = 50f;
                gorillaZiplineSettings.maxSlidePitch = 50f;
                gorillaZiplineSettings.maxSlideVolume = 50f;
                gorillaZiplineSettings.maxSpeed = 50f;
                gorillaZiplineSettings.gravityMulti = 50f;
                gorillaZiplineSettings.friction = 50f;
                gorillaZiplineSettings.maxFriction = 50f;
                gorillaZiplineSettings.maxFrictionSpeed = 50f;
            }
        }

        public static void SteamScreenShot()
        {
            Keyboard i = Keyboard.current;
            i.f12Key.Equals(true);
        }

        public static void CrashSelf()
        {
            UnityEngine.Application.Quit();
        }

        public static void WheelMod()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                GameObject Wheel1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                GameObject Wheel2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                GameObject QuestionableCarFormat = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                {
                    Wheel1.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    Wheel2.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    QuestionableCarFormat.transform.localScale = new Vector3(0.55f, 0.3f, 0.55f);
                    Wheel1.transform.rotation = GorillaLocomotion.GTPlayer.Instance.bodyCollider.transform.rotation;
                    Wheel2.transform.rotation = GorillaLocomotion.GTPlayer.Instance.bodyCollider.transform.rotation;
                    QuestionableCarFormat.transform.rotation = GorillaLocomotion.GTPlayer.Instance.bodyCollider.transform.rotation;
                    Wheel1.transform.position = GorillaLocomotion.GTPlayer.Instance.bodyCollider.transform.position + new Vector3(0.25f, -0.15f, 0f);
                    Wheel2.transform.position = GorillaLocomotion.GTPlayer.Instance.bodyCollider.transform.position + new Vector3(0f, -0.15f, 0.3f);
                    QuestionableCarFormat.transform.position = GorillaLocomotion.GTPlayer.Instance.bodyCollider.transform.position + new Vector3(0f, -0.15f, 0.25f);
                    Wheel1.GetComponent<Renderer>().material.color = new Color32(92, 52, 3, 1);
                    Wheel2.GetComponent<Renderer>().material.color = new Color32(92, 52, 3, 1);
                    QuestionableCarFormat.GetComponent<Renderer>().material.color = new Color32(64, 37, 3, 1);
                    UnityEngine.Object.Destroy(Wheel1.GetComponent<MeshCollider>());
                    UnityEngine.Object.Destroy(Wheel2.GetComponent<MeshCollider>());
                    UnityEngine.Object.Destroy(QuestionableCarFormat.GetComponent<MeshCollider>());
                    UnityEngine.Object.Destroy(Wheel1, Time.deltaTime);
                    UnityEngine.Object.Destroy(Wheel2, Time.deltaTime);
                    UnityEngine.Object.Destroy(QuestionableCarFormat, Time.deltaTime);
                }
            }
        }

        public static void OldRamp()
        {
            GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/tree/stubbranch").SetActive(true);
        }

        public static void BigBubbles()
        {
            GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/TurnParent/Main Camera/UnderwaterVisualEffects/UnderwaterParticleEffects/UnderwaterBubbles").SetActive(true);
            GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/TurnParent/Main Camera/UnderwaterVisualEffects/UnderwaterParticleEffects/UnderwaterBubbles").transform.localScale = new Vector3(55f, 55f, 55f);
        }

        public static void DisableBigBubbles()
        {
            GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/TurnParent/Main Camera/UnderwaterVisualEffects/UnderwaterParticleEffects/UnderwaterBubbles").SetActive(false);
        }

        public static void BubblesSpamRight()
        {
            GameObject bubbles = GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/TurnParent/Main Camera/UnderwaterVisualEffects/UnderwaterParticleEffects/UnderwaterBubbles");
            if (ControllerInputPoller.instance.rightGrab)
            {
                for (int i = 0; i < 5; i++)
                {
                    GameObject newBubble = GameObject.Instantiate(bubbles);
                    newBubble.SetActive(true);
                    newBubble.transform.localScale = new Vector3(1f, 1f, 1f);

                    newBubble.transform.position = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position;

                    GameObject.Destroy(newBubble, 2f);
                }
            }
        }

        public static void BubblesSpamLeft()
        {
            GameObject bubbles = GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/TurnParent/Main Camera/UnderwaterVisualEffects/UnderwaterParticleEffects/UnderwaterBubbles");
            if (ControllerInputPoller.instance.leftGrab)
            {
                for (int i = 0; i < 5; i++)
                {
                    GameObject newBubble = GameObject.Instantiate(bubbles);
                    newBubble.SetActive(true);
                    newBubble.transform.localScale = new Vector3(1f, 1f, 1f);

                    newBubble.transform.position = GorillaLocomotion.GTPlayer.Instance.LeftHand.controllerTransform.position;

                    GameObject.Destroy(newBubble, 2f);
                }
            }
        }

        public static void BubblesCrashSelf()
        {
            GameObject bubbles = GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/TurnParent/Main Camera/UnderwaterVisualEffects/UnderwaterParticleEffects/UnderwaterBubbles");
            for (int i = 0; i < 5000; i++)
            {
                GameObject newBubble = GameObject.Instantiate(bubbles);
                newBubble.SetActive(true);
                newBubble.transform.localScale = new Vector3(1f, 1f, 1f);
                newBubble.transform.position = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position;

                GameObject.Destroy(newBubble, 9f);
            }
        }

        public static void BubbleGun()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Physics.Raycast(GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position, -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up, out var hitInfo);
                if (change17 == 1)
                {
                    pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    pointer.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                    pointer.transform.position = hitInfo.point;
                }
                if (change17 == 2 | change17 == 3)
                {
                    pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    if (change17 == 2)
                    {
                        UnityEngine.Object.Destroy(pointer.GetComponent<Renderer>());
                    }
                    pointer.transform.position = hitInfo.point;
                    GameObject gameObject2 = new GameObject("Line");
                    Line = gameObject2.AddComponent<LineRenderer>();
                    Line.material.shader = Shader.Find("GUI/Text Shader");
                    Line.startWidth = 0.025f;
                    Line.endWidth = 0.025f;
                    if (change8 == 1)
                    {
                        Line.startColor = Color.blue;
                        Line.endColor = Color.blue;
                    }
                    if (change8 == 2)
                    {
                        Line.startColor = Color.red;
                        Line.endColor = Color.red;
                    }
                    if (change8 == 3)
                    {
                        Line.startColor = Color.white;
                        Line.endColor = Color.white;
                    }
                    if (change8 == 4)
                    {
                        Line.startColor = Color.green;
                        Line.endColor = Color.green;
                    }
                    if (change8 == 5)
                    {
                        Line.startColor = Color.magenta;
                        Line.endColor = Color.magenta;
                    }
                    if (change8 == 6)
                    {
                        Line.startColor = Color.cyan;
                        Line.endColor = Color.cyan;
                    }
                    if (change8 == 7)
                    {
                        Line.startColor = Color.yellow;
                        Line.endColor = Color.yellow;
                    }
                    if (change8 == 8)
                    {
                        Line.startColor = Color.black;
                        Line.endColor = Color.black;
                    }
                    if (change8 == 9)
                    {
                        Line.startColor = Color.grey;
                        Line.endColor = Color.grey;
                    }
                    if (change8 == 10)
                    {
                        GradientColorKey[] array = new GradientColorKey[7];
                        array[0].color = Color.red;
                        array[0].time = 0f;
                        array[1].color = Color.yellow;
                        array[1].time = 0.2f;
                        array[2].color = Color.green;
                        array[2].time = 0.3f;
                        array[3].color = Color.cyan;
                        array[3].time = 0.5f;
                        array[4].color = Color.blue;
                        array[4].time = 0.6f;
                        array[5].color = Color.magenta;
                        array[5].time = 0.8f;
                        array[6].color = Color.red;
                        array[6].time = 1f;
                        Gradient gradient = new Gradient();
                        gradient.colorKeys = array;
                        float num = Mathf.PingPong(Time.time / 2f, 1f);
                        Color color = gradient.Evaluate(num);
                        Line.startColor = color;
                        Line.endColor = color;
                    }
                    Line.positionCount = 2;
                    Line.useWorldSpace = true;
                    Line.SetPosition(0, GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position);
                    Line.SetPosition(1, pointer.transform.position);
                    UnityEngine.Object.Destroy(gameObject2, Time.deltaTime);
                }
                if (change8 == 1)
                {
                    pointer.GetComponent<Renderer>().material.color = Color.blue;
                }
                if (change8 == 2)
                {
                    pointer.GetComponent<Renderer>().material.color = Color.red;
                }
                if (change8 == 3)
                {
                    pointer.GetComponent<Renderer>().material.color = Color.white;
                }
                if (change8 == 4)
                {
                    pointer.GetComponent<Renderer>().material.color = Color.green;
                }
                if (change8 == 5)
                {
                    pointer.GetComponent<Renderer>().material.color = Color.magenta;
                }
                if (change8 == 6)
                {
                    pointer.GetComponent<Renderer>().material.color = Color.cyan;
                }
                if (change8 == 7)
                {
                    pointer.GetComponent<Renderer>().material.color = Color.yellow;
                }
                if (change8 == 8)
                {
                    pointer.GetComponent<Renderer>().material.color = Color.black;
                }
                if (change8 == 9)
                {
                    pointer.GetComponent<Renderer>().material.color = Color.grey;
                }
                if (change8 == 10)
                {
                    GradientColorKey[] array = new GradientColorKey[7];
                    array[0].color = Color.red;
                    array[0].time = 0f;
                    array[1].color = Color.yellow;
                    array[1].time = 0.2f;
                    array[2].color = Color.green;
                    array[2].time = 0.3f;
                    array[3].color = Color.cyan;
                    array[3].time = 0.5f;
                    array[4].color = Color.blue;
                    array[4].time = 0.6f;
                    array[5].color = Color.magenta;
                    array[5].time = 0.8f;
                    array[6].color = Color.red;
                    array[6].time = 1f;
                    Gradient gradient = new Gradient();
                    gradient.colorKeys = array;
                    float num = Mathf.PingPong(Time.time / 2f, 1f);
                    Color color = gradient.Evaluate(num);
                    pointer.GetComponent<Renderer>().material.color = color;
                }
                UnityEngine.Object.Destroy(pointer.GetComponent<BoxCollider>());
                UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(pointer.GetComponent<Collider>());
                GameObject bubbles = GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/TurnParent/Main Camera/UnderwaterVisualEffects/UnderwaterParticleEffects/UnderwaterBubbles");
                if (ControllerInputPoller.instance.rightControllerIndexFloat == 1f)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        GameObject newBubble = GameObject.Instantiate(bubbles);
                        newBubble.SetActive(true);
                        newBubble.transform.localScale = new Vector3(1f, 1f, 1f);
                        newBubble.transform.position = pointer.transform.position;

                        GameObject.Destroy(newBubble, 3f);
                    }
                }
            }
            if (pointer != null)
            {
                UnityEngine.Object.Destroy(pointer, Time.deltaTime);
            }
        }

        public static void ParticalGun()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Physics.Raycast(GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position, -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up, out var hitInfo);
                if (change17 == 1)
                {
                    pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    pointer.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                    pointer.transform.position = hitInfo.point;
                }
                if (change17 == 2 | change17 == 3)
                {
                    pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    if (change17 == 2)
                    {
                        UnityEngine.Object.Destroy(pointer.GetComponent<Renderer>());
                    }
                    pointer.transform.position = hitInfo.point;
                    GameObject gameObject2 = new GameObject("Line");
                    Line = gameObject2.AddComponent<LineRenderer>();
                    Line.material.shader = Shader.Find("GUI/Text Shader");
                    Line.startWidth = 0.025f;
                    Line.endWidth = 0.025f;
                    if (change8 == 1)
                    {
                        Line.startColor = Color.blue;
                        Line.endColor = Color.blue;
                    }
                    if (change8 == 2)
                    {
                        Line.startColor = Color.red;
                        Line.endColor = Color.red;
                    }
                    if (change8 == 3)
                    {
                        Line.startColor = Color.white;
                        Line.endColor = Color.white;
                    }
                    if (change8 == 4)
                    {
                        Line.startColor = Color.green;
                        Line.endColor = Color.green;
                    }
                    if (change8 == 5)
                    {
                        Line.startColor = Color.magenta;
                        Line.endColor = Color.magenta;
                    }
                    if (change8 == 6)
                    {
                        Line.startColor = Color.cyan;
                        Line.endColor = Color.cyan;
                    }
                    if (change8 == 7)
                    {
                        Line.startColor = Color.yellow;
                        Line.endColor = Color.yellow;
                    }
                    if (change8 == 8)
                    {
                        Line.startColor = Color.black;
                        Line.endColor = Color.black;
                    }
                    if (change8 == 9)
                    {
                        Line.startColor = Color.grey;
                        Line.endColor = Color.grey;
                    }
                    if (change8 == 10)
                    {
                        GradientColorKey[] array = new GradientColorKey[7];
                        array[0].color = Color.red;
                        array[0].time = 0f;
                        array[1].color = Color.yellow;
                        array[1].time = 0.2f;
                        array[2].color = Color.green;
                        array[2].time = 0.3f;
                        array[3].color = Color.cyan;
                        array[3].time = 0.5f;
                        array[4].color = Color.blue;
                        array[4].time = 0.6f;
                        array[5].color = Color.magenta;
                        array[5].time = 0.8f;
                        array[6].color = Color.red;
                        array[6].time = 1f;
                        Gradient gradient = new Gradient();
                        gradient.colorKeys = array;
                        float num = Mathf.PingPong(Time.time / 2f, 1f);
                        Color color = gradient.Evaluate(num);
                        Line.startColor = color;
                        Line.endColor = color;
                    }
                    Line.positionCount = 2;
                    Line.useWorldSpace = true;
                    Line.SetPosition(0, GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position);
                    Line.SetPosition(1, pointer.transform.position);
                    UnityEngine.Object.Destroy(gameObject2, Time.deltaTime);
                }
                if (change8 == 1)
                {
                    pointer.GetComponent<Renderer>().material.color = Color.blue;
                }
                if (change8 == 2)
                {
                    pointer.GetComponent<Renderer>().material.color = Color.red;
                }
                if (change8 == 3)
                {
                    pointer.GetComponent<Renderer>().material.color = Color.white;
                }
                if (change8 == 4)
                {
                    pointer.GetComponent<Renderer>().material.color = Color.green;
                }
                if (change8 == 5)
                {
                    pointer.GetComponent<Renderer>().material.color = Color.magenta;
                }
                if (change8 == 6)
                {
                    pointer.GetComponent<Renderer>().material.color = Color.cyan;
                }
                if (change8 == 7)
                {
                    pointer.GetComponent<Renderer>().material.color = Color.yellow;
                }
                if (change8 == 8)
                {
                    pointer.GetComponent<Renderer>().material.color = Color.black;
                }
                if (change8 == 9)
                {
                    pointer.GetComponent<Renderer>().material.color = Color.grey;
                }
                if (change8 == 10)
                {
                    GradientColorKey[] array = new GradientColorKey[7];
                    array[0].color = Color.red;
                    array[0].time = 0f;
                    array[1].color = Color.yellow;
                    array[1].time = 0.2f;
                    array[2].color = Color.green;
                    array[2].time = 0.3f;
                    array[3].color = Color.cyan;
                    array[3].time = 0.5f;
                    array[4].color = Color.blue;
                    array[4].time = 0.6f;
                    array[5].color = Color.magenta;
                    array[5].time = 0.8f;
                    array[6].color = Color.red;
                    array[6].time = 1f;
                    Gradient gradient = new Gradient();
                    gradient.colorKeys = array;
                    float num = Mathf.PingPong(Time.time / 2f, 1f);
                    Color color = gradient.Evaluate(num);
                    pointer.GetComponent<Renderer>().material.color = color;
                }
                UnityEngine.Object.Destroy(pointer.GetComponent<BoxCollider>());
                UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(pointer.GetComponent<Collider>());
                if (ControllerInputPoller.instance.rightControllerIndexFloat == 1f)
                {
                    ParticleSystem particleSystem = new GameObject("FireBreath").AddComponent<ParticleSystem>();
                    particleSystem.transform.position = pointer.transform.position;
                    particleSystem.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                    particleSystem.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                    particleSystem.GetComponent<Renderer>().material.color = Settings.ParticalColor;
                    particleSystem.Play();
                    Object.Destroy(particleSystem.gameObject, 0.5f);
                }
            }
            if (pointer != null)
            {
                UnityEngine.Object.Destroy(pointer, Time.deltaTime);
            }
        }

        public static void ParticleSpam()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                ParticleSystem particleSystem = new GameObject("FireBreath").AddComponent<ParticleSystem>();
                particleSystem.transform.position = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position;
                particleSystem.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                particleSystem.transform.rotation = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.rotation;
                particleSystem.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                particleSystem.GetComponent<Renderer>().material.color = Settings.ParticalColor;
                particleSystem.Play();
                Object.Destroy(particleSystem.gameObject, 0.5f);
            }

            if (ControllerInputPoller.instance.leftGrab)
            {
                ParticleSystem particleSystem2 = new GameObject("FireBreath").AddComponent<ParticleSystem>();
                particleSystem2.transform.position = GorillaLocomotion.GTPlayer.Instance.LeftHand.controllerTransform.position;
                particleSystem2.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                particleSystem2.transform.rotation = GorillaLocomotion.GTPlayer.Instance.LeftHand.controllerTransform.rotation;
                particleSystem2.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                particleSystem2.GetComponent<Renderer>().material.color = Settings.ParticalColor;
                particleSystem2.Play();
                Object.Destroy(particleSystem2.gameObject, 0.5f);
            }
        }

        [Obsolete]
        public static void BubbleDUME()
        {
            GameObject bubbles = GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/TurnParent/Main Camera/UnderwaterVisualEffects/UnderwaterParticleEffects/UnderwaterBubbles");
            ParticleSystem component = GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/TurnParent/Main Camera/UnderwaterVisualEffects/UnderwaterParticleEffects/UnderwaterBubbles").GetComponent<ParticleSystem>();
            bubbles.SetActive(true);
            GameObject.Destroy(bubbles, 4f);
            bubbles.transform.position = GorillaLocomotion.GTPlayer.Instance.bodyCollider.transform.position;
            component.startLifetime = 30;
            component.maxParticles = 9999;
            component.emissionRate = 99999;
        }

        public static void FixOldRamp()
        {
            GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/tree/stubbranch").SetActive(false);
        }

        public static void ShowSkeletons()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                {
                    GorillaBodyRenderer.SetAllSkeletons(allSkeletons: true);
                }
            }
        }

        public static void HideSkeletons()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                GorillaBodyRenderer.SetAllSkeletons(allSkeletons: false);
            }
        }
        #endregion
        #region VARS

        public static GameObject pointer;

        public static int change17 = 1;

        public static LineRenderer Line;

        public static int change8 = 1;

        private static float CrystalDelay = 0f;

        public static GameObject RightIndicatorCircle;

        public static GameObject LeftIndicatorCircle;

        public static float farClipPlane = Camera.main.farClipPlane;

        public static bool AntiRepeat = false;

        public static float DrawSize = 0.2f;

        public static GameObject DrawCube = null;

        private static bool ESPStuff = false;

        private static int ESPColor;

        public static float TempLinear;

        public static bool Fps;

        private static int Sky = 0;

        public static Material Mat = new Material(Shader.Find("GorillaTag/UberShader"));

        public static int Ground = 1;

        public static void HideHandHitboxes()
        {
            if (VisualMods.RightIndicatorCircle != null)
            {
                Object.Destroy(VisualMods.RightIndicatorCircle);
                VisualMods.RightIndicatorCircle = null;
            }

            if (VisualMods.LeftIndicatorCircle != null)
            {
                Object.Destroy(VisualMods.LeftIndicatorCircle);
                VisualMods.LeftIndicatorCircle = null;
            }
        }

        public static bool Infected(VRRig rig)
        {
            return rig.mainSkin.material.name.Contains("fected") || rig.mainSkin.material.name.Contains("It");
        }

        public static void FlushRpcs()
        {
            GorillaNot.instance.rpcCallLimit = int.MaxValue;
            PhotonNetwork.RemoveRPCs(PhotonNetwork.LocalPlayer);
            PhotonNetwork.OpCleanActorRpcBuffer(PhotonNetwork.LocalPlayer.ActorNumber);
            PhotonNetwork.OpCleanRpcBuffer(GorillaTagger.Instance.myVRRig.GetView);
            PhotonNetwork.RemoveBufferedRPCs(GorillaTagger.Instance.myVRRig.ViewID, null, null);
        }

        public static void Cube(Vector3 position, Quaternion rotation, Vector3 scale, Color color)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            UnityEngine.Object.Destroy(cube, Time.deltaTime);
            UnityEngine.Object.Destroy(cube.GetComponent<Collider>());
            UnityEngine.Object.Destroy(cube.GetComponent<Rigidbody>());
            cube.transform.position = position;
            cube.transform.localScale = scale;
            cube.transform.rotation = rotation;
            Color clr = color;
            clr.a = 0.25f;
            cube.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
            cube.GetComponent<Renderer>().material.color = Settings.Network;
        }

        public class RGBSkeletonESPClass : MonoBehaviour
        {
            private void Start()
            {
                this.lineRenderer = base.gameObject.AddComponent<LineRenderer>();
                this.lineRenderer.material = new Material(Shader.Find("GUI/Text Shader"));
                this.lineRenderer.startWidth = this.lineWidth;
                this.lineRenderer.endWidth = this.lineWidth;
            }

            private void Update()
            {
                this.DrawSkeleton();
            }

            private void OnDestroy()
            {
                this.ClearLineObjects();
            }

            public void DrawSkeleton()
            {
                this.ClearLineObjects();
                VRRig component = base.GetComponent<VRRig>();
                if (component == null)
                {
                    UnityEngine.Debug.LogWarning("niga2");
                    return;
                }
                Color animatedColor = this.GetAnimatedColor();
                this.DrawLine(component.headMesh.transform.position - new Vector3(0f, 0.35f, 0f), component.headMesh.transform.position, animatedColor);
                this.DrawLine(component.headMesh.transform.position - new Vector3(0f, 0.05f, 0f), component.headMesh.transform.position + component.headMesh.transform.up * 0.2f, animatedColor);
                this.DrawLine(component.headMesh.transform.position - new Vector3(0f, 0.05f, 0f), component.headMesh.transform.position + component.transform.right * -0.15f, animatedColor);
                this.DrawLine(component.headMesh.transform.position - new Vector3(0f, 0.05f, 0f), component.headMesh.transform.position + component.transform.right * 0.15f, animatedColor);
                this.DrawLine(component.headMesh.transform.position + component.transform.right * -0.15f, component.myBodyDockPositions.leftArmTransform.position, animatedColor);
                this.DrawLine(component.headMesh.transform.position + component.transform.right * 0.15f, component.myBodyDockPositions.rightArmTransform.position, animatedColor);
                this.DrawLine(component.myBodyDockPositions.leftArmTransform.position, component.leftHandTransform.position, animatedColor);
                this.DrawLine(component.myBodyDockPositions.rightArmTransform.position, component.rightHandTransform.position, animatedColor);
                this.DrawLine(component.rightHandTransform.position, component.rightThumb.fingerBone1.position, animatedColor);
                this.DrawLine(component.rightThumb.fingerBone1.position, component.rightThumb.fingerBone2.position, animatedColor);
                this.DrawLine(component.rightHandTransform.position, component.rightIndex.fingerBone1.position, animatedColor);
                this.DrawLine(component.rightIndex.fingerBone1.position, component.rightIndex.fingerBone2.position, animatedColor);
                this.DrawLine(component.rightIndex.fingerBone2.position, component.rightIndex.fingerBone3.position, animatedColor);
                this.DrawLine(component.rightHandTransform.position, component.rightMiddle.fingerBone1.position, animatedColor);
                this.DrawLine(component.rightMiddle.fingerBone1.position, component.rightMiddle.fingerBone2.position, animatedColor);
                this.DrawLine(component.rightMiddle.fingerBone2.position, component.rightMiddle.fingerBone3.position, animatedColor);
                this.DrawLine(component.leftHandTransform.position, component.leftThumb.fingerBone1.position, animatedColor);
                this.DrawLine(component.leftThumb.fingerBone1.position, component.leftThumb.fingerBone2.position, animatedColor);
                this.DrawLine(component.leftHandTransform.position, component.leftIndex.fingerBone1.position, animatedColor);
                this.DrawLine(component.leftIndex.fingerBone1.position, component.leftIndex.fingerBone2.position, animatedColor);
                this.DrawLine(component.leftIndex.fingerBone2.position, component.leftIndex.fingerBone3.position, animatedColor);
                this.DrawLine(component.leftHandTransform.position, component.leftMiddle.fingerBone1.position, animatedColor);
                this.DrawLine(component.leftMiddle.fingerBone1.position, component.leftMiddle.fingerBone2.position, animatedColor);
                this.DrawLine(component.leftMiddle.fingerBone2.position, component.leftMiddle.fingerBone3.position, animatedColor);
            }

            private Color GetAnimatedColor()
            {
                float time = Time.time;
                float num = Mathf.Sin(time * 2f) * 0.5f + 0.5f;
                float num2 = Mathf.Sin(time * 1.5f) * 0.5f + 0.5f;
                float num3 = Mathf.Sin(time * 2.5f) * 0.5f + 0.5f;
                return new Color(num, num2, num3);
            }

            private void ClearLineObjects()
            {
                foreach (GameObject gameObject in this.lineObjects)
                {
                    UnityEngine.Object.Destroy(gameObject);
                }
                this.lineObjects.Clear();
            }

            private GameObject CreateLineObject()
            {
                GameObject gameObject = new GameObject("LineObject");
                gameObject.transform.SetParent(base.transform);
                this.lineObjects.Add(gameObject);
                return gameObject;
            }

            private void DrawLine(Vector3 startPos, Vector3 endPos, Color color)
            {
                LineRenderer lineRenderer = this.CreateLineObject().AddComponent<LineRenderer>();
                lineRenderer.material = new Material(Shader.Find("GUI/Text Shader"));
                lineRenderer.startColor = color;
                lineRenderer.endColor = color;
                lineRenderer.startWidth = this.lineWidth;
                lineRenderer.endWidth = this.lineWidth;
                lineRenderer.positionCount = 2;
                lineRenderer.SetPositions(new Vector3[]
                {
                    startPos,
                    endPos
                });
            }

            public Color lineColor = Color.white;
            public float lineWidth = 0.02f;
            private LineRenderer lineRenderer;
            private List<GameObject> lineObjects = new List<GameObject>();

        }
        #endregion
        #region Gun Temp
        public static void Gun()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Physics.Raycast(GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position, -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up, out var hitInfo);
                if (change17 == 1)
                {
                    pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    pointer.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                    pointer.transform.position = hitInfo.point;
                }
                if (change17 == 2 | change17 == 3)
                {
                    pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    if (change17 == 2)
                    {
                        UnityEngine.Object.Destroy(pointer.GetComponent<Renderer>());
                    }
                    pointer.transform.position = hitInfo.point;
                    GameObject gameObject2 = new GameObject("Line");
                    Line = gameObject2.AddComponent<LineRenderer>();
                    Line.material.shader = Shader.Find("GUI/Text Shader");
                    Line.startWidth = 0.025f;
                    Line.endWidth = 0.025f;
                    if (change8 == 1)
                    {
                        Line.startColor = Color.blue;
                        Line.endColor = Color.blue;
                    }
                    if (change8 == 2)
                    {
                        Line.startColor = Color.red;
                        Line.endColor = Color.red;
                    }
                    if (change8 == 3)
                    {
                        Line.startColor = Color.white;
                        Line.endColor = Color.white;
                    }
                    if (change8 == 4)
                    {
                        Line.startColor = Color.green;
                        Line.endColor = Color.green;
                    }
                    if (change8 == 5)
                    {
                        Line.startColor = Color.magenta;
                        Line.endColor = Color.magenta;
                    }
                    if (change8 == 6)
                    {
                        Line.startColor = Color.cyan;
                        Line.endColor = Color.cyan;
                    }
                    if (change8 == 7)
                    {
                        Line.startColor = Color.yellow;
                        Line.endColor = Color.yellow;
                    }
                    if (change8 == 8)
                    {
                        Line.startColor = Color.black;
                        Line.endColor = Color.black;
                    }
                    if (change8 == 9)
                    {
                        Line.startColor = Color.grey;
                        Line.endColor = Color.grey;
                    }
                    if (change8 == 10)
                    {
                        GradientColorKey[] array = new GradientColorKey[7];
                        array[0].color = Color.red;
                        array[0].time = 0f;
                        array[1].color = Color.yellow;
                        array[1].time = 0.2f;
                        array[2].color = Color.green;
                        array[2].time = 0.3f;
                        array[3].color = Color.cyan;
                        array[3].time = 0.5f;
                        array[4].color = Color.blue;
                        array[4].time = 0.6f;
                        array[5].color = Color.magenta;
                        array[5].time = 0.8f;
                        array[6].color = Color.red;
                        array[6].time = 1f;
                        Gradient gradient = new Gradient();
                        gradient.colorKeys = array;
                        float num = Mathf.PingPong(Time.time / 2f, 1f);
                        Color color = gradient.Evaluate(num);
                        Line.startColor = color;
                        Line.endColor = color;
                    }
                    Line.positionCount = 2;
                    Line.useWorldSpace = true;
                    Line.SetPosition(0, GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position);
                    Line.SetPosition(1, pointer.transform.position);
                    UnityEngine.Object.Destroy(gameObject2, Time.deltaTime);
                }
                if (change8 == 1)
                {
                    pointer.GetComponent<Renderer>().material.color = Color.blue;
                }
                if (change8 == 2)
                {
                    pointer.GetComponent<Renderer>().material.color = Color.red;
                }
                if (change8 == 3)
                {
                    pointer.GetComponent<Renderer>().material.color = Color.white;
                }
                if (change8 == 4)
                {
                    pointer.GetComponent<Renderer>().material.color = Color.green;
                }
                if (change8 == 5)
                {
                    pointer.GetComponent<Renderer>().material.color = Color.magenta;
                }
                if (change8 == 6)
                {
                    pointer.GetComponent<Renderer>().material.color = Color.cyan;
                }
                if (change8 == 7)
                {
                    pointer.GetComponent<Renderer>().material.color = Color.yellow;
                }
                if (change8 == 8)
                {
                    pointer.GetComponent<Renderer>().material.color = Color.black;
                }
                if (change8 == 9)
                {
                    pointer.GetComponent<Renderer>().material.color = Color.grey;
                }
                if (change8 == 10)
                {
                    GradientColorKey[] array = new GradientColorKey[7];
                    array[0].color = Color.red;
                    array[0].time = 0f;
                    array[1].color = Color.yellow;
                    array[1].time = 0.2f;
                    array[2].color = Color.green;
                    array[2].time = 0.3f;
                    array[3].color = Color.cyan;
                    array[3].time = 0.5f;
                    array[4].color = Color.blue;
                    array[4].time = 0.6f;
                    array[5].color = Color.magenta;
                    array[5].time = 0.8f;
                    array[6].color = Color.red;
                    array[6].time = 1f;
                    Gradient gradient = new Gradient();
                    gradient.colorKeys = array;
                    float num = Mathf.PingPong(Time.time / 2f, 1f);
                    Color color = gradient.Evaluate(num);
                    pointer.GetComponent<Renderer>().material.color = color;
                }
                UnityEngine.Object.Destroy(pointer.GetComponent<BoxCollider>());
                UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(pointer.GetComponent<Collider>());
                if (ControllerInputPoller.instance.rightControllerIndexFloat == 1f)
                {

                }
            }
            if (pointer != null)
            {
                UnityEngine.Object.Destroy(pointer, Time.deltaTime);
            }
        }
        #endregion 
    }
}
