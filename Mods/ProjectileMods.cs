using ExitGames.Client.Photon;
using GorillaLocomotion;
using Photon.Pun;
using Photon.Realtime;
using StupidTemplate.Classes;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;
using static FlockingManager;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace StupidTemplate.Mods
{
    internal class ProjectileMods
    {
        #region Projectiles
        public static void HaveAPeriod()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Vector3 POS = GorillaTagger.Instance.bodyCollider.transform.position + new Vector3(0f, -0.2f, 0f);

                Vector3 velocity = Vector3.zero;

                ProjectileMods.SnowballLaunchJPX(GorillaTagger.Instance.rightHandTransform.position + GorillaTagger.Instance.rightHandTransform.forward * 0.2f, Vector3.zero, 0);

            }
        }

        public static void RapidFireSlingshot()//WIP
        {
            if (!ControllerInputPoller.instance.rightControllerPrimaryButton)
                return;

            Slingshot sling = UnityEngine.Object.FindObjectOfType<Slingshot>();
            if (sling == null)
            {
                Debug.LogError("Slingshot not found — make sure it's equipped.");
                return;
            }

            FieldInfo minLaunch = typeof(Slingshot).GetField("minTimeToLaunch",
                BindingFlags.NonPublic | BindingFlags.Instance);

            if (minLaunch != null)
            {
                minLaunch.SetValue(sling, Time.time - 1f);
            }

            ControllerInputPoller.instance.rightControllerIndexFloat =
                Codes.lastSlingThing ? 1f : 0f;

            Codes.lastSlingThing = !Codes.lastSlingThing;
        }

        public static void BlindAll()
        {
            VRRig randomRig = RigManager.GetRandomVRRig(false);

            Vector3 POS = randomRig.headMesh.transform.position + (randomRig.headMesh.transform.forward * 0.5f);
            Vector3 velocity = Vector3.zero;

            ProjectileMods.WaterBalloonLaunchJPX(GorillaTagger.Instance.rightHandTransform.position + GorillaTagger.Instance.rightHandTransform.forward * 0.2f, Vector3.zero);
        }

        public static void RainbowSnowballs()
        {
            if (ProjectileMods.RGBSnowballStuff < Time.time)
            {
                foreach (SnowballThrowable snowballThrowable in UnityEngine.Object.FindObjectsOfType<SnowballThrowable>())
                {
                    if (!snowballThrowable.randomizeColor)
                    {
                        snowballThrowable.randomizeColor = true;
                    }
                }
                ProjectileMods.RGBSnowballStuff = Time.time + 0.1f;
            }
        }

        public static void FastThrower()
        {
            foreach (SnowballMaker Maker in new[] { SnowballMaker.leftHandInstance, SnowballMaker.rightHandInstance })
            {
                foreach (SnowballThrowable Throwable in Maker.snowballs)
                {
                    Throwable.linSpeedMultiplier = 10f;
                    Throwable.maxLinSpeed = 99999f;
                }
            }
        }

        public static void SlowSnowballs()
        {
            foreach (SnowballMaker Maker in new[] { SnowballMaker.leftHandInstance, SnowballMaker.rightHandInstance })
            {
                foreach (SnowballThrowable Throwable in Maker.snowballs)
                {
                    Throwable.linSpeedMultiplier = 0.2f;
                    Throwable.maxLinSpeed = 6f;
                }
            }
        }

        public static void FixSnowballs()
        {
            foreach (SnowballMaker Maker in new[] { SnowballMaker.leftHandInstance, SnowballMaker.rightHandInstance })
            {
                foreach (SnowballThrowable Throwable in Maker.snowballs)
                {
                    Throwable.linSpeedMultiplier = 1f;
                    Throwable.maxLinSpeed = 12f;
                }
            }
        }

        public static void ThrowPoop()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Vector3 POS = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position;
                Vector3 velocity = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 600;
                ProjectileMods.SnowballLaunchJPX(GorillaTagger.Instance.rightHandTransform.position + GorillaTagger.Instance.rightHandTransform.forward * 0.2f, Vector3.zero, 0);
            }
        }

        public static void PeriodLanucher()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Vector3 POS = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position;
                Vector3 velocity = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 600;
                ProjectileMods.SnowballLaunchJPX(GorillaTagger.Instance.rightHandTransform.position + GorillaTagger.Instance.rightHandTransform.forward * 0.2f, Vector3.zero, 0);
            }
        }

        public static void WaterHose()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Vector3 POS = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position;
                Vector3 velocity = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 600;
                ProjectileMods.SnowballLaunchJPX(GorillaTagger.Instance.rightHandTransform.position + GorillaTagger.Instance.rightHandTransform.forward * 0.2f, Vector3.zero, 0);
            }
        }

        public static void Vomit()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Vector3 POS = GorillaTagger.Instance.headCollider.transform.position
                            + GorillaTagger.Instance.headCollider.transform.forward * 0.1f
                            + GorillaTagger.Instance.headCollider.transform.up * -0.15f;

                Vector3 velocity = GorillaTagger.Instance.headCollider.transform.forward * 8.33f;
                ProjectileMods.SnowballLaunchJPX(GorillaTagger.Instance.rightHandTransform.position + GorillaTagger.Instance.rightHandTransform.forward * 0.2f, Vector3.zero, 0);
            }
        }

        public static void LaserPee()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Vector3 POS = GorillaLocomotion.GTPlayer.Instance.bodyCollider.transform.position + new Vector3(0f, -0.1f, 0f);
                Vector3 velocity = GorillaLocomotion.GTPlayer.Instance.bodyCollider.transform.forward * Time.deltaTime * 1000f;
                ProjectileMods.SnowballLaunchJPX(GorillaTagger.Instance.rightHandTransform.position + GorillaTagger.Instance.rightHandTransform.forward * 0.2f, Vector3.zero, 0);
            }
        }

        public static void Pee()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Vector3 POS = GorillaLocomotion.GTPlayer.Instance.bodyCollider.transform.position + new Vector3(0f, -0.1f, 0f);
                Vector3 velocity = GorillaLocomotion.GTPlayer.Instance.bodyCollider.transform.forward * Time.deltaTime * 145f;
                ProjectileMods.SnowballLaunchJPX(GorillaTagger.Instance.rightHandTransform.position + GorillaTagger.Instance.rightHandTransform.forward * 0.2f, Vector3.zero, 0);
            }
        }

        public static void ClosePee()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Vector3 POS = GorillaLocomotion.GTPlayer.Instance.bodyCollider.transform.position + new Vector3(0f, -0.1f, 0f);
                Vector3 velocity = GorillaLocomotion.GTPlayer.Instance.bodyCollider.transform.forward * Time.deltaTime * 45f;
                ProjectileMods.SnowballLaunchJPX(GorillaTagger.Instance.rightHandTransform.position + GorillaTagger.Instance.rightHandTransform.forward * 0.2f, Vector3.zero, 0);
            }
        }

        public static void LaserCum()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Vector3 POS = GorillaLocomotion.GTPlayer.Instance.bodyCollider.transform.position + new Vector3(0f, -0.1f, 0f);
                Vector3 velocity = GorillaLocomotion.GTPlayer.Instance.bodyCollider.transform.forward * Time.deltaTime * 1000f;
                ProjectileMods.SnowballLaunchJPX(GorillaTagger.Instance.rightHandTransform.position + GorillaTagger.Instance.rightHandTransform.forward * 0.2f, Vector3.zero, 0);
            }
        }

        public static void Cum()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Vector3 POS = GorillaLocomotion.GTPlayer.Instance.bodyCollider.transform.position + new Vector3(0f, -0.1f, 0f);
                Vector3 velocity = GorillaLocomotion.GTPlayer.Instance.bodyCollider.transform.forward * Time.deltaTime * 145f;
                ProjectileMods.SnowballLaunchJPX(GorillaTagger.Instance.rightHandTransform.position + GorillaTagger.Instance.rightHandTransform.forward * 0.2f, Vector3.zero, 0);
            }
        }

        public static void CloseCum()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Vector3 POS = GorillaLocomotion.GTPlayer.Instance.bodyCollider.transform.position + new Vector3(0f, -0.1f, 0f);
                Vector3 velocity = GorillaLocomotion.GTPlayer.Instance.bodyCollider.transform.forward * Time.deltaTime * 45f;
                ProjectileMods.SnowballLaunchJPX(GorillaTagger.Instance.rightHandTransform.position + GorillaTagger.Instance.rightHandTransform.forward * 0.2f, Vector3.zero, 0);
            }
        }

        public static void Poop()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Vector3 position = GorillaTagger.Instance.bodyCollider.transform.position + new Vector3(0f, -0.2f, 0f);
                Vector3 zero = Vector3.zero;
                ProjectileMods.SnowballLaunchJPX(GorillaTagger.Instance.rightHandTransform.position + GorillaTagger.Instance.rightHandTransform.forward * 0.2f, Vector3.zero, 0);
            }
        }

        public static void ImpactOrbit()
        {
            if (PhotonNetwork.InRoom)
            {
                OrbitAndHaloAngle += OrbitAndHaloSpeed * Time.deltaTime;
                float num3 = 1.0f;
                Vector3 vector = GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(0f, 1f, 0f);
                Vector3 vector2 = new Vector3(Mathf.Cos(OrbitAndHaloAngle), 0f, Mathf.Sin(OrbitAndHaloAngle)) * num3;
                Vector3 vector3 = vector + vector2 * Time.deltaTime * 5f;
                ImpactSpamThing(vector3, Color.red);
            }
        }

        public static void ImpactAroundSelf()
        {
            if (PhotonNetwork.InRoom)
            {
                Vector3 vector = Random.insideUnitSphere.normalized * (float)Random.Range(0, 6);
                if (ControllerInputPoller.instance.rightControllerIndexFloat > 0f)
                {
                    ProjectileMods.ImpactSpamThing(GorillaTagger.Instance.offlineVRRig.transform.position + vector, Color.red);
                }
            }
        }

        public static void ImpactAll()
        {
            if (PhotonNetwork.InRoom)
            {
                foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                {
                    if (ControllerInputPoller.instance.rightControllerIndexFloat > 0f)
                    {
                        ProjectileMods.ImpactSpamThing(vrrig.transform.position, vrrig.playerColor);
                    }
                }
            }
        }

        public static void ImpactSpam()
        {
            if (PhotonNetwork.InRoom)
            {
                if (ControllerInputPoller.instance.rightGrab)
                {
                    ProjectileMods.ImpactSpamThing(GorillaTagger.Instance.rightHandTransform.position, Color.red);
                }

                if (ControllerInputPoller.instance.leftGrab)
                {
                    ProjectileMods.ImpactSpamThing(GorillaTagger.Instance.leftHandTransform.position, Color.red);
                }
            }
        }

        public static void ImpactGun()
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
                    if (PhotonNetwork.InRoom)
                    {
                        ProjectileMods.ImpactSpamThing(Codes.pointer.transform.position, Color.blue);
                    }
                }
            }
            if (pointer != null)
            {
                UnityEngine.Object.Destroy(pointer, Time.deltaTime);
            }
        }

        public static void SnowballSpam()
        {
            if (PhotonNetwork.InRoom && ControllerInputPoller.instance.rightGrab)
            {
                ProjectileMods.SnowballLaunchJPX(GorillaTagger.Instance.rightHandTransform.position + GorillaTagger.Instance.rightHandTransform.forward * 0.2f, Vector3.zero, 0);
            }
        }

        public static void SnowballLauncher()
        {
            if (PhotonNetwork.InRoom && ControllerInputPoller.instance.rightGrab)
            {
                Vector3 position = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position;
                Vector3 velocity = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 600f;
                ProjectileMods.SnowballLaunchJPX(position, velocity);
            }
        }

        public static void SnowballImpact()
        {
            if (PhotonNetwork.InRoom && ControllerInputPoller.instance.rightGrab)
            {
                Vector3 position = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position;
                Vector3 velocity = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 80000;
                ProjectileMods.SnowballLaunchJPX(position, velocity);
            }
        }

        public static void SnowballRain()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Vector3 position = GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(Random.Range(-5f, 5f), 5f, Random.Range(-5f, 5f));
                Vector3 velocity = GorillaLocomotion.GTPlayer.Instance.InstantaneousVelocity;
                ProjectileMods.SnowballLaunchJPX(position, velocity);
            }
        }

        public static void WaterBallonSpam()
        {
            if (PhotonNetwork.InRoom && ControllerInputPoller.instance.rightGrab)
            {
                ProjectileMods.WaterBalloonLaunchJPX(GorillaTagger.Instance.rightHandTransform.position + GorillaTagger.Instance.rightHandTransform.forward * 0.2f, Vector3.zero);
            }
        }

        public static void WaterBallonLauncher()
        {
            if (PhotonNetwork.InRoom && ControllerInputPoller.instance.rightGrab)
            {
                Vector3 position = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position;
                Vector3 velocity = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 600f;
                ProjectileMods.WaterBalloonLaunchJPX(position, velocity);
            }
        }

        public static void WaterBallonImpact()
        {
            if (PhotonNetwork.InRoom && ControllerInputPoller.instance.rightGrab)
            {
                Vector3 position = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position;
                Vector3 velocity = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 80000;
                ProjectileMods.WaterBalloonLaunchJPX(position, velocity);
            }
        }

        public static void WaterBallonRain()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Vector3 position = GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(Random.Range(-5f, 5f), 5f, Random.Range(-5f, 5f));
                Vector3 velocity = GorillaLocomotion.GTPlayer.Instance.InstantaneousVelocity;
                ProjectileMods.WaterBalloonLaunchJPX(position, velocity);
            }
        }

        public static void PresentSpam()
        {
            if (PhotonNetwork.InRoom && ControllerInputPoller.instance.rightGrab)
            {
                ProjectileMods.PresentLaunchJPX(GorillaTagger.Instance.rightHandTransform.position + GorillaTagger.Instance.rightHandTransform.forward * 0.2f, Vector3.zero);
            }
        }

        public static void PresentLauncher()
        {
            if (PhotonNetwork.InRoom && ControllerInputPoller.instance.rightGrab)
            {
                Vector3 position = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position;
                Vector3 velocity = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 600f;
                ProjectileMods.PresentLaunchJPX(position, velocity);
            }
        }

        public static void PresentImpact()
        {
            if (PhotonNetwork.InRoom && ControllerInputPoller.instance.rightGrab)
            {
                Vector3 position = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position;
                Vector3 velocity = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 80000;
                ProjectileMods.PresentLaunchJPX(position, velocity);
            }
        }

        public static void PresentRain()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Vector3 position = GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(Random.Range(-5f, 5f), 5f, Random.Range(-5f, 5f));
                Vector3 velocity = GorillaLocomotion.GTPlayer.Instance.InstantaneousVelocity;
                ProjectileMods.PresentLaunchJPX(position, velocity);
            }
        }

        public static void MentosSpam()
        {
            if (PhotonNetwork.InRoom && ControllerInputPoller.instance.rightGrab)
            {
                ProjectileMods.MentosLaunchJPX(GorillaTagger.Instance.rightHandTransform.position + GorillaTagger.Instance.rightHandTransform.forward * 0.2f, Vector3.zero);
            }
        }

        public static void MentosLauncher()
        {
            if (PhotonNetwork.InRoom && ControllerInputPoller.instance.rightGrab)
            {
                Vector3 position = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position;
                Vector3 velocity = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 600f;
                ProjectileMods.MentosLaunchJPX(position, velocity);
            }
        }

        public static void MentosImpact()
        {
            if (PhotonNetwork.InRoom && ControllerInputPoller.instance.rightGrab)
            {
                Vector3 position = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position;
                Vector3 velocity = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 80000;
                ProjectileMods.MentosLaunchJPX(position, velocity);
            }
        }

        public static void MentosRain()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Vector3 position = GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(Random.Range(-5f, 5f), 5f, Random.Range(-5f, 5f));
                Vector3 velocity = GorillaLocomotion.GTPlayer.Instance.InstantaneousVelocity;
                ProjectileMods.MentosLaunchJPX(position, velocity);
            }
        }

        public static void FishFoodSpam()
        {
            if (PhotonNetwork.InRoom && ControllerInputPoller.instance.rightGrab)
            {
                ProjectileMods.FishFoodJPX(GorillaTagger.Instance.rightHandTransform.position + GorillaTagger.Instance.rightHandTransform.forward * 0.2f, Vector3.zero);
            }
        }

        public static void FishFoodLauncher()
        {
            if (PhotonNetwork.InRoom && ControllerInputPoller.instance.rightGrab)
            {
                Vector3 position = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position;
                Vector3 velocity = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 600f;
                ProjectileMods.FishFoodJPX(position, velocity);
            }
        }

        public static void FishFoodImpact()
        {
            if (PhotonNetwork.InRoom && ControllerInputPoller.instance.rightGrab)
            {
                Vector3 position = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position;
                Vector3 velocity = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 80000;
                ProjectileMods.FishFoodJPX(position, velocity);
            }
        }

        public static void FishFoodRain()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Vector3 position = GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(Random.Range(-5f, 5f), 5f, Random.Range(-5f, 5f));
                Vector3 velocity = GorillaLocomotion.GTPlayer.Instance.InstantaneousVelocity;
                ProjectileMods.FishFoodJPX(position, velocity);
            }
        }

        public static void VotingRockSpam()
        {
            if (PhotonNetwork.InRoom && ControllerInputPoller.instance.rightGrab)
            {
                ProjectileMods.VotingRockJPX(GorillaTagger.Instance.rightHandTransform.position + GorillaTagger.Instance.rightHandTransform.forward * 0.2f, Vector3.zero);
            }
        }

        public static void VotingRockLauncher()
        {
            if (PhotonNetwork.InRoom && ControllerInputPoller.instance.rightGrab)
            {
                Vector3 position = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position;
                Vector3 velocity = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 600f;
                ProjectileMods.VotingRockJPX(position, velocity);
            }
        }

        public static void VotingRockImpact()
        {
            if (PhotonNetwork.InRoom && ControllerInputPoller.instance.rightGrab)
            {
                Vector3 position = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position;
                Vector3 velocity = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 80000;
                ProjectileMods.VotingRockJPX(position, velocity);
            }
        }

        public static void VotingRockRain()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Vector3 position = GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(Random.Range(-5f, 5f), 5f, Random.Range(-5f, 5f));
                Vector3 velocity = GorillaLocomotion.GTPlayer.Instance.InstantaneousVelocity;
                ProjectileMods.VotingRockJPX(position, velocity);
            }
        }

        public static void CandySpam()
        {
            if (PhotonNetwork.InRoom && ControllerInputPoller.instance.rightGrab)
            {
                ProjectileMods.CandyJPX(GorillaTagger.Instance.rightHandTransform.position + GorillaTagger.Instance.rightHandTransform.forward * 0.2f, Vector3.zero);
            }
        }

        public static void CandyLauncher()
        {
            if (PhotonNetwork.InRoom && ControllerInputPoller.instance.rightGrab)
            {
                Vector3 position = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position;
                Vector3 velocity = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 600f;
                ProjectileMods.CandyJPX(position, velocity);
            }
        }

        public static void CandyImpact()
        {
            if (PhotonNetwork.InRoom && ControllerInputPoller.instance.rightGrab)
            {
                Vector3 position = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position;
                Vector3 velocity = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 80000;
                ProjectileMods.CandyJPX(position, velocity);
            }
        }

        public static void CandyRain()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Vector3 position = GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(Random.Range(-5f, 5f), 5f, Random.Range(-5f, 5f));
                Vector3 velocity = GorillaLocomotion.GTPlayer.Instance.InstantaneousVelocity;
                ProjectileMods.CandyJPX(position, velocity);
            }
        }

        public static void AppleSpam()
        {
            if (PhotonNetwork.InRoom && ControllerInputPoller.instance.rightGrab)
            {
                ProjectileMods.ApplesJPX(GorillaTagger.Instance.rightHandTransform.position + GorillaTagger.Instance.rightHandTransform.forward * 0.2f, Vector3.zero);
            }
        }

        public static void AppleLauncher()
        {
            if (PhotonNetwork.InRoom && ControllerInputPoller.instance.rightGrab)
            {
                Vector3 position = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position;
                Vector3 velocity = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 600f;
                ProjectileMods.ApplesJPX(position, velocity);
            }
        }

        public static void AppleImpact()
        {
            if (PhotonNetwork.InRoom && ControllerInputPoller.instance.rightGrab)
            {
                Vector3 position = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position;
                Vector3 velocity = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 80000;
                ProjectileMods.ApplesJPX(position, velocity);
            }
        }

        public static void AppleRain()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Vector3 position = GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(Random.Range(-5f, 5f), 5f, Random.Range(-5f, 5f));
                Vector3 velocity = GorillaLocomotion.GTPlayer.Instance.InstantaneousVelocity;
                ProjectileMods.ApplesJPX(position, velocity);
            }
        }

        #endregion
        #region VARS
        private static float SnowballCD;

        private static float WaterBalloonCD;

        private static float PresentCD;

        private static float MentosCD;

        private static float FishFoodCD;

        private static float VotingRockCD;

        private static float CandyCD;

        private static float ApplesCD;

        private static float RGBSnowballStuff;

        private static float OrbitAndHaloAngle;

        public static float OrbitAndHaloSpeed = 5f;

        public static float ImpactDelay;

        public static int Count;

        public static LineRenderer Line;

        public static GameObject pointer;

        public static int change17 = 1;

        public static int change8 = 1;

        public static void SnowballLaunchJPX(Vector3 position, Vector3 velocity, int size = 0)
        {
            if (EquipmentInteractor.instance.leftHandHeldEquipment is GrowingSnowballThrowable)
            {
                EquipmentInteractor.instance.leftHandHeldEquipment.gameObject.transform.position =
                    GTPlayer.Instance.LeftHand.controllerTransform.position;
            }
            if (Time.time > ProjectileMods.SnowballCD)
            {
                ProjectileMods.SnowballCD = Time.time + 0.225f;
                if (EquipmentInteractor.instance.leftHandHeldEquipment == null)
                {
                    SnowballThrowable snowballThrowable;
                    SnowballMaker.leftHandInstance.TryCreateSnowball(32, out snowballThrowable);
                }
                if (EquipmentInteractor.instance.leftHandHeldEquipment is GrowingSnowballThrowable growingSnowballThrowable)
                {
                    if (size > 0)
                    {
                        growingSnowballThrowable.IncreaseSize(size);
                    }

                    PhotonEvent photonEvent = (PhotonEvent)growingSnowballThrowable
                        .GetType()
                        .GetField("snowballThrowEvent", BindingFlags.Instance | BindingFlags.NonPublic)
                        .GetValue(growingSnowballThrowable);

                    photonEvent.RaiseAll(new object[]
                    {
          position,
          velocity,
          ++ProjectileMods.Count
                    });
                }
                else
                {
                }
            }
        }

        private static void WaterBalloonLaunchJPX(Vector3 position, Vector3 velocity)
        {
            if (EquipmentInteractor.instance.rightHandHeldEquipment != null)
            {
                EquipmentInteractor.instance.rightHandHeldEquipment.gameObject.transform.position =
                    GTPlayer.Instance.RightHand.controllerTransform.position;
            }

            if (Time.time > WaterBalloonCD)
            {
                WaterBalloonCD = Time.time + 0.225f;

                if (!(EquipmentInteractor.instance.rightHandHeldEquipment is GrowingSnowballThrowable))
                {
                    SnowballThrowable balloon;
                    SnowballMaker.rightHandInstance.TryCreateSnowball(204, out balloon);
                }

                if (EquipmentInteractor.instance.rightHandHeldEquipment is GrowingSnowballThrowable growing)
                {
                    PhotonEvent throwEvent = (PhotonEvent)growing
                        .GetType()
                        .GetField("snowballThrowEvent", BindingFlags.Instance | BindingFlags.NonPublic)
                        .GetValue(growing);

                    throwEvent.RaiseAll(new object[]
                    {
                position,
                velocity,
                ++ProjectileMods.Count
                    });
                }
            }
        }

        private static void PresentLaunchJPX(Vector3 position, Vector3 velocity)
        {
            if (EquipmentInteractor.instance.rightHandHeldEquipment != null)
            {
                EquipmentInteractor.instance.rightHandHeldEquipment.gameObject.transform.position =
                    GTPlayer.Instance.RightHand.controllerTransform.position;
            }

            if (Time.time > PresentCD)
            {
                PresentCD = Time.time + 0.225f;

                if (!(EquipmentInteractor.instance.rightHandHeldEquipment is GrowingSnowballThrowable))
                {
                    SnowballThrowable balloon;
                    SnowballMaker.rightHandInstance.TryCreateSnowball(240, out balloon);
                }

                if (EquipmentInteractor.instance.rightHandHeldEquipment is GrowingSnowballThrowable growing)
                {
                    PhotonEvent throwEvent = (PhotonEvent)growing
                        .GetType()
                        .GetField("snowballThrowEvent", BindingFlags.Instance | BindingFlags.NonPublic)
                        .GetValue(growing);

                    throwEvent.RaiseAll(new object[]
                    {
                position,
                velocity,
                ++ProjectileMods.Count
                    });
                }
            }
        }

        private static void MentosLaunchJPX(Vector3 position, Vector3 velocity)
        {
            if (EquipmentInteractor.instance.rightHandHeldEquipment != null)
            {
                EquipmentInteractor.instance.rightHandHeldEquipment.gameObject.transform.position =
                    GTPlayer.Instance.RightHand.controllerTransform.position;
            }

            if (Time.time > MentosCD)
            {
                MentosCD = Time.time + 0.225f;

                if (!(EquipmentInteractor.instance.rightHandHeldEquipment is GrowingSnowballThrowable))
                {
                    SnowballThrowable balloon;
                    SnowballMaker.rightHandInstance.TryCreateSnowball(249, out balloon);
                }

                if (EquipmentInteractor.instance.rightHandHeldEquipment is GrowingSnowballThrowable growing)
                {
                    PhotonEvent throwEvent = (PhotonEvent)growing
                        .GetType()
                        .GetField("snowballThrowEvent", BindingFlags.Instance | BindingFlags.NonPublic)
                        .GetValue(growing);

                    throwEvent.RaiseAll(new object[]
                    {
                position,
                velocity,
                ++ProjectileMods.Count
                    });
                }
            }
        }

        private static void FishFoodJPX(Vector3 position, Vector3 velocity)
        {
            if (EquipmentInteractor.instance.rightHandHeldEquipment != null)
            {
                EquipmentInteractor.instance.rightHandHeldEquipment.gameObject.transform.position =
                    GTPlayer.Instance.RightHand.controllerTransform.position;
            }

            if (Time.time > FishFoodCD)
            {
                FishFoodCD = Time.time + 0.225f;

                if (!(EquipmentInteractor.instance.rightHandHeldEquipment is GrowingSnowballThrowable))
                {
                    SnowballThrowable balloon;
                    SnowballMaker.rightHandInstance.TryCreateSnowball(252, out balloon);
                }

                if (EquipmentInteractor.instance.rightHandHeldEquipment is GrowingSnowballThrowable growing)
                {
                    PhotonEvent throwEvent = (PhotonEvent)growing
                        .GetType()
                        .GetField("snowballThrowEvent", BindingFlags.Instance | BindingFlags.NonPublic)
                        .GetValue(growing);

                    throwEvent.RaiseAll(new object[]
                    {
                position,
                velocity,
                ++ProjectileMods.Count
                    });
                }
            }
        }

        private static void VotingRockJPX(Vector3 position, Vector3 velocity)
        {
            if (EquipmentInteractor.instance.rightHandHeldEquipment != null)
            {
                EquipmentInteractor.instance.rightHandHeldEquipment.gameObject.transform.position =
                    GTPlayer.Instance.RightHand.controllerTransform.position;
            }

            if (Time.time > VotingRockCD)
            {
                VotingRockCD = Time.time + 0.225f;

                if (!(EquipmentInteractor.instance.rightHandHeldEquipment is GrowingSnowballThrowable))
                {
                    SnowballThrowable balloon;
                    SnowballMaker.rightHandInstance.TryCreateSnowball(287, out balloon);
                }

                if (EquipmentInteractor.instance.rightHandHeldEquipment is GrowingSnowballThrowable growing)
                {
                    PhotonEvent throwEvent = (PhotonEvent)growing
                        .GetType()
                        .GetField("snowballThrowEvent", BindingFlags.Instance | BindingFlags.NonPublic)
                        .GetValue(growing);

                    throwEvent.RaiseAll(new object[]
                    {
                position,
                velocity,
                ++ProjectileMods.Count
                    });
                }
            }
        }

        private static void CandyJPX(Vector3 position, Vector3 velocity)
        {
            if (EquipmentInteractor.instance.rightHandHeldEquipment != null)
            {
                EquipmentInteractor.instance.rightHandHeldEquipment.gameObject.transform.position =
                    GTPlayer.Instance.RightHand.controllerTransform.position;
            }

            if (Time.time > CandyCD)
            {
                CandyCD = Time.time + 0.225f;

                if (!(EquipmentInteractor.instance.rightHandHeldEquipment is GrowingSnowballThrowable))
                {
                    SnowballThrowable balloon;
                    SnowballMaker.rightHandInstance.TryCreateSnowball(286, out balloon);
                }

                if (EquipmentInteractor.instance.rightHandHeldEquipment is GrowingSnowballThrowable growing)
                {
                    PhotonEvent throwEvent = (PhotonEvent)growing
                        .GetType()
                        .GetField("snowballThrowEvent", BindingFlags.Instance | BindingFlags.NonPublic)
                        .GetValue(growing);

                    throwEvent.RaiseAll(new object[]
                    {
                position,
                velocity,
                ++ProjectileMods.Count
                    });
                }
            }
        }

        private static void ApplesJPX(Vector3 position, Vector3 velocity)
        {
            if (EquipmentInteractor.instance.rightHandHeldEquipment != null)
            {
                EquipmentInteractor.instance.rightHandHeldEquipment.gameObject.transform.position =
                    GTPlayer.Instance.RightHand.controllerTransform.position;
            }

            if (Time.time > ApplesCD)
            {
                ApplesCD = Time.time + 0.225f;

                if (!(EquipmentInteractor.instance.rightHandHeldEquipment is GrowingSnowballThrowable))
                {
                    SnowballThrowable balloon;
                    SnowballMaker.rightHandInstance.TryCreateSnowball(288, out balloon);
                }

                if (EquipmentInteractor.instance.rightHandHeldEquipment is GrowingSnowballThrowable growing)
                {
                    PhotonEvent throwEvent = (PhotonEvent)growing
                        .GetType()
                        .GetField("snowballThrowEvent", BindingFlags.Instance | BindingFlags.NonPublic)
                        .GetValue(growing);

                    throwEvent.RaiseAll(new object[]
                    {
                position,
                velocity,
                ++ProjectileMods.Count
                    });
                }
            }
        }

        public static void ImpactSpamThing(Vector3 position, Color color)
        {
            if (Time.time > ProjectileMods.ImpactDelay)
            {
                object[] array = new object[]
                {
           position,
           color.r,
           color.g,
           color.b,
           1f,
           1
                };
                object[] array2 = new object[]
                {
           PhotonNetwork.ServerTimestamp,
           1,
           array
                };
                try
                {
                    PhotonNetwork.RaiseEvent(3, array2, new RaiseEventOptions
                    {
                        Receivers = (ReceiverGroup)1
                    }, SendOptions.SendUnreliable);
                }
                catch
                {
                }
                ProjectileMods.ImpactDelay = Time.time + 0.15f;
            }
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
