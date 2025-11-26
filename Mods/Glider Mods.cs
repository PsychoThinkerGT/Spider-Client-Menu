using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Object = UnityEngine.Object;

namespace StupidTemplate.Mods
{
    internal class GliderMods
    {
        #region Gliders
        public static void GrabGliders()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                foreach (GliderHoldable glider in UnityEngine.Object.FindObjectsOfType<GliderHoldable>())
                {
                    glider.gameObject.transform.position = GorillaTagger.Instance.rightHandTransform.position;
                }
            }
        }

        public static void GliderTornado()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                IsGliderTornadoEnabled = true;

                GliderHoldable[] gliders = Object.FindObjectsOfType<GliderHoldable>();
                int index = 0;

                foreach (GliderHoldable glider in gliders)
                {
                    if (glider.GetView.Owner == PhotonNetwork.LocalPlayer)
                    {
                        float radius = 2f;
                        float speed = 3f;
                        float heightSpeed = 1.2f;
                        float spiralHeight = 1.5f;

                        Vector3 center = GorillaTagger.Instance.headCollider.transform.position;

                        float angle = (Time.time * speed) + (index * 1.5f);

                        float x = Mathf.Cos(angle) * radius;
                        float z = Mathf.Sin(angle) * radius;

                        float y = Mathf.Sin(Time.time * heightSpeed + index) * spiralHeight;

                        glider.transform.position = center + new Vector3(x, y, z);
                        glider.transform.LookAt(center + Vector3.up * 1.2f);

                        index++;
                    }
                }
            }
            else
            {
                if (IsGliderTornadoEnabled)
                {
                    IsGliderTornadoEnabled = false;
                    RespawnGliders();
                }
            }
        }

        public static void GliderOrbitClosest()
        {
            if (ControllerInputPoller.instance.rightGrab &&
                GorillaParent.instance != null &&
                GorillaTagger.Instance != null &&
                GorillaTagger.Instance.offlineVRRig != null)
            {
                VRRig myRig = GorillaTagger.Instance.offlineVRRig;
                VRRig closest = null;
                float best = float.MaxValue;

                foreach (VRRig rig in GorillaParent.instance.vrrigs)
                {
                    if (rig != null && !rig.isOfflineVRRig && !rig.isMyPlayer)
                    {
                        float d = Vector3.SqrMagnitude(rig.transform.position - myRig.transform.position);
                        if (d < best)
                        {
                            best = d;
                            closest = rig;
                        }
                    }
                }

                if (closest != null)
                {
                    Vector3 center = closest.headMesh.transform.position;
                    GliderHoldable[] gliders = Object.FindObjectsOfType<GliderHoldable>();
                    int count = gliders.Length;

                    if (count > 0)
                    {
                        GliderRingAngleBase += 3f * Time.deltaTime;
                        float angleStep = Mathf.PI * 2f / count;
                        float distance = 1.7f;
                        float height = 0.6f;
                        int index = 0;

                        foreach (GliderHoldable glider in gliders)
                        {
                            if (glider != null && glider.GetView.Owner == PhotonNetwork.LocalPlayer)
                            {
                                float angle = GliderRingAngleBase + angleStep * index;
                                float x = center.x + distance * Mathf.Cos(angle);
                                float y = center.y + height;
                                float z = center.z + distance * Mathf.Sin(angle);

                                glider.transform.position = new Vector3(x, y, z);
                                glider.transform.LookAt(center);

                                index++;
                            }
                            else if (glider != null)
                            {
                                glider.OnHover(null, null);
                            }
                        }
                    }
                }
            }
        }


        public static void GliderSizePulse()
        {
            foreach (GliderHoldable glider in UnityEngine.Object.FindObjectsOfType<GliderHoldable>())
            {
                if (glider.GetView.Owner == PhotonNetwork.LocalPlayer)
                {
                    float pulse = Mathf.PingPong(Time.time * 2f, 0.5f) + 1f;
                    glider.transform.localScale = new Vector3(pulse, pulse, pulse);
                }
            }
        }

        public static void RGBGliders()
        {
            foreach (GliderHoldable glider in UnityEngine.Object.FindObjectsOfType<GliderHoldable>())
            {
                if (glider.GetView.Owner != PhotonNetwork.LocalPlayer)
                    continue;
                float t = Mathf.PingPong(Time.time * 0.6f, 1f);
                Color rgb = Color.HSVToRGB(t, 1f, 1f);
                var leafField = typeof(GliderHoldable).GetField("leafMesh",
                    System.Reflection.BindingFlags.NonPublic |
                    System.Reflection.BindingFlags.Instance);
                MeshRenderer leafRenderer = (MeshRenderer)leafField.GetValue(glider);

                if (leafRenderer != null && leafRenderer.material != null)
                {
                    leafRenderer.material.color = rgb;
                }

                MeshRenderer handleRenderer = glider.GetComponentInChildren<MeshRenderer>();
                if (handleRenderer != null)
                {
                    handleRenderer.material.color = rgb;
                }
            }
        }

        public static void RespawnGliders()
        {
            foreach (GliderHoldable glider in UnityEngine.Object.FindObjectsOfType<GliderHoldable>())
            {
                if (glider.GetView.Owner == PhotonNetwork.LocalPlayer)
                {
                    glider.Respawn();
                }
                else
                {
                    glider.OnHover(null, null);
                }
            }
        }

        public static void GliderGun()
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
                    foreach (GliderHoldable glider in UnityEngine.Object.FindObjectsOfType<GliderHoldable>())
                    {
                        if (glider.GetView.Owner == PhotonNetwork.LocalPlayer)
                        {
                            glider.gameObject.transform.position = pointer.transform.position + new Vector3(0f, 1f, 0f);
                        }
                        else
                        {
                            glider.OnHover(null, null);
                        }
                    }
                }
            }
            if (pointer != null)
            {
                UnityEngine.Object.Destroy(pointer, Time.deltaTime);
            }
        }

        public static void SpazGliders()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                foreach (GliderHoldable glider in UnityEngine.Object.FindObjectsOfType<GliderHoldable>())
                {
                    if (glider.GetView.Owner == PhotonNetwork.LocalPlayer)
                    {
                        glider.gameObject.transform.rotation = Quaternion.Euler(new Vector3(UnityEngine.Random.Range(0, 360), UnityEngine.Random.Range(0, 360), UnityEngine.Random.Range(0, 360)));
                    }
                    else
                    {
                        glider.OnHover(null, null);
                    }
                }
            }
        }
        #endregion
        #region VARS
        public static int ChangerModeIndex = 0;

        public static float GliderRingAngleBase = 0f;

        private static bool IsGliderTornadoEnabled = false;

        public static GameObject pointer;

        public static int change17 = 1;

        public static LineRenderer Line;

        public static int change8 = 1;
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
