using BepInEx;
using ExitGames.Client.Photon;
using Fusion;
using GorillaExtensions;
using GorillaLocomotion;
using GorillaLocomotion.Climbing;
using GorillaLocomotion.Gameplay;
using GorillaNetworking;
using GorillaTagScripts;
using HarmonyLib;
using Photon.Pun;
using Photon.Realtime;
using POpusCodec.Enums;
using StupidTemplate.Classes;
using StupidTemplate.Managers;
using StupidTemplate.Menu;
using StupidTemplate.Notifications;
using StupidTemplate.Patches;
using StupidTemplate.Patches.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Technie.PhysicsCreator.QHull;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;
using static BetterDayNightManager;
using static Oculus.Interaction.PointableCanvasModule;
using Debug = UnityEngine.Debug;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace StupidTemplate.Mods
{
    internal class WaterMods
    {
        #region Water
        public static void AirSwim()
        {
            if (AirSwimEffect == null)
            {
                AirSwimEffect = UnityEngine.Object.Instantiate<GameObject>(GameObject.Find("Environment Objects/LocalObjects_Prefab/ForestToBeach/ForestToBeach_Prefab_V4/CaveWaterVolume"));
                AirSwimEffect.transform.localScale = new Vector3(5f, 5f, 5f);
                AirSwimEffect.GetComponent<Renderer>().enabled = false;
            }
            else
            {
                GorillaLocomotion.GTPlayer.Instance.audioManager.UnsetMixerSnapshot(0.1f);
                AirSwimEffect.transform.position = GorillaTagger.Instance.headCollider.transform.position + new Vector3(0f, 2.5f, 0f);
            }
        }

        public static void WaterBeam()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Transform hand = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform;
                Vector3 origin = hand.position;
                Vector3 dir = -hand.up;

                for (int i = 0; i < 10; i++)
                {
                    Vector3 pos = origin + dir * (i * 1.2f);

                    GorillaTagger.Instance.myVRRig.GetView.RPC("RPC_PlaySplashEffect", 0, new object[]
                    {
                       pos,
                       Quaternion.identity,
                       0.6f,
                       160f,
                       false,
                       false
                    });
                }
                FlushRpcs();
            }
        }

        public static void SplachWaterAura()
        {
            if (ControllerInputPoller.instance.rightControllerIndexFloat == 1f)
            {
                foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                {
                    if (Vector3.Distance(vrrig.transform.position, RigManager.GetOwnVRRig().transform.position) <= 9 && vrrig.playerText1.text != PhotonNetwork.LocalPlayer.NickName && vrrig.playerText1.text != PhotonNetwork.LocalPlayer.NickName)
                    {
                        GorillaTagger.Instance.myVRRig.GetView.RPC("RPC_PlaySplashEffect", 0, new object[]
                        {
                            vrrig.transform.position,
                            UnityEngine.Random.rotation,
                            4f,
                            100f,
                            true,
                            false
                        });
                    }
                }
            }
        }

        public static void DisableWater()
        {
            GameObject water = GameObject.Find("Beach/B_WaterVolumes");
            Transform waterTransform = water.transform;
            for (int i = 0; i < waterTransform.childCount; i++)
            {
                GameObject v = waterTransform.GetChild(i).gameObject;
                v.layer = LayerMask.NameToLayer("TransparentFX");
            }
        }

        public static void SolidWater()
        {
            GameObject water = GameObject.Find("Beach/B_WaterVolumes");
            Transform waterTransform = water.transform;
            for (int i = 0; i < waterTransform.childCount; i++)
            {
                GameObject v = waterTransform.GetChild(i).gameObject;
                v.layer = LayerMask.NameToLayer("Default");
            }
        }

        public static void FixWater()
        {
            GameObject water = GameObject.Find("Beach/B_WaterVolumes");
            Transform waterTransform = water.transform;
            for (int i = 0; i < waterTransform.childCount; i++)
            {
                GameObject v = waterTransform.GetChild(i).gameObject;
                v.layer = LayerMask.NameToLayer("Water");
            }
        }

        public static void FastSwim()
        {
            if (GorillaLocomotion.GTPlayer.Instance.InWater)
            {
                GorillaLocomotion.GTPlayer.Instance.gameObject.GetComponent<Rigidbody>().velocity *= 1.039f;
            }
        }

        public static void DisableAirSwim()
        {
            if (AirSwimEffect != null)
            {
                UnityEngine.Object.Destroy(AirSwimEffect);
            }
        }

        public static void ChangeSizeOfWater()
        {
            if (ControllerInputPoller.instance.rightGrab && ControllerInputPoller.instance.leftGrab)
            {
                FlushRpcs();
                Vector3 position = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.transform.position;
                Vector3 position2 = GorillaLocomotion.GTPlayer.Instance.LeftHand.controllerTransform.transform.position;
                Quaternion rotation = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.transform.rotation;
                Quaternion rotation2 = GorillaLocomotion.GTPlayer.Instance.LeftHand.controllerTransform.transform.rotation;
                Vector3 vector = (position + position2) / 2f;
                Quaternion quaternion = Quaternion.Lerp(rotation, rotation2, 0.5f);
                float num = Vector3.Distance(position, position2);
                GorillaTagger.Instance.myVRRig.GetView.RPC("RPC_PlaySplashEffect", 0, new object[]
                {
                     vector,
                     quaternion,
                     num,
                     num,
                     false,
                     true
                });
            }
            else
            {
                if (ControllerInputPoller.instance.rightGrab)
                {
                    FlushRpcs();
                    GorillaTagger.Instance.myVRRig.GetView.RPC("RPC_PlaySplashEffect", 0, new object[]
                    {
                         GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.transform.position,
                         GorillaTagger.Instance.offlineVRRig.transform.rotation,
                         0.3f,
                         0.3f,
                         false,
                         true
                    });
                }
                if (ControllerInputPoller.instance.leftGrab)
                {
                    FlushRpcs();
                    GorillaTagger.Instance.myVRRig.GetView.RPC("RPC_PlaySplashEffect", 0, new object[]
                    {
                         GorillaLocomotion.GTPlayer.Instance.LeftHand.controllerTransform.transform.position,
                         GorillaTagger.Instance.offlineVRRig.transform.rotation,
                         0.3f,
                         0.3f,
                         false,
                         true
                    });
                }
            }
            if (ControllerInputPoller.instance.rightControllerSecondaryButton)
            {
                Vector3 position3 = GorillaTagger.Instance.offlineVRRig.headMesh.transform.position;
                Quaternion quaternion2 = Quaternion.Euler(90f, 0f, 0f);
                GorillaTagger.Instance.myVRRig.GetView.RPC("RPC_PlaySplashEffect", 0, new object[]
                {
                     position3 + new Vector3(0f, 0.5f, 0f),
                     quaternion2,
                     0.3f,
                     0.3f,
                     false,
                     false
                });
            }
        }

        public static void WaterGun()
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
                    RigManager.GetOwnVRRig().enabled = false;
                    RigManager.GetOwnVRRig().transform.position = pointer.transform.position;
                    GorillaTagger.Instance.myVRRig.GetView.RPC("RPC_PlaySplashEffect", 0, new object[]
                        {
                            RigManager.GetOwnVRRig().transform.position,
                            UnityEngine.Random.rotation,
                            4f,
                            100f,
                            true,
                            false
                        });
                    FlushRpcs();
                    RigManager.GetOwnVRRig().enabled = true;
                }

            }
            if (pointer != null)
            {
                UnityEngine.Object.Destroy(pointer, Time.deltaTime);
            }
        }

        public static void WaterBender()
        {
            if (ControllerInputPoller.instance.rightGrab && Time.time > WaterMods.WaterBendDelay + 0.4f)
            {
                WaterMods.WaterBendDelay = Time.time;
                GorillaTagger.Instance.myVRRig.GetView.RPC("RPC_PlaySplashEffect", 0, new object[]
                {
            GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position,
            GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.rotation,
            1f,
            250f,
            true,
            false
                });
            }
            if (ControllerInputPoller.instance.leftGrab && Time.time > WaterMods.WaterBendDelay + 0.4f)
            {
                WaterMods.WaterBendDelay = Time.time;
                GorillaTagger.Instance.myVRRig.GetView.RPC("RPC_PlaySplashEffect", 0, new object[]
                {
            GorillaLocomotion.GTPlayer.Instance.LeftHand.controllerTransform.position,
            GorillaLocomotion.GTPlayer.Instance.LeftHand.controllerTransform.rotation,
            1f,
            250f,
            true,
            false
                });
            }
        }

        public static void SplachSelf()
        {
            if (ControllerInputPoller.instance.rightControllerIndexFloat == 1f && WaterDelay < Time.time)
            {
                WaterDelay = Time.time + 0.5f;
                GorillaTagger.Instance.myVRRig.GetView.RPC("RPC_PlaySplashEffect", 0, new object[]
                {
                            RigManager.GetOwnVRRig().transform.position,
                            UnityEngine.Random.rotation,
                            4f,
                            100f,
                            true,
                            false
                });
            }
        }

        public static void WaterVortex()
        {
            if (ControllerInputPoller.instance.rightControllerIndexFloat == 1f)
            {
                if (WaterVortexInstance == null)
                {
                    FlushRpcs();

                    WaterVortexInstance = new GameObject("WaterVortex");
                    WaterVortexInstance.transform.position = RigManager.GetOwnVRRig().transform.position;
                    WaterVortexStopTime = Time.time + 6f;

                    GorillaTagger.Instance.myVRRig.GetView.RPC("RPC_PlaySplashEffect", 0, new object[]
                    {
                       WaterVortexInstance .transform.position,
                       Quaternion.identity,
                       2.5f,
                       400f,
                       false,
                       true
                    });
                }
            }

            if (WaterVortexInstance != null)
            {
                WaterVortexInstance.transform.Rotate(Vector3.up * 220f * Time.deltaTime);

                int rings = 6;
                float heightStep = 0.6f;
                float radiusStart = 1.2f;
                float radiusEnd = 0.3f;
                float spin = Time.time * 4f;

                for (int i = 0; i < rings; i++)
                {
                    float t = (float)i / rings;
                    float height = t * (rings * heightStep);
                    float radius = Mathf.Lerp(radiusStart, radiusEnd, t);
                    float angle = spin + (i * 0.6f);

                    Vector3 offset = new Vector3(
                        Mathf.Cos(angle) * radius,
                        height,
                        Mathf.Sin(angle) * radius
                    );

                    Vector3 splashPos = WaterVortexInstance.transform.position + offset;

                    GorillaTagger.Instance.myVRRig.GetView.RPC("RPC_PlaySplashEffect", 0, new object[]
                    {
                splashPos,
                Quaternion.identity,
                0.9f,
                75f,
                false,
                false
                    });
                }

                if (Time.time >= WaterVortexNextSplashTime)
                {
                    WaterVortexNextSplashTime = Time.time + 0.3f;

                    float radius = 5f;

                    foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                    {
                        if (vrrig == null) continue;

                        float dist = Vector3.Distance(vrrig.transform.position, WaterVortexInstance.transform.position);

                        if (dist <= radius)
                        {
                            if (vrrig == RigManager.GetOwnVRRig())
                            {
                                Rigidbody rb = GorillaLocomotion.GTPlayer.Instance.gameObject.GetComponent<Rigidbody>();
                                if (rb != null)
                                    rb.velocity += Vector3.up * 9f;
                            }

                            GorillaTagger.Instance.myVRRig.GetView.RPC("RPC_PlaySplashEffect", 0, new object[]
                            {
                        vrrig.transform.position,
                        UnityEngine.Random.rotation,
                        1.8f,
                        300f,
                        true,
                        false
                            });
                        }
                    }
                }

                if (Time.time >= WaterVortexStopTime)
                {
                    UnityEngine.Object.Destroy(WaterVortexInstance);
                    WaterVortexInstance = null;
                    FlushRpcs();
                }
            }
        }
        #endregion
        #region Vars
        public static GameObject WaterVortexInstance = null;

        public static float WaterVortexStopTime = 0f;

        public static float WaterVortexNextSplashTime = 0f;

        public static GameObject AirSwimEffect = null;

        public static float WaterBendDelay;

        public static float WaterDelay = 0f;

        public static GameObject pointer;

        public static int change17 = 1;

        public static int change8 = 1;

        public static LineRenderer Line;

        public static void FlushRpcs()
        {
            GorillaNot.instance.rpcCallLimit = int.MaxValue;
            PhotonNetwork.RemoveRPCs(PhotonNetwork.LocalPlayer);
            PhotonNetwork.OpCleanActorRpcBuffer(PhotonNetwork.LocalPlayer.ActorNumber);
            PhotonNetwork.OpCleanRpcBuffer(GorillaTagger.Instance.myVRRig.GetView);
            PhotonNetwork.RemoveBufferedRPCs(GorillaTagger.Instance.myVRRig.ViewID, null, null);
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
