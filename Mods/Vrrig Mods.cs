using GorillaNetworking;
using Photon.Pun;
using StupidTemplate.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using Technie.PhysicsCreator.QHull;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace StupidTemplate.Mods
{
    internal class VrrigMods
    {
        #region Vrrig
        public static void AutoClicker()
        {
            AutoClickState = !AutoClickState;
            if (ControllerInputPoller.instance.rightControllerSecondaryButton)
            {
                ControllerInputPoller.instance.leftControllerIndexFloat = AutoClickState ? 1f : 0f;

                VRRig.LocalRig.leftHand.calcT = AutoClickState ? 1f : 0f;
                VRRig.LocalRig.leftHand.MapMyFinger(1f);
            }
        }

        public static void FixHead()
        {
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.x = 0f;
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.y = 0f;
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.z = 0f;
        }

        public static void SmallHead()
        {
            GorillaTagger.Instance.offlineVRRig.headMesh.transform.localScale = Vector3.one * 0.4f;
        }

        public static void BigHead()
        {
            GorillaTagger.Instance.offlineVRRig.headMesh.transform.localScale = Vector3.one * 3f;
        }

        public static void FixSizeHead()
        {
            GorillaTagger.Instance.offlineVRRig.headMesh.transform.localScale = Vector3.one;
        }

        public static void HeadSpinX()
        {
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.x += 15f;
        }

        public static void HeadSpinY()
        {
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.y += 15f;
        }

        public static void SpazHead()
        {
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.y += 15f;
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.x += 15f;
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.z += 15f;
        }

        public static void FixSpazHead()
        {
            GorillaTagger.Instance.offlineVRRig.head.trackingPositionOffset = VrrigMods.HeadFix;
        }

        public static void BigMonkes()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (!vrrig.isOfflineVRRig)
                {
                    vrrig.transform.localScale = new Vector3(2f, 2f, 2f);
                }
            }
        }

        public static void TallMonkes()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (!vrrig.isOfflineVRRig)
                {
                    vrrig.transform.localScale = new Vector3(1.5f, 2.5f, 1.5f);
                }
            }
        }

        public static void RemoveSelfFromLeaderboard()
        {
            PhotonNetwork.LocalPlayer.NickName = string.Empty;
        }

        public static void FlatMonkes()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (!vrrig.isOfflineVRRig)
                {
                    vrrig.transform.localScale = new Vector3(0.01f, 1f, 1f);
                }
            }
        }

        public static void SmallMonkes()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (!vrrig.isOfflineVRRig)
                {
                    vrrig.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                }
            }
        }

        public static void DisableBigMonkes()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (!vrrig.isOfflineVRRig)
                {
                    vrrig.transform.localScale = new Vector3(1, 1, 1);
                }
            }
        }

        public static void DisableTallMonkes()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (!vrrig.isOfflineVRRig)
                {
                    vrrig.transform.localScale = new Vector3(1, 1, 1);
                }
            }
        }

        public static void DisableFlatMonkes()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (!vrrig.isOfflineVRRig)
                {
                    vrrig.transform.localScale = new Vector3(1, 1, 1);
                }
            }
        }

        public static void DisableSmallMonkes()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (!vrrig.isOfflineVRRig)
                {
                    vrrig.transform.localScale = new Vector3(1, 1, 1);
                }
            }
        }

        public static void HeadSpinZ()
        {
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.z += 15f;
        }

        public static void FixHeadY()
        {
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.y = 0f;
        }

        public static void FixHeadX()
        {
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.x = 0f;
        }

        public static void FixHeadZ()
        {
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.z = 0f;
        }

        public static void VibrateRightController()
        {
            GorillaTagger.Instance.StartVibration(forLeftController: false, GorillaTagger.Instance.tapHapticStrength / 2f, GorillaTagger.Instance.tapHapticDuration / 2f);
        }

        public static void VibrateLeftController()
        {
            GorillaTagger.Instance.StartVibration(forLeftController: true, GorillaTagger.Instance.tapHapticStrength / 2f, GorillaTagger.Instance.tapHapticDuration / 2f);
        }

        public static void VibrateBothController()
        {
            GorillaTagger.Instance.StartVibration(forLeftController: true, GorillaTagger.Instance.tapHapticStrength / 2f, GorillaTagger.Instance.tapHapticDuration / 2f);

            GorillaTagger.Instance.StartVibration(forLeftController: false, GorillaTagger.Instance.tapHapticStrength / 2f, GorillaTagger.Instance.tapHapticDuration / 2f);
        }

        public static void BecomePBBV()
        {
            ChangeName("PBBV");
            SetPlayerColor(new Color32(230, 127, 102, 255));
        }

        public static void HideNameOnLeaderBoard()
        {
            VrrigMods.ChangeName("________");
            VrrigMods.SetPlayerColor(new Color32(0, 53, 2, byte.MaxValue));
        }

        public static void BecomeDAISY09()
        {
            ChangeName("DAISY09");
            SetPlayerColor(new Color32(255, 81, 231, 255));
        }

        public static void SetNameToSpiderOnTop()
        {
            ChangeName("SpiderOnTop");
        }

        public static void SetNameToPBBV()
        {
            ChangeName("PBBV");
        }

        public static void SetNameToNothing()
        {
            ChangeName("");
        }

        public static void HauntedNameCycle()
        {
            string[] spookyNames =
            {
                "GHOST", "RUN", "IMBEHINDU", "TURNAROUND", "HELP", "DONTMOVE",
                "SPIDR", "PBBV?", "ERROR", "STATIC", "IMREAL", "NOESCAPE"
            };

            int index = Mathf.FloorToInt(Time.time) % spookyNames.Length;
            string name = spookyNames[index];
            PhotonNetwork.NickName = name;
            GorillaComputer.instance.savedName = name;
            PlayerPrefs.SetString("playerName", name);
            PlayerPrefs.Save();
        }

        public static void Disguise()
        {
            Color color;
            color = UnityEngine.Random.ColorHSV();
            NameList.Add("GAY");
            NameList.Add("SPIDR");
            NameList.Add("ON");
            NameList.Add("CKC");
            NameList.Add("DISGUISEDMAN");
            NameList.Add("SKIPPIY");
            NameList.Add("TOILET");
            NameList.Add("BAGUETTE");
            NameList.Add("WASSSAP");
            NameList.Add("HMMM");
            NameList.Add("ME");
            NameList.Add("GTAG");
            NameList.Add("BOB");
            NameList.Add("MONKE");
            GorillaTagger.Instance.offlineVRRig.enabled = false;
            GorillaTagger.Instance.offlineVRRig.transform.position = new Vector3(-66.7989f, 12.5422f, -82.6815f);
            if (GorillaComputer.instance.friendJoinCollider.playerIDsCurrentlyTouching.Contains(PhotonNetwork.LocalPlayer.UserId))
            {
                string randomname = NameList[UnityEngine.Random.Range(0, 13)];
                PhotonNetwork.NickName = randomname;
                GorillaComputer.instance.savedName = randomname;
                PlayerPrefs.SetString("playerName", randomname);
                PlayerPrefs.Save();
                GorillaTagger.Instance.UpdateColor(color.r, color.g, color.b);
                Debug.Log("local");
                GorillaTagger.Instance.myVRRig.SendRPC("RPC_InitializeNoobMaterial", RpcTarget.All, new object[]
                {
            color.r,
            color.g,
            color.b,
            false
                });
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }

        public static void Strobe()
        {
            if (SelectedRGBColor == 0)
            {
                color = Color.red;
            }
            if (SelectedRGBColor == 1)
            {
                color = Color.green;
            }
            if (SelectedRGBColor == 2)
            {
                color = Color.blue;
            }
            if (SelectedRGBColor == 3)
            {
                color = Color.cyan;
            }
            if (SelectedRGBColor == 4)
            {
                color = Color.white;
            }
            Codes.StartDelay(delegate
            {
                SelectedRGBColor++;
                SetPlayerColor(color);
                if (SelectedRGBColor > 4)
                {
                    SelectedRGBColor = 0;
                }
            }, .09f);
            FlushRpcs();
        }

        public static void RGBMonke()
        {
            if (SelectedRGBColor == 0)
            {
                color = Color.red;
            }
            if (SelectedRGBColor == 1)
            {
                color = Color.green;
            }
            if (SelectedRGBColor == 2)
            {
                color = Color.blue;
            }
            if (SelectedRGBColor == 3)
            {
                color = Color.cyan;
            }
            if (SelectedRGBColor == 4)
            {
                color = Color.white;
            }
            Codes.StartDelay(delegate
            {
                SelectedRGBColor++;
                SetPlayerColor(color);
                if (SelectedRGBColor > 4)
                {
                    SelectedRGBColor = 0;
                }
            }, .19f);
            FlushRpcs();
        }

        public static void FreezeRigLimbs()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;

                GorillaTagger.Instance.offlineVRRig.transform.position = GorillaTagger.Instance.bodyCollider.transform.position + new Vector3(0f, 0.15f, 0f);
                GorillaTagger.Instance.myVRRig.transform.position = GorillaTagger.Instance.bodyCollider.transform.position + new Vector3(0f, 0.15f, 0f);

                GorillaTagger.Instance.offlineVRRig.transform.rotation = GorillaTagger.Instance.bodyCollider.transform.rotation;
                GorillaTagger.Instance.myVRRig.transform.rotation = GorillaTagger.Instance.bodyCollider.transform.rotation;

                GameObject l = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                UnityEngine.Object.Destroy(l.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(l.GetComponent<SphereCollider>());

                l.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                l.transform.position = GorillaTagger.Instance.leftHandTransform.position;

                GameObject r = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                UnityEngine.Object.Destroy(r.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(r.GetComponent<SphereCollider>());

                r.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                r.transform.position = GorillaTagger.Instance.rightHandTransform.position;

                l.GetComponent<Renderer>().material.color = Settings.MenuColor;
                r.GetComponent<Renderer>().material.color = Settings.MenuColor;

                UnityEngine.Object.Destroy(l, Time.deltaTime);
                UnityEngine.Object.Destroy(r, Time.deltaTime);
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }

        public static void FixBeeArms()
        {
            GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.transform.position += new Vector3(0, 0, 0);
            GorillaLocomotion.GTPlayer.Instance.LeftHand.controllerTransform.transform.position += new Vector3(0, 0, 0);
        }

        public static void BeeArms()
        {
            GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.transform.position += new Vector3(0, 10, 0);
            GorillaLocomotion.GTPlayer.Instance.LeftHand.controllerTransform.transform.position += new Vector3(0, 10, 0);
        }

        public static void SizeChanger()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                SizeScale = 1f;
            }
            if (ControllerInputPoller.instance.rightGrab)
            {
                SizeScale += 0.05f;
            }
            if (ControllerInputPoller.instance.leftGrab)
            {
                SizeScale -= 0.05f;
            }
            if (SizeScale <= 0)
            {
                SizeScale = 0.05f;
            }
            VRRig.LocalRig.transform.localScale = Vector3.one * SizeScale;
            VRRig.LocalRig.NativeScale = SizeScale;
        }

        public static void HandsInHead()
        {
            GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position = GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position;
            GorillaLocomotion.GTPlayer.Instance.LeftHand.controllerTransform.position = GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position;
        }

        public static void HeadUpsidedown()
        {
            RigManager.GetOwnVRRig().head.trackingRotationOffset.x = 180f;
        }

        public static void LookAtClosest()
        {
            if (ControllerInputPoller.instance.rightControllerIndexFloat > 0f)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                GameObject gameObject = GameObject.CreatePrimitive(0);
                Object.Destroy(gameObject.GetComponent<Rigidbody>());
                Object.Destroy(gameObject.GetComponent<SphereCollider>());
                gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                gameObject.transform.position = GorillaTagger.Instance.rightHandTransform.position;
                gameObject.GetComponent<Renderer>().material.color = Settings.MenuColor;
                GameObject gameObject2 = GameObject.CreatePrimitive(0);
                Object.Destroy(gameObject2.GetComponent<Rigidbody>());
                Object.Destroy(gameObject2.GetComponent<SphereCollider>());
                gameObject2.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                gameObject2.transform.position = GorillaTagger.Instance.leftHandTransform.position;
                gameObject2.GetComponent<Renderer>().material.color = Settings.MenuColor;
                Object.Destroy(gameObject, Time.deltaTime);
                Object.Destroy(gameObject2, Time.deltaTime);
                VRRig vrrig = GorillaGameManager.instance.FindPlayerVRRig(Codes.GetClosestPlayer());
                GorillaTagger.Instance.offlineVRRig.headConstraint.LookAt(vrrig.transform.position);
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }

        public static void SpazArms()
        {
            GorillaTagger.Instance.leftHandTransform.position = new Vector3(Random.Range(0f, 999999f), Random.Range(0f, 999999f), Random.Range(0f, 999999f));
            GorillaTagger.Instance.rightHandTransform.position = new Vector3(Random.Range(0f, 999999f), Random.Range(0f, 999999f), Random.Range(0f, 999999f));
        }

        public static void DisableMouthMovement()
        {
            VRRig.LocalRig.shouldSendSpeakingLoudness = false;
            StupidTemplate.Patches.MicPatch.enabled = true;
        }

        public static void EnableMouthMovement()
        {
            VRRig.LocalRig.shouldSendSpeakingLoudness = true;
            StupidTemplate.Patches.MicPatch.enabled = false;
        }

        public static void BrokenNeck()
        {
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.z = 90f;
        }

        public static void HandSpinner()
        {
            VRMap rightHand = GorillaTagger.Instance.offlineVRRig.rightHand;
            VRMap leftHand = GorillaTagger.Instance.offlineVRRig.leftHand;
            rightHand.trackingRotationOffset.y = rightHand.trackingRotationOffset.y + 10f;
            leftHand.trackingRotationOffset.y = leftHand.trackingRotationOffset.y + 10f;
        }

        public static void FixHandSpinner()
        {
            GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.rotation *= Quaternion.Euler(GorillaTagger.Instance.offlineVRRig.leftHand.trackingRotationOffset);
            GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.rotation *= Quaternion.Euler(GorillaTagger.Instance.offlineVRRig.rightHand.trackingRotationOffset);
        }

        public static void GrabHead()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                if (!IsHeadGrabbed)
                {
                    OriginalHeadPosition = GorillaTagger.Instance.offlineVRRig.headMesh.transform.position;
                    IsHeadGrabbed = true;
                }
                GorillaTagger.Instance.offlineVRRig.headMesh.transform.position = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position;
            }
            else if (IsHeadGrabbed)
            {
                GorillaTagger.Instance.offlineVRRig.headMesh.transform.position = OriginalHeadPosition;
                IsHeadGrabbed = false;
            }
        }

        public static void CopyIdentityGun()
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

                    VRRig possibly = hitInfo.collider.GetComponentInParent<VRRig>();
                    if (possibly && possibly != GorillaTagger.Instance.offlineVRRig)
                    {
                        ChangeName(RigManager.GetPlayerFromVRRig(possibly).NickName);
                        SetPlayerColor(possibly.playerColor);
                        StealIdentityDelay = Time.time + 0.5f;
                    }
                }
            }
            if (pointer != null)
            {
                UnityEngine.Object.Destroy(pointer, Time.deltaTime);
            }
        }

        public static void RightArmGun()
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
                    GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position = hitInfo.point;
                }
            }
            if (pointer != null)
            {
                UnityEngine.Object.Destroy(pointer, Time.deltaTime);
            }
        }

        public static void LeftArmGun()
        {
            if (ControllerInputPoller.instance.leftGrab)
            {
                Physics.Raycast(GorillaLocomotion.GTPlayer.Instance.LeftHand.controllerTransform.position, -GorillaLocomotion.GTPlayer.Instance.LeftHand.controllerTransform.up, out var hitInfo);
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
                    Line.SetPosition(0, GorillaLocomotion.GTPlayer.Instance.LeftHand.controllerTransform.position);
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
                if (ControllerInputPoller.instance.leftControllerIndexFloat == 1f)
                {
                    GorillaLocomotion.GTPlayer.Instance.LeftHand.controllerTransform.position = hitInfo.point;
                }
            }
            if (pointer != null)
            {
                UnityEngine.Object.Destroy(pointer, Time.deltaTime);
            }
        }

        public static void FlipHands()
        {
            Vector3 lh = GorillaTagger.Instance.leftHandTransform.position;
            Vector3 rh = GorillaTagger.Instance.rightHandTransform.position;
            Quaternion lhr = GorillaTagger.Instance.leftHandTransform.rotation;
            Quaternion rhr = GorillaTagger.Instance.rightHandTransform.rotation;

            GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.transform.position = lh;
            GorillaLocomotion.GTPlayer.Instance.LeftHand.controllerTransform.transform.position = rh;

            GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.transform.rotation = lhr;
            GorillaLocomotion.GTPlayer.Instance.LeftHand.controllerTransform.transform.rotation = rhr;
        }

        public static void NoFingerMovement()
        {
            ControllerInputPoller.instance.leftControllerGripFloat = 0f;
            ControllerInputPoller.instance.rightControllerGripFloat = 0f;
            ControllerInputPoller.instance.leftControllerIndexFloat = 0f;
            ControllerInputPoller.instance.rightControllerIndexFloat = 0f;
            ControllerInputPoller.instance.leftControllerPrimaryButton = false;
            ControllerInputPoller.instance.leftControllerSecondaryButton = false;
            ControllerInputPoller.instance.rightControllerPrimaryButton = false;
            ControllerInputPoller.instance.rightControllerSecondaryButton = false;
        }

        public static void FixHeadUpsidedown()
        {
            RigManager.GetOwnVRRig().head.trackingRotationOffset.x = 0f;
        }

        public static void SpazSelf()
        {
            foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerList)
            {
                GorillaTagger.Instance.offlineVRRig.head.rigTarget.eulerAngles = new Vector3((float)UnityEngine.Random.Range(0, 360), (float)UnityEngine.Random.Range(0, 360), (float)UnityEngine.Random.Range(0, 360));
                GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.eulerAngles = new Vector3((float)UnityEngine.Random.Range(0, 360), (float)UnityEngine.Random.Range(0, 360), (float)UnityEngine.Random.Range(0, 360));
                GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.eulerAngles = new Vector3((float)UnityEngine.Random.Range(0, 360), (float)UnityEngine.Random.Range(0, 360), (float)UnityEngine.Random.Range(0, 360));
                GorillaTagger.Instance.offlineVRRig.head.rigTarget.eulerAngles = new Vector3((float)UnityEngine.Random.Range(0, 360), (float)UnityEngine.Random.Range(0, 180), (float)UnityEngine.Random.Range(0, 180));
                GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.eulerAngles = new Vector3((float)UnityEngine.Random.Range(0, 360), (float)UnityEngine.Random.Range(0, 180), (float)UnityEngine.Random.Range(0, 180));
                GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.eulerAngles = new Vector3((float)UnityEngine.Random.Range(0, 360), (float)UnityEngine.Random.Range(0, 180), (float)UnityEngine.Random.Range(0, 180));
            }
        }

        public static void HeadBackwards()
        {
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.y = 180f;
        }

        public static void FixHeadbackwards()
        {
            RigManager.GetOwnVRRig().head.trackingRotationOffset.y = 0f;
        }

        public static void FixBrokenNeck()
        {
            RigManager.GetOwnVRRig().head.trackingRotationOffset.z = 0f;
        }

        public static void GhostMonke()
        {
            if (ControllerInputPoller.instance.rightControllerIndexFloat > 0f)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                GameObject gameObject = GameObject.CreatePrimitive(0);
                Object.Destroy(gameObject.GetComponent<Rigidbody>());
                Object.Destroy(gameObject.GetComponent<SphereCollider>());
                gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                gameObject.transform.position = GorillaTagger.Instance.rightHandTransform.position;
                gameObject.GetComponent<Renderer>().material.color = Settings.MenuColor;
                GameObject gameObject2 = GameObject.CreatePrimitive(0);
                Object.Destroy(gameObject2.GetComponent<Rigidbody>());
                Object.Destroy(gameObject2.GetComponent<SphereCollider>());
                gameObject2.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                gameObject2.transform.position = GorillaTagger.Instance.leftHandTransform.position;
                gameObject2.GetComponent<Renderer>().material.color = Settings.MenuColor;
                Object.Destroy(gameObject, Time.deltaTime);
                Object.Destroy(gameObject2, Time.deltaTime);
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }

        public static void InvisMonke()
        {
            if (ControllerInputPoller.instance.rightControllerIndexFloat > 0f)
            {
                GorillaTagger.Instance.offlineVRRig.headBodyOffset = new Vector3(999f, 999f, 999f);
                GameObject gameObject = GameObject.CreatePrimitive(0);
                Object.Destroy(gameObject.GetComponent<Rigidbody>());
                Object.Destroy(gameObject.GetComponent<SphereCollider>());
                gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                gameObject.transform.position = GorillaTagger.Instance.rightHandTransform.position;
                gameObject.GetComponent<Renderer>().material.color = Settings.MenuColor;
                GameObject gameObject2 = GameObject.CreatePrimitive(0);
                Object.Destroy(gameObject2.GetComponent<Rigidbody>());
                Object.Destroy(gameObject2.GetComponent<SphereCollider>());
                gameObject2.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                gameObject2.transform.position = GorillaTagger.Instance.leftHandTransform.position;
                gameObject2.GetComponent<Renderer>().material.color = Settings.MenuColor;
                Object.Destroy(gameObject, Time.deltaTime);
                Object.Destroy(gameObject2, Time.deltaTime);
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.headBodyOffset = Vector3.zero;
            }
        }

        public static void ToggleGhostMonkey()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton && Time.time > Codes.GhostCooldown + 1f)
            {
                Codes.GhostCooldown = Time.time;
                Codes.InGhostState = !Codes.InGhostState;
            }
            if (Codes.InGhostState)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                GameObject gameObject = GameObject.CreatePrimitive(0);
                Object.Destroy(gameObject.GetComponent<Rigidbody>());
                Object.Destroy(gameObject.GetComponent<SphereCollider>());
                gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                gameObject.transform.position = GorillaTagger.Instance.rightHandTransform.position;
                gameObject.GetComponent<Renderer>().material.color = Settings.MenuColor;
                GameObject gameObject2 = GameObject.CreatePrimitive(0);
                Object.Destroy(gameObject2.GetComponent<Rigidbody>());
                Object.Destroy(gameObject2.GetComponent<SphereCollider>());
                gameObject2.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                gameObject2.transform.position = GorillaTagger.Instance.leftHandTransform.position;
                gameObject2.GetComponent<Renderer>().material.color = Settings.MenuColor;
                Object.Destroy(gameObject, Time.deltaTime);
                Object.Destroy(gameObject2, Time.deltaTime);
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }

        public static void InvisibleOnTouch1()
        {
            if (GorillaParent.instance == null || GorillaTagger.Instance == null) return;

            Vector3 myHead = GorillaTagger.Instance.offlineVRRig.headMesh.transform.position;
            bool close = false;
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (vrrig == null || vrrig.isMyPlayer || vrrig.isOfflineVRRig) continue;

                float distR = Vector3.Distance(vrrig.rightHandTransform.position, myHead);
                float distL = Vector3.Distance(vrrig.leftHandTransform.position, myHead);

                if (distR < 0.6f || distL < 0.6f)
                {
                    close = true;
                    break;
                }
            }
            GorillaTagger.Instance.offlineVRRig.headBodyOffset =
            close ? new Vector3(0f, -999f, 0f) : Vector3.zero;
        }

        public static void InvisibleOnTouch()
        {
            if (GorillaParent.instance == null || GorillaTagger.Instance == null)
                return;

            Vector3 myHead = GorillaTagger.Instance.offlineVRRig.headMesh.transform.position;
            bool close = false;

            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (vrrig == null || vrrig.isMyPlayer || vrrig.isOfflineVRRig)
                    continue;

                float distR = Vector3.Distance(vrrig.rightHandTransform.position, myHead);
                float distL = Vector3.Distance(vrrig.leftHandTransform.position, myHead);

                if (distR < 0.6f || distL < 0.6f)
                {
                    close = true;
                    break;
                }
            }

            if (close)
            {
                GorillaTagger.Instance.offlineVRRig.headBodyOffset = new Vector3(999f, 999f, 999f);
                GameObject gameObject = GameObject.CreatePrimitive(0);
                Object.Destroy(gameObject.GetComponent<Rigidbody>());
                Object.Destroy(gameObject.GetComponent<SphereCollider>());
                gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                gameObject.transform.position = GorillaTagger.Instance.rightHandTransform.position;
                gameObject.GetComponent<Renderer>().material.color = Settings.MenuColor;
                GameObject gameObject2 = GameObject.CreatePrimitive(0);
                Object.Destroy(gameObject2.GetComponent<Rigidbody>());
                Object.Destroy(gameObject2.GetComponent<SphereCollider>());
                gameObject2.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                gameObject2.transform.position = GorillaTagger.Instance.leftHandTransform.position;
                gameObject2.GetComponent<Renderer>().material.color = Settings.MenuColor;
                Object.Destroy(gameObject, Time.deltaTime);
                Object.Destroy(gameObject2, Time.deltaTime);
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.headBodyOffset = Vector3.zero;
            }
        }

        public static void GhostMonkeOnTouch()
        {
            if (GorillaParent.instance == null || GorillaTagger.Instance == null)
                return;

            Vector3 myHead = GorillaTagger.Instance.offlineVRRig.headMesh.transform.position;
            bool close = false;

            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (vrrig == null || vrrig.isMyPlayer || vrrig.isOfflineVRRig)
                    continue;

                float distR = Vector3.Distance(vrrig.rightHandTransform.position, myHead);
                float distL = Vector3.Distance(vrrig.leftHandTransform.position, myHead);

                if (distR < 0.6f || distL < 0.6f)
                {
                    close = true;
                    break;
                }
            }

            if (close)
            {

                GorillaTagger.Instance.offlineVRRig.enabled = false;

                GameObject orbR = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                UnityEngine.Object.Destroy(orbR.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(orbR.GetComponent<SphereCollider>());
                orbR.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                orbR.transform.position = GorillaTagger.Instance.rightHandTransform.position;
                orbR.GetComponent<Renderer>().material.color = Settings.MenuColor;

                GameObject orbL = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                UnityEngine.Object.Destroy(orbL.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(orbL.GetComponent<SphereCollider>());
                orbL.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                orbL.transform.position = GorillaTagger.Instance.leftHandTransform.position;
                orbL.GetComponent<Renderer>().material.color = Settings.MenuColor;

                UnityEngine.Object.Destroy(orbR, Time.deltaTime);
                UnityEngine.Object.Destroy(orbL, Time.deltaTime);
            }
            else
            {

                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }

        public static void LaggyRig()
        {
            if (Time.time > LagRigCooldown)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
                IsLagRigModeActive = true;
                LagRigCooldown = Time.time + 0.5f;
            }
            else
            {
                if (IsLagRigModeActive)
                {
                    IsLagRigModeActive = false;
                }
                else
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = false;
                }
            }
        }

        public static void ToggleInvisibleMonkey()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton && Time.time > Codes.GhostCooldown + 1f)
            {
                Codes.GhostCooldown = Time.time;
                Codes.InGhostState = !Codes.InGhostState;
            }
            if (Codes.InGhostState)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                GorillaTagger.Instance.offlineVRRig.transform.position = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
                GameObject gameObject = GameObject.CreatePrimitive(0);
                Object.Destroy(gameObject.GetComponent<Rigidbody>());
                Object.Destroy(gameObject.GetComponent<SphereCollider>());
                gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                gameObject.transform.position = GorillaTagger.Instance.rightHandTransform.position;
                gameObject.GetComponent<Renderer>().material.color = Settings.MenuColor;
                GameObject gameObject2 = GameObject.CreatePrimitive(0);
                Object.Destroy(gameObject2.GetComponent<Rigidbody>());
                Object.Destroy(gameObject2.GetComponent<SphereCollider>());
                gameObject2.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                gameObject2.transform.position = GorillaTagger.Instance.leftHandTransform.position;
                gameObject2.GetComponent<Renderer>().material.color = Settings.MenuColor;
                Object.Destroy(gameObject, Time.deltaTime);
                UnityEngine.Object.Destroy(gameObject2, Time.deltaTime);
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }
        #endregion
        #region VARS
        public static bool IsLagRigModeActive = false;

        public static float LagRigCooldown = 0f;

        private static bool AutoClickState;

        public static Vector3 OriginalHeadPosition;

        public static int SelectedRGBColor;

        public static Color color;

        public static List<string> NameList = new List<string>();

        public static bool IsHeadGrabbed = false;

        private static Vector3 HeadFix = Vector3.zero;

        public static float SizeScale = 1f;

        public static GameObject pointer;

        public static int change17 = 1;

        public static LineRenderer Line;

        public static float StealIdentityDelay = 0f;

        public static int change8 = 1;

        public static void SetPlayerColor(Color color)
        {
            PlayerPrefs.SetFloat("redValue", color.r);
            PlayerPrefs.SetFloat("greenValue", color.g);
            PlayerPrefs.SetFloat("blueValue", color.b);
            GorillaTagger.Instance.UpdateColor(color.r, color.g, color.b);
            GorillaTagger.Instance.myVRRig.SendRPC("RPC_InitializeNoobMaterial", RpcTarget.All, new object[]
            {
                color.r,
                color.g,
                color.b
            });
        }

        public static void ChangeName(string PlayerName)
        {
            GorillaComputer.instance.currentName = PlayerName;

            GorillaComputer.instance.SetLocalNameTagText(GorillaComputer.instance.currentName);
            GorillaComputer.instance.savedName = GorillaComputer.instance.currentName;
            PlayerPrefs.SetString("playerName", GorillaComputer.instance.currentName);
            PlayerPrefs.Save();

            PhotonNetwork.LocalPlayer.NickName = PlayerName;
        }

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
