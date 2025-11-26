using StupidTemplate.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace StupidTemplate.Mods
{
    internal class AnimalMods
    {
        #region Animals
        public static void BugBabies()
        {
            GameObject.Find("Environment Objects/05Maze_PersistentObjects/BugBabies").SetActive(true);
        }

        public static void FixBugBabies()
        {
            GameObject.Find("Environment Objects/05Maze_PersistentObjects/BugBabies").SetActive(false);
        }

        public static void RequestBugOwnership()
        {
            GameObject.Find("Floating Bug Holdable").GetComponent<ThrowableBug>().ownerRig = GorillaTagger.Instance.offlineVRRig;
            GameObject.Find("Floating Bug Holdable").GetComponent<ThrowableBug>().allowWorldSharableInstance = true;
            GameObject.Find("Floating Bug Holdable").GetComponent<ThrowableBug>().WorldShareableRequestOwnership();
        }

        public static void RideBug()
        {
            if (ControllerInputPoller.instance.rightControllerIndexFloat == 1f)
            {
                GorillaLocomotion.GTPlayer.Instance.transform.position = GameObject.Find("Floating Bug Holdable").transform.position + new Vector3(0f, 0.3f, 0f);
                GorillaTagger.Instance.rigidbody.velocity = Vector3.zero;
            }
        }

        public static void RideBat()
        {
            if (ControllerInputPoller.instance.rightControllerIndexFloat == 1f)
            {
                GorillaLocomotion.GTPlayer.Instance.transform.position = GameObject.Find("Cave Bat Holdable").transform.position + new Vector3(0f, 0.3f, 0f);
                GorillaTagger.Instance.rigidbody.velocity = Vector3.zero;
            }
        }

        public static void RideBall()
        {
            if (ControllerInputPoller.instance.rightControllerIndexFloat == 1f)
            {
                GorillaLocomotion.GTPlayer.Instance.transform.position = GameObject.Find("Ball").transform.position + new Vector3(0f, 0.3f, 0f);
                GorillaTagger.Instance.rigidbody.velocity = Vector3.zero;
            }
        }

        public static void RideShark()
        {
            if (ControllerInputPoller.instance.rightControllerIndexFloat == 1f)
            {
                GorillaLocomotion.GTPlayer.Instance.transform.position = GameObject.Find("Swimming Shark prefab").transform.position + new Vector3(0f, 0.3f, 0f);
                GorillaTagger.Instance.rigidbody.velocity = Vector3.zero;
            }
        }

        public static void DestroyBug()
        {
            GameObject.Find("Floating Bug Holdable").transform.position = new Vector3(99999f, 99999f, 99999f);
        }

        public static void DestroyBat()
        {
            GameObject.Find("Cave Bat Holdable").transform.position = new Vector3(99999f, 99999f, 99999f);
        }

        public static void DestroyBeachBall()
        {
            GameObject.Find("Ball").transform.position = new Vector3(99999f, 99999f, 99999f);
        }

        public static void DestroyShark()
        {
            GameObject.Find("Swimming Shark prefab").transform.position = new Vector3(99999f, 99999f, 99999f);
        }

        public static void FastBug()
        {
            foreach (ThrowableBug bug in UnityEngine.Object.FindObjectsOfType<ThrowableBug>())
            {
                bug.bobingSpeed = 55f;
                bug.maxNaturalSpeed = 55f;
                bug.startingSpeed = 55f;
            }
        }

        public static void FixBug()
        {
            foreach (ThrowableBug bug in UnityEngine.Object.FindObjectsOfType<ThrowableBug>())
            {
                bug.bobingSpeed = 1.5f;
                bug.maxNaturalSpeed = 1.5f;
                bug.startingSpeed = 1.5f;
            }
        }

        public static void SlowBug()
        {
            foreach (ThrowableBug bug in UnityEngine.Object.FindObjectsOfType<ThrowableBug>())
            {
                bug.bobingSpeed = 0.5f;
                bug.maxNaturalSpeed = 0.5f;
                bug.startingSpeed = 0.5f;
            }
        }

        public static void FreezeBug()
        {
            foreach (ThrowableBug bug in UnityEngine.Object.FindObjectsOfType<ThrowableBug>())
            {
                bug.bobingSpeed = 0f;
                bug.maxNaturalSpeed = 0f;
                bug.startingSpeed = 0f;
            }
        }

        public static void FastBat()
        {
            foreach (ThrowableBug Bat in UnityEngine.Object.FindObjectsOfType<ThrowableBug>())
            {
                Bat.bobingSpeed = 55f;
                Bat.maxNaturalSpeed = 55f;
                Bat.startingSpeed = 55f;
            }
        }

        public static void FixBat()
        {
            foreach (ThrowableBug Bat in UnityEngine.Object.FindObjectsOfType<ThrowableBug>())
            {
                Bat.bobingSpeed = 1.5f;
                Bat.maxNaturalSpeed = 1.5f;
                Bat.startingSpeed = 1.5f;
            }
        }

        public static void SlowBat()
        {
            foreach (ThrowableBug Bat in UnityEngine.Object.FindObjectsOfType<ThrowableBug>())
            {
                Bat.bobingSpeed = 0.5f;
                Bat.maxNaturalSpeed = 0.5f;
                Bat.startingSpeed = 0.5f;
            }
        }

        public static void FreezeBat()
        {
            foreach (ThrowableBug Bat in UnityEngine.Object.FindObjectsOfType<ThrowableBug>())
            {
                Bat.bobingSpeed = 0f;
                Bat.maxNaturalSpeed = 0f;
                Bat.startingSpeed = 0f;
            }
        }

        public static void FreezeMosters()
        {
            foreach (MonkeyeAI monkeyeAI in UnityEngine.Object.FindObjectsOfType<MonkeyeAI>())
            {
                monkeyeAI.speed = 0f;
            }
        }

        public static void FastBall()
        {
            foreach (TransferrableBall ball in UnityEngine.Object.FindObjectsOfType<TransferrableBall>())
            {
                ball.maxHitSpeed = 550f;
            }
        }

        public static void SlowBall()
        {
            foreach (TransferrableBall ball in UnityEngine.Object.FindObjectsOfType<TransferrableBall>())
            {
                ball.maxHitSpeed = 3f;
            }
        }

        public static void FreezeBall()
        {
            foreach (TransferrableBall ball in UnityEngine.Object.FindObjectsOfType<TransferrableBall>())
            {
                ball.maxHitSpeed = 0f;
            }
        }

        public static void FixBall()
        {
            foreach (TransferrableBall ball in UnityEngine.Object.FindObjectsOfType<TransferrableBall>())
            {
                ball.maxHitSpeed = 5f;
            }
        }

        public static void DestroyBalloon()
        {
            foreach (BalloonHoldable balloonHoldable2 in Object.FindObjectsOfType<BalloonHoldable>())
            {
                balloonHoldable2.gameObject.transform.position = new Vector3(99999f, 99999f, 99999f);
            }
        }

        public static void PopAllBalloons()
        {
            foreach (BalloonHoldable balloonHoldable2 in Object.FindObjectsOfType<BalloonHoldable>())
            {
                Vector3 position = balloonHoldable2.gameObject.transform.position;
                Vector3 velocity = Vector3.zero;

                ProjectileMods.SnowballLaunchJPX(GorillaTagger.Instance.rightHandTransform.position + GorillaTagger.Instance.rightHandTransform.forward * 0.2f, Vector3.zero, 0);
            }
        }

        public static void GrabShark()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                GameObject.Find("Swimming Shark prefab").transform.position = GorillaTagger.Instance.rightHandTransform.position;
            }
        }

        public static void SharkTraces()
        {
            GameObject gameObject = GameObject.Find("Swimming Shark prefab");
            GameObject gameObject2 = GameObject.CreatePrimitive((PrimitiveType)2);
            UnityEngine.Object.Destroy(gameObject2.GetComponent<BoxCollider>());
            UnityEngine.Object.Destroy(gameObject2.GetComponent<Rigidbody>());
            UnityEngine.Object.Destroy(gameObject2.GetComponent<Collider>());
            UnityEngine.Object.Destroy(gameObject2.GetComponent<MeshCollider>());
            gameObject2.transform.rotation = Quaternion.identity;
            gameObject2.transform.localScale = new Vector3(0.020f, 0.020f, 0.020f);
            gameObject2.transform.position = gameObject.transform.position;
            UpdateScaleForBeacons(GorillaTagger.Instance.rightHandTransform.gameObject, gameObject.gameObject, gameObject2);
            Renderer component = gameObject2.GetComponent<Renderer>();
            component.material.color = Color.Lerp(new Color(0f, 1f, 0f, 0.5f), new Color(0f, 1f, 1f, 0.5f), Mathf.PingPong(Time.time, 1f));
            UnityEngine.Object.Destroy(gameObject2, Time.deltaTime);
        }

        public static void SharkSizeChanger()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                GameObject.Find("Swimming Shark prefab").transform.localScale = new Vector3(1f, 1f, 1f);
            }
            if (ControllerInputPoller.instance.rightGrab)
            {
                GameObject.Find("Swimming Shark prefab").transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
            }
            if (ControllerInputPoller.instance.leftGrab)
            {
                GameObject.Find("Swimming Shark prefab").transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
            }
        }

        public static void SpazShark()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                GameObject.Find("Swimming Shark prefab").transform.rotation = UnityEngine.Random.rotation;
            }
        }

        public static void OrbitShark()
        {
            float distance = 1.0f;
            OrbitAndHaloAngle += OrbitAndHaloSpeed * Time.deltaTime;
            float x = RigManager.GetOwnVRRig().transform.position.x + distance * Mathf.Cos(OrbitAndHaloAngle);
            float y = RigManager.GetOwnVRRig().transform.position.y + distance * Mathf.Sin(OrbitAndHaloAngle);
            float z = RigManager.GetOwnVRRig().transform.position.z + distance * Mathf.Sin(OrbitAndHaloAngle);
            GameObject.Find("Swimming Shark prefab").transform.position = new Vector3(x, y, z);
        }

        public static void HaloShark()
        {
            OrbitAndHaloAngle += OrbitAndHaloSpeed * Time.deltaTime;
            float x = RigManager.GetOwnVRRig().headConstraint.transform.position.x + 0.5f * Mathf.Cos(OrbitAndHaloAngle);
            float y = RigManager.GetOwnVRRig().headConstraint.transform.position.y + 0.5f;
            float z = RigManager.GetOwnVRRig().headConstraint.transform.position.z + 0.5f * Mathf.Sin(OrbitAndHaloAngle);
            GameObject.Find("Swimming Shark prefab").transform.position = new Vector3(x, y, z);
        }

        public static void SharkGun()
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
                    GameObject.Find("Swimming Shark prefab").transform.position = pointer.transform.position;
                }
            }
            if (pointer != null)
            {
                UnityEngine.Object.Destroy(pointer, Time.deltaTime);
            }
        }

        public static void GrabBall()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                GameObject.Find("Ball").transform.position = GorillaTagger.Instance.rightHandTransform.position;
            }
        }

        public static void SeizureBug()
        {
            GameObject bug = GameObject.Find("Floating Bug Holdable");
            ThrowableBug bugShit = GameObject.Find("Floating Bug Holdable").GetComponent<ThrowableBug>();

            if (bugShit.IsMyItem())
            {
                if (ControllerInputPoller.instance.rightGrab)
                {
                    float rotationSpeed = 500.0f;

                    bug.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
                    bug.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
                    bug.transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
                }
            }
        }

        public static void BatTraces()
        {
            GameObject gameObject = GameObject.Find("Cave Bat Holdable");
            GameObject gameObject2 = GameObject.CreatePrimitive((PrimitiveType)2);
            UnityEngine.Object.Destroy(gameObject2.GetComponent<BoxCollider>());
            UnityEngine.Object.Destroy(gameObject2.GetComponent<Rigidbody>());
            UnityEngine.Object.Destroy(gameObject2.GetComponent<Collider>());
            UnityEngine.Object.Destroy(gameObject2.GetComponent<MeshCollider>());
            gameObject2.transform.rotation = Quaternion.identity;
            gameObject2.transform.localScale = new Vector3(0.020f, 0.020f, 0.020f);
            gameObject2.transform.position = gameObject.transform.position;
            UpdateScaleForBeacons(GorillaTagger.Instance.rightHandTransform.gameObject, gameObject.gameObject, gameObject2);
            Renderer component = gameObject2.GetComponent<Renderer>();
            component.material.color = Color.Lerp(new Color(0f, 1f, 0f, 0.5f), new Color(0f, 1f, 1f, 0.5f), Mathf.PingPong(Time.time, 1f));
            UnityEngine.Object.Destroy(gameObject2, Time.deltaTime);
        }

        public static void GrabBallons()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                foreach (BalloonHoldable balloonHoldable2 in Object.FindObjectsOfType<BalloonHoldable>())
                {
                    balloonHoldable2.gameObject.transform.position = GorillaTagger.Instance.rightHandTransform.position;
                }
            }
        }

        public static void BalloonSizeChanger()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                foreach (BalloonHoldable balloonHoldable2 in Object.FindObjectsOfType<BalloonHoldable>())
                {
                    balloonHoldable2.transform.localScale = new Vector3(1f, 1f, 1f);
                }
            }
            if (ControllerInputPoller.instance.rightGrab)
            {
                foreach (BalloonHoldable balloonHoldable2 in Object.FindObjectsOfType<BalloonHoldable>())
                {
                    balloonHoldable2.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
                }
            }
            if (ControllerInputPoller.instance.leftGrab)
            {
                foreach (BalloonHoldable balloonHoldable2 in Object.FindObjectsOfType<BalloonHoldable>())
                {
                    balloonHoldable2.transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
                }
            }
        }

        public static void HaloBalloon()
        {
            OrbitAndHaloAngle += OrbitAndHaloSpeed * Time.deltaTime;
            float x = RigManager.GetOwnVRRig().headConstraint.transform.position.x + 0.5f * Mathf.Cos(OrbitAndHaloAngle);
            float y = RigManager.GetOwnVRRig().headConstraint.transform.position.y + 0.5f;
            float z = RigManager.GetOwnVRRig().headConstraint.transform.position.z + 0.5f * Mathf.Sin(OrbitAndHaloAngle);
            foreach (BalloonHoldable balloonHoldable2 in Object.FindObjectsOfType<BalloonHoldable>())
            {
                balloonHoldable2.transform.position = new Vector3(x, y, z);
            }
        }

        public static void OrbitBalloon()
        {
            float distance = 1.0f;
            OrbitAndHaloAngle += OrbitAndHaloSpeed * Time.deltaTime;
            float x = RigManager.GetOwnVRRig().transform.position.x + distance * Mathf.Cos(OrbitAndHaloAngle);
            float y = RigManager.GetOwnVRRig().transform.position.y + distance * Mathf.Sin(OrbitAndHaloAngle);
            float z = RigManager.GetOwnVRRig().transform.position.z + distance * Mathf.Sin(OrbitAndHaloAngle);
            foreach (BalloonHoldable balloonHoldable2 in Object.FindObjectsOfType<BalloonHoldable>())
            {
                balloonHoldable2.transform.position = new Vector3(x, y, z);
            }
        }

        public static void BallonTraces()
        {
            foreach (BalloonHoldable balloonHoldable2 in Object.FindObjectsOfType<BalloonHoldable>())
            {
                GameObject gameObject2 = GameObject.CreatePrimitive((PrimitiveType)2);
                UnityEngine.Object.Destroy(gameObject2.GetComponent<BoxCollider>());
                UnityEngine.Object.Destroy(gameObject2.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(gameObject2.GetComponent<Collider>());
                UnityEngine.Object.Destroy(gameObject2.GetComponent<MeshCollider>());
                gameObject2.transform.rotation = Quaternion.identity;
                gameObject2.transform.localScale = new Vector3(0.020f, 0.020f, 0.020f);
                gameObject2.transform.position = balloonHoldable2.transform.position;
                UpdateScaleForBeacons(GorillaTagger.Instance.rightHandTransform.gameObject, balloonHoldable2.gameObject, gameObject2);
                Renderer component = gameObject2.GetComponent<Renderer>();
                component.material.color = Color.Lerp(new Color(0f, 1f, 0f, 0.5f), new Color(0f, 1f, 1f, 0.5f), Mathf.PingPong(Time.time, 1f));
                UnityEngine.Object.Destroy(gameObject2, Time.deltaTime);
            }
        }

        public static void BugTraces()
        {
            GameObject gameObject = GameObject.Find("Floating Bug Holdable");
            GameObject gameObject2 = GameObject.CreatePrimitive((PrimitiveType)2);
            UnityEngine.Object.Destroy(gameObject2.GetComponent<BoxCollider>());
            UnityEngine.Object.Destroy(gameObject2.GetComponent<Rigidbody>());
            UnityEngine.Object.Destroy(gameObject2.GetComponent<Collider>());
            UnityEngine.Object.Destroy(gameObject2.GetComponent<MeshCollider>());
            gameObject2.transform.rotation = Quaternion.identity;
            gameObject2.transform.localScale = new Vector3(0.020f, 0.020f, 0.020f);
            gameObject2.transform.position = gameObject.transform.position;
            UpdateScaleForBeacons(GorillaTagger.Instance.rightHandTransform.gameObject, gameObject.gameObject, gameObject2);
            Renderer component = gameObject2.GetComponent<Renderer>();
            component.material.color = Color.Lerp(new Color(0f, 1f, 0f, 0.5f), new Color(0f, 1f, 1f, 0.5f), Mathf.PingPong(Time.time, 1f));
            UnityEngine.Object.Destroy(gameObject2, Time.deltaTime);
        }

        public static void GrabBugR()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                GameObject.Find("Floating Bug Holdable").transform.position = GorillaTagger.Instance.rightHandTransform.position;
            }
        }

        public static void MakeBugLookAtYou()
        {
            GameObject.Find("Floating Bug Holdable").transform.LookAt(GorillaLocomotion.GTPlayer.Instance.bodyCollider.transform.position);
        }

        public static void BugSizeChanger()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                GameObject.Find("Floating Bug Holdable").transform.localScale = new Vector3(1f, 1f, 1f);
            }
            if (ControllerInputPoller.instance.rightGrab)
            {
                GameObject.Find("Floating Bug Holdable").transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
            }
            if (ControllerInputPoller.instance.leftGrab)
            {
                GameObject.Find("Floating Bug Holdable").transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
            }
        }

        public static void OrbitBug()
        {
            float distance = 1.0f;
            OrbitAndHaloAngle += OrbitAndHaloSpeed * Time.deltaTime;
            float x = RigManager.GetOwnVRRig().transform.position.x + distance * Mathf.Cos(OrbitAndHaloAngle);
            float y = RigManager.GetOwnVRRig().transform.position.y + distance * Mathf.Sin(OrbitAndHaloAngle);
            float z = RigManager.GetOwnVRRig().transform.position.z + distance * Mathf.Sin(OrbitAndHaloAngle);
            GameObject.Find("Floating Bug Holdable").transform.position = new Vector3(x, y, z);
        }

        public static void BugGun()
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
                    GameObject.Find("Floating Bug Holdable").transform.position = pointer.transform.position;
                }
            }
            if (pointer != null)
            {
                UnityEngine.Object.Destroy(pointer, Time.deltaTime);
            }
        }

        public static void BalloonGun()
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
                    foreach (BalloonHoldable balloonHoldable2 in Object.FindObjectsOfType<BalloonHoldable>())
                    {
                        balloonHoldable2.transform.position = hitInfo.point;
                    }
                }
            }
            if (pointer != null)
            {
                UnityEngine.Object.Destroy(pointer, Time.deltaTime);
            }
        }

        public static void BugLauncher()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {

                Vector3 POS = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position;
                Vector3 velocity = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up
                                   * Time.deltaTime * 1000;

                ThrowableBug template = Object.FindObjectOfType<ThrowableBug>();
                if (template == null) return;

                ThrowableBug clone = Object.Instantiate(template);

                clone.transform.position = POS;
                clone.transform.rotation = template.transform.rotation;

                clone.enabled = false;

                Rigidbody rb = clone.GetComponent<Rigidbody>();
                if (rb == null)
                    rb = clone.gameObject.AddComponent<Rigidbody>();

                rb.useGravity = true;
                rb.isKinematic = false;

                rb.velocity = velocity;

                rb.angularVelocity = Random.insideUnitSphere * 5f;

                Object.Destroy(clone.gameObject, 3f);
            }
        }

        public static void BugRain()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Vector3 POS = GorillaTagger.Instance.offlineVRRig.transform.position
                              + new Vector3(Random.Range(-5f, 5f), 5f, Random.Range(-5f, 5f));

                Vector3 velocity = GorillaLocomotion.GTPlayer.Instance.InstantaneousVelocity;

                ThrowableBug template = Object.FindObjectOfType<ThrowableBug>();
                if (template == null) return;

                ThrowableBug clone = Object.Instantiate(template);

                clone.transform.position = POS;
                clone.transform.rotation = template.transform.rotation;

                clone.enabled = false;

                Rigidbody rb = clone.GetComponent<Rigidbody>();
                if (rb == null)
                    rb = clone.gameObject.AddComponent<Rigidbody>();

                rb.useGravity = true;
                rb.isKinematic = false;

                rb.velocity = velocity + (Vector3.down * 3f);
                rb.angularVelocity = Random.insideUnitSphere * 3f;

                Object.Destroy(clone.gameObject, 3f);
            }
        }

        public static void BugSpam()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Vector3 POS = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position;

                ThrowableBug template = Object.FindObjectOfType<ThrowableBug>();
                if (template == null) return;

                ThrowableBug clone = Object.Instantiate(template);

                clone.transform.position = POS;
                clone.transform.rotation = template.transform.rotation;

                clone.enabled = false;

                Rigidbody rb = clone.GetComponent<Rigidbody>();
                if (rb == null)
                    rb = clone.gameObject.AddComponent<Rigidbody>();

                rb.useGravity = true;
                rb.isKinematic = false;
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;

                Object.Destroy(clone.gameObject, 2.5f);
            }
        }

        public static void SnipeBat()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position = GameObject.Find("Cave Bat Holdable").transform.position;
            }
        }

        public static void SeizureBalloon()
        {
            foreach (BalloonHoldable balloonHoldable2 in Object.FindObjectsOfType<BalloonHoldable>())
            {
                if (ControllerInputPoller.instance.rightGrab)
                {
                    float rotationSpeed = 500.0f;

                    balloonHoldable2.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
                    balloonHoldable2.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
                    balloonHoldable2.transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
                }
            }
        }

        public static void SeizureBat()
        {
            GameObject bug = GameObject.Find("Cave Bat Holdable");
            ThrowableBug bugShit = GameObject.Find("Cave Bat Holdable").GetComponent<ThrowableBug>();

            if (bugShit.IsMyItem())
            {
                if (ControllerInputPoller.instance.rightGrab)
                {
                    float rotationSpeed = 500.0f;

                    bug.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
                    bug.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
                    bug.transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
                }
            }
        }

        public static void BatGun()
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
                    GameObject.Find("Cave Bat Holdable").transform.position = pointer.transform.position;
                }
            }
            if (pointer != null)
            {
                UnityEngine.Object.Destroy(pointer, Time.deltaTime);
            }
        }

        public static void MakeBatLookAtYou()
        {
            GameObject.Find("Cave Bat Holdable").transform.LookAt(GorillaLocomotion.GTPlayer.Instance.bodyCollider.transform.position);
        }

        public static void GrabBat()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                GameObject.Find("Cave Bat Holdable").transform.position = GorillaTagger.Instance.rightHandTransform.position;
            }
        }

        public static void BallSizeChanger()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                GameObject.Find("Ball").transform.localScale = new Vector3(1f, 1f, 1f);
            }
            if (ControllerInputPoller.instance.rightGrab)
            {
                GameObject.Find("Ball").transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
            }
            if (ControllerInputPoller.instance.leftGrab)
            {
                GameObject.Find("Ball").transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
            }
        }

        public static void OrbitBat()
        {
            float distance = 1.0f;
            OrbitAndHaloAngle += OrbitAndHaloSpeed * Time.deltaTime;
            float x = RigManager.GetOwnVRRig().transform.position.x + distance * Mathf.Cos(OrbitAndHaloAngle);
            float y = RigManager.GetOwnVRRig().transform.position.y + distance * Mathf.Sin(OrbitAndHaloAngle);
            float z = RigManager.GetOwnVRRig().transform.position.z + distance * Mathf.Sin(OrbitAndHaloAngle);
            GameObject.Find("Cave Bat Holdable").transform.position = new Vector3(x, y, z);
        }

        public static void HaloBat()
        {
            OrbitAndHaloAngle += OrbitAndHaloSpeed * Time.deltaTime;
            float x = RigManager.GetOwnVRRig().headConstraint.transform.position.x + 0.5f * Mathf.Cos(OrbitAndHaloAngle);
            float y = RigManager.GetOwnVRRig().headConstraint.transform.position.y + 0.5f;
            float z = RigManager.GetOwnVRRig().headConstraint.transform.position.z + 0.5f * Mathf.Sin(OrbitAndHaloAngle);
            GameObject.Find("Cave Bat Holdable").transform.position = new Vector3(x, y, z);
        }

        public static void HaloBug()
        {
            OrbitAndHaloAngle += OrbitAndHaloSpeed * Time.deltaTime;
            float x = RigManager.GetOwnVRRig().headConstraint.transform.position.x + 0.5f * Mathf.Cos(OrbitAndHaloAngle);
            float y = RigManager.GetOwnVRRig().headConstraint.transform.position.y + 0.5f;
            float z = RigManager.GetOwnVRRig().headConstraint.transform.position.z + 0.5f * Mathf.Sin(OrbitAndHaloAngle);
            GameObject.Find("Floating Bug Holdable").transform.position = new Vector3(x, y, z);
        }

        public static void SnipeBug()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position = GameObject.Find("Floating Bug Holdable").transform.position;
            }
        }

        public static void SpazBall()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                GameObject.Find("Ball").transform.rotation = UnityEngine.Random.rotation;
            }
        }

        public static void BatSizeChanger()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                GameObject.Find("Cave Bat Holdable").transform.localScale = new Vector3(1f, 1f, 1f);
            }
            if (ControllerInputPoller.instance.rightGrab)
            {
                GameObject.Find("Cave Bat Holdable").transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
            }
            if (ControllerInputPoller.instance.leftGrab)
            {
                GameObject.Find("Cave Bat Holdable").transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
            }
        }

        public static void RequestBatOwnership()
        {
            GameObject.Find("Cave Bat Holdable").GetComponent<ThrowableBug>().ownerRig = GorillaTagger.Instance.offlineVRRig;
            GameObject.Find("Cave Bat Holdable").GetComponent<ThrowableBug>().allowWorldSharableInstance = true;
            GameObject.Find("Cave Bat Holdable").GetComponent<ThrowableBug>().WorldShareableRequestOwnership();
        }
        #endregion
        #region VARS
        private static float OrbitAndHaloAngle;

        public static float OrbitAndHaloSpeed = 5f;

        public static GameObject pointer;

        public static int change17 = 1;

        public static int change8 = 1;

        public static LineRenderer Line;

        private static void UpdateScaleForBeacons(GameObject startObj, GameObject endObj, GameObject beaconObj)
        {
            float num = Vector3.Distance(startObj.transform.position, endObj.transform.position);
            beaconObj.transform.localScale = new Vector3(beaconObj.transform.localScale.x, num / 2f, beaconObj.transform.localScale.z);
            Vector3 position = (startObj.transform.position + endObj.transform.position) / 2f;
            beaconObj.transform.position = position;
            Vector3 up = endObj.transform.position - startObj.transform.position;
            beaconObj.transform.up = up;
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
