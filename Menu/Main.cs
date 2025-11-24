using BepInEx;
using GorillaLocomotion;
using HarmonyLib;
using Photon.Pun;
using StupidTemplate.Classes;
using StupidTemplate.Mods;
using StupidTemplate.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.XR;
using static StupidTemplate.Menu.Buttons;
using static StupidTemplate.Settings;
using Button = StupidTemplate.Classes.Button;

/*
 * Hello, current and future developers!
 * This is ii's Stupid Template, a base mod menu template for Gorilla Tag.
 * 
 * Comments are placed around the code showing you how certain classes work, such as the settings, buttons, and notifications.
 * 
 * If you need help with the template, you may join my Discord server: https://discord.gg/iidk
 * It's full of talented developers that can show you the way and how things work.
 * 
 * If you want to support my, check out my Patreon: https://patreon.com/iiDk
 * Any support is appreciated, and it helps me make more free content for you all!
 * 
 * Thank you, and enjoy the template!
 */

namespace StupidTemplate.Menu
{
    [HarmonyPatch(typeof(GTPlayer), "LateUpdate")]
    public class Main : MonoBehaviour
    {
        // Constant
        public static Font ComicSans = Font.CreateDynamicFontFromOSFont("Comic Sans MS", 1);
        public static void Prefix()
        {
            // Initialize Menu
                try
                {
                    bool toOpen = (!rightHanded && ControllerInputPoller.instance.leftControllerSecondaryButton) || (rightHanded && ControllerInputPoller.instance.rightControllerSecondaryButton);
                    bool keyboardOpen = UnityInput.Current.GetKey(keyboardButton);

                    if (menu == null)
                    {
                        if (toOpen || keyboardOpen)
                        {
                            CreateMenu();
                            RecenterMenu(rightHanded, keyboardOpen);
                            if (reference == null)
                                CreateReference(rightHanded);
                        }
                    }
                    else
                    {
                        if (toOpen || keyboardOpen)
                            RecenterMenu(rightHanded, keyboardOpen);
                        else
                        {
                            GameObject.Find("Shoulder Camera").transform.Find("CM vcam1").gameObject.SetActive(true);

                            Rigidbody comp = menu.AddComponent(typeof(Rigidbody)) as Rigidbody;
                            comp.linearVelocity = (rightHanded ? GTPlayer.Instance.LeftHand.velocityTracker : GTPlayer.Instance.RightHand.velocityTracker).GetAverageVelocity(true, 0);

                            Destroy(menu, 2f);
                            menu = null;

                            Destroy(reference);
                            reference = null;
                        }
                    }
                }
                catch (Exception exc)
                {
                    Debug.LogError(string.Format("{0} // Error initializing at {1}: {2}", PluginInfo.Name, exc.StackTrace, exc.Message));
                }

            // Constant
                try
                {
                    // Pre-Execution
                        if (fpsObject != null)
                            fpsObject.text = "FPS: " + Mathf.Ceil(1f / Time.unscaledDeltaTime).ToString();

                    // Execute Enabled Mods
                        foreach (ButtonInfo button in buttons
                            .SelectMany(list => list)
                            .Where(button => button.enabled && button.method != null))
                        {
                            try
                            {
                                button.method.Invoke();
                            }
                            catch (Exception exc)
                            {
                                Debug.LogError(string.Format("{0} // Error with mod {1} at {2}: {3}", PluginInfo.Name, button.buttonText, exc.StackTrace, exc.Message));
                            }
                        }
                } catch (Exception exc)
                {
                    Debug.LogError(string.Format("{0} // Error with executing mods at {1}: {2}", PluginInfo.Name, exc.StackTrace, exc.Message));
                }
        }

        // Functions
        public static void CreateMenu()
        {
            // Menu Holder
                menu = GameObject.CreatePrimitive(PrimitiveType.Cube);
                Destroy(menu.GetComponent<Rigidbody>());
                Destroy(menu.GetComponent<BoxCollider>());
                Destroy(menu.GetComponent<Renderer>());
                menu.transform.localScale = new Vector3(0.1f, 0.3f, 0.3825f);

            // Menu Background
                menuBackground = GameObject.CreatePrimitive(PrimitiveType.Cube);
                Destroy(menuBackground.GetComponent<Rigidbody>());
                Destroy(menuBackground.GetComponent<BoxCollider>());
                menuBackground.transform.parent = menu.transform;
                menuBackground.transform.rotation = Quaternion.identity;
                menuBackground.transform.localScale = menuSize;
                menuBackground.GetComponent<Renderer>().material.color = MenuColor;
            menuBackground.transform.position = new Vector3(0.05f, 0f, 0f);
            if (BorderOn)
            {
                GameObject primitive = GameObject.CreatePrimitive(PrimitiveType.Cube);
                UnityEngine.Object.Destroy(primitive.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(primitive.GetComponent<BoxCollider>());
                primitive.transform.parent = Main.menu.transform;
                primitive.transform.position = new Vector3(0.05f, 0.0f, 0.0f);
                primitive.transform.rotation = Quaternion.identity;
                primitive.transform.localScale = new Vector3(0.06f, 1.37f, menuSize.z + 0.06f);
                Color startColor = BorderColor;
                startColor.a = 0f;
                primitive.GetComponent<Renderer>().material.color = startColor;
            }

            // Canvas
            canvasObject = new GameObject();
                canvasObject.transform.parent = menu.transform;
                Canvas canvas = canvasObject.AddComponent<Canvas>();
                CanvasScaler canvasScaler = canvasObject.AddComponent<CanvasScaler>();
                canvasObject.AddComponent<GraphicRaycaster>();
                canvas.renderMode = RenderMode.WorldSpace;
                canvasScaler.dynamicPixelsPerUnit = 1000f;

            // Title and FPS
                Text text = new GameObject
                {
                    transform =
                    {
                        parent = canvasObject.transform
                    }
                }.AddComponent<Text>();
                text.font = ComicSans;
                text.text = MenuTitle + " [" + (pageNumber + 1).ToString() + "]";
                text.fontSize = 1;
                text.color = TitleColor;
                text.supportRichText = true;
                text.fontStyle = FontStyle.Bold;
                text.alignment = TextAnchor.MiddleCenter;
                text.resizeTextForBestFit = true;
                text.resizeTextMinSize = 0;
                RectTransform component = text.GetComponent<RectTransform>();
                component.localPosition = Vector3.zero;
                component.sizeDelta = new Vector2(0.28f, 0.05f);
                component.position = new Vector3(0.06f, 0f, 0.19f);
                component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));

                if (fpsCounter)
                {
                    fpsObject = new GameObject
                    {
                        transform =
                        {
                            parent = canvasObject.transform
                        }
                    }.AddComponent<Text>();
                    fpsObject.font = ComicSans;
                    fpsObject.text = "FPS: " + Mathf.Ceil(1f / Time.unscaledDeltaTime).ToString();
                fpsObject.color = TitleColor;
                    fpsObject.fontSize = 1;
                    fpsObject.supportRichText = true;
                    fpsObject.fontStyle = FontStyle.Normal;
                    fpsObject.alignment = TextAnchor.MiddleCenter;
                    fpsObject.horizontalOverflow = HorizontalWrapMode.Overflow;
                    fpsObject.resizeTextForBestFit = true;
                    fpsObject.resizeTextMinSize = 0;
                    RectTransform component2 = fpsObject.GetComponent<RectTransform>();
                    component2.localPosition = Vector3.zero;
                    component2.sizeDelta = new Vector2(0.25f, 0.01f);
                    component2.position = new Vector3(0.06f, 0f, 0.204f);
                    component2.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
                }

            // Buttons

            if (HomeButton)
            {
                GameObject primitive = GameObject.CreatePrimitive(PrimitiveType.Cube); // PrimitiveType 3 is a Cube
                if (!UnityInput.Current.GetKey(KeyCode.Q))
                {
                    primitive.layer = 2;
                }
                UnityEngine.Object.Destroy(primitive.GetComponent<Rigidbody>());
                primitive.GetComponent<BoxCollider>().isTrigger = true;

                primitive.transform.parent = Main.menu.transform;
                primitive.transform.rotation = Quaternion.identity;
                primitive.transform.localScale = new Vector3(0.09f, 0.65f, 0.08f);

                // button position


                primitive.transform.localPosition = new Vector3(0.56f, 0.01f, 0.78f);
                primitive.GetComponent<Renderer>().material.color = Color.black;

                primitive.AddComponent<Button>().relatedText = "Home";

                Text text2 = new GameObject
                {
                    transform = { parent = Main.canvasObject.transform }
                }.AddComponent<Text>();
                text2.text = "Home";
                text2.font = ComicSans;
                text2.fontSize = 1;
                text2.color = TextColorOff;
                text2.alignment = TextAnchor.MiddleCenter;
                text2.resizeTextForBestFit = true;
                text2.resizeTextMinSize = 0;
                text2.fontStyle = FontStyle.Bold;

                RectTransform rectTransform2 = text2.GetComponent<RectTransform>();
                rectTransform2.localPosition = Vector3.zero;
                rectTransform2.sizeDelta = new Vector2(0.2f, 0.02f);

                // text position


                rectTransform2.localPosition = new Vector3(0.064f, 0.0f, 0.31f);
                rectTransform2.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            }
            // Disconnect
            if (disconnectButton)
                    {
                        GameObject disconnectbutton = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        if (!UnityInput.Current.GetKey(keyboardButton))
                            disconnectbutton.layer = 2;
                        Destroy(disconnectbutton.GetComponent<Rigidbody>());
                        disconnectbutton.GetComponent<BoxCollider>().isTrigger = true;
                        disconnectbutton.transform.parent = menu.transform;
                        disconnectbutton.transform.rotation = Quaternion.identity;
                        disconnectbutton.transform.localScale = new Vector3(0.09f, 0.81f, 0.08f);
                        disconnectbutton.transform.localPosition = new Vector3(0.56f, 0.01f, 0.65f);
                        disconnectbutton.GetComponent<Renderer>().material.color = DisconnectColor;
                        disconnectbutton.AddComponent<Classes.Button>().relatedText = "Disconnect";

                        Text discontext = new GameObject
                        {
                            transform =
                            {
                                parent = canvasObject.transform
                            }
                        }.AddComponent<Text>();
                        discontext.text = "Disconnect";
                        discontext.font = ComicSans;
                        discontext.fontSize = 1;
                        discontext.color = TextColorOff;
                        discontext.alignment = TextAnchor.MiddleCenter;
                        discontext.resizeTextForBestFit = true;
                        discontext.resizeTextMinSize = 0;

                        RectTransform rectt = discontext.GetComponent<RectTransform>();
                        rectt.localPosition = Vector3.zero;
                        rectt.sizeDelta = new Vector2(0.2f, 0.02f);
                        rectt.localPosition = new Vector3(0.064f, 0.0f, 0.25f);
                        rectt.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
                    }

                // Page Buttons
                    GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    if (!UnityInput.Current.GetKey(keyboardButton))
                        gameObject.layer = 2;
                    Destroy(gameObject.GetComponent<Rigidbody>());
                    gameObject.GetComponent<BoxCollider>().isTrigger = true;
                    gameObject.transform.parent = menu.transform;
                    gameObject.transform.rotation = Quaternion.identity;
                    gameObject.transform.localScale = new Vector3(0.01f, 0.395f, 0.08f);
                    gameObject.transform.localPosition = new Vector3(0.56f, 0.251f, -0.455f);
                    gameObject.GetComponent<Renderer>().material.color = PrevButton;
                    gameObject.AddComponent<Classes.Button>().relatedText = "PreviousPage";

                    text = new GameObject
                    {
                        transform =
                        {
                            parent = canvasObject.transform
                        }
                    }.AddComponent<Text>();
                    text.font = ComicSans;
                    text.text = "<";
                    text.fontSize = 1;
                    text.color = TextColorOff;
                    text.alignment = TextAnchor.MiddleCenter;
                    text.resizeTextForBestFit = true;
                    text.resizeTextMinSize = 0;
                    component = text.GetComponent<RectTransform>();
                    component.localPosition = Vector3.zero;
                    component.sizeDelta = new Vector2(0.2f, 0.03f);
                    component.localPosition = new Vector3(0.064f, 0.075f, -0.1685f);
                    component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
 
            gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    if (!UnityInput.Current.GetKey(keyboardButton))
                    {
                        gameObject.layer = 2;
                    }
                    Destroy(gameObject.GetComponent<Rigidbody>());
                    gameObject.GetComponent<BoxCollider>().isTrigger = true;
                    gameObject.transform.parent = menu.transform;
                    gameObject.transform.rotation = Quaternion.identity;
                    gameObject.transform.localScale = new Vector3(0.01f, 0.395f, 0.08f);
                    gameObject.transform.localPosition = new Vector3(0.56f, -0.251f, -0.455f);
                    gameObject.GetComponent<Renderer>().material.color = NextButton;
                    gameObject.AddComponent<Classes.Button>().relatedText = "NextPage";


                    text = new GameObject
                    {
                        transform =
                        {
                            parent = canvasObject.transform
                        }
                    }.AddComponent<Text>();
                    text.font = ComicSans;
                    text.text = ">";
                    text.fontSize = 1;
                    text.color = TextColorOff;
                    text.alignment = TextAnchor.MiddleCenter;
                    text.resizeTextForBestFit = true;
                    text.resizeTextMinSize = 0;
                    component = text.GetComponent<RectTransform>();
                    component.localPosition = Vector3.zero;
                    component.sizeDelta = new Vector2(0.2f, 0.03f);
                    component.localPosition = new Vector3(0.064f, -0.075f, -0.1685f);
                    component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));

            // Mod Buttons
            ButtonInfo[] activeButtons = buttons[currentCategory].Skip(pageNumber * buttonsPerPage).Take(buttonsPerPage).ToArray();
                    for (int i = 0; i < activeButtons.Length; i++)
                        CreateButton(i * 0.1f, activeButtons[i]);
        }

        public static void CreateButton(float offset, ButtonInfo method)
        {
            GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            if (!UnityInput.Current.GetKey(keyboardButton))
                gameObject.layer = 2;
            
            Destroy(gameObject.GetComponent<Rigidbody>());
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            gameObject.transform.parent = menu.transform;
            gameObject.transform.rotation = Quaternion.identity;
            gameObject.transform.localScale = new Vector3(0.09f, 1.2f, 0.09f);
            gameObject.transform.localPosition = new Vector3(0.56f, 0f, 0.37f - offset);
            gameObject.AddComponent<Classes.Button>().relatedText = method.buttonText;


            Text text = new GameObject
            {
                transform =
                {
                    parent = canvasObject.transform
                }
            }.AddComponent<Text>();
            text.font = ComicSans;
            text.text = method.buttonText;

            if (method.overlapText != null)
                text.text = method.overlapText;
            
            text.supportRichText = true;
            text.fontSize = 1;
            if (method.enabled)
            {
                text.color = TextColorOn;
                gameObject.GetComponent<Renderer>().material.color = buttonColorsOn;
            }
            else
            {
                text.color = TextColorOff;
                gameObject.GetComponent<Renderer>().material.color = buttonColorsOff;
            }
            text.alignment = TextAnchor.MiddleCenter;
            text.fontStyle = FontStyle.Normal;
            text.resizeTextForBestFit = true;
            text.resizeTextMinSize = 0;
            RectTransform component = text.GetComponent<RectTransform>();
            component.localPosition = Vector3.zero;
            component.sizeDelta = new Vector2(0.2f, 0.03f);
            component.localPosition = new Vector3(0.064f, 0, 0.145f - offset / 2.6f);
            component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
        }

        public static void RecreateMenu()
        {
            if (menu != null)
            {
                Destroy(menu);
                menu = null;

                CreateMenu();
                RecenterMenu(rightHanded, UnityInput.Current.GetKey(keyboardButton));
            }
        }

        public static void RecenterMenu(bool isRightHanded, bool isKeyboardCondition)
        {
            if (!isKeyboardCondition)
            {
                if (!isRightHanded)
                {
                    menu.transform.position = GorillaTagger.Instance.leftHandTransform.position;
                    menu.transform.rotation = GorillaTagger.Instance.leftHandTransform.rotation;
                }
                else
                {
                    menu.transform.position = GorillaTagger.Instance.rightHandTransform.position;
                    Vector3 rotation = GorillaTagger.Instance.rightHandTransform.rotation.eulerAngles;
                    rotation += new Vector3(0f, 0f, 180f);
                    menu.transform.rotation = Quaternion.Euler(rotation);
                }
            }
            else
            {
                try
                {
                    TPC = GameObject.Find("Player Objects/Third Person Camera/Shoulder Camera").GetComponent<Camera>();
                }
                catch { }

                GameObject.Find("Shoulder Camera").transform.Find("CM vcam1").gameObject.SetActive(false);

                if (TPC != null)
                {
                    TPC.transform.position = new Vector3(-999f, -999f, -999f);
                    TPC.transform.rotation = Quaternion.identity;
                    GameObject bg = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    bg.transform.localScale = new Vector3(10f, 10f, 0.01f);
                    bg.transform.transform.position = TPC.transform.position + TPC.transform.forward;
                    bg.GetComponent<Renderer>().material.color = BackBack;
                    GameObject.Destroy(bg, Time.deltaTime);
                    menu.transform.parent = TPC.transform;
                    menu.transform.position = (TPC.transform.position + (Vector3.Scale(TPC.transform.forward, new Vector3(0.5f, 0.5f, 0.5f)))) + (Vector3.Scale(TPC.transform.up, new Vector3(-0.02f, -0.02f, -0.02f)));
                    Vector3 rot = TPC.transform.rotation.eulerAngles;
                    rot = new Vector3(rot.x - 90, rot.y + 90, rot.z);
                    menu.transform.rotation = Quaternion.Euler(rot);

                    if (reference != null)
                    {
                        if (Mouse.current.leftButton.isPressed)
                        {
                            Ray ray = TPC.ScreenPointToRay(Mouse.current.position.ReadValue());
                            RaycastHit hit;
                            bool worked = Physics.Raycast(ray, out hit, 100);
                            if (worked)
                            {
                                Classes.Button collide = hit.transform.gameObject.GetComponent<Classes.Button>();
                                if (collide != null)
                                {
                                    collide.OnTriggerEnter(buttonCollider);
                                }
                            }
                        }
                        else
                        {
                            reference.transform.position = new Vector3(999f, -999f, -999f);
                        }
                    }
                }
            }
        }

        public static void CreateReference(bool isRightHanded)
        {
            reference = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            reference.transform.parent = isRightHanded ? GorillaTagger.Instance.leftHandTransform : GorillaTagger.Instance.rightHandTransform;
            reference.GetComponent<Renderer>().material.color = Settings.MenuColor;
            reference.transform.localPosition = new Vector3(0f, -0.1f, 0f);
            reference.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            buttonCollider = reference.GetComponent<SphereCollider>();
        }

        public static void Toggle(string buttonText)
        {
            if (buttonText == "Disconnect")
            {
                PhotonNetwork.Disconnect();
            }

            if (buttonText == "Home")
            {
                SettingsMods.Home();
            }
            int lastPage = ((buttons[currentCategory].Length + buttonsPerPage - 1) / buttonsPerPage) - 1;
            if (buttonText == "PreviousPage")
            {
                pageNumber--;
                if (pageNumber < 0)
                    pageNumber = lastPage;
            } else
            {
                if (buttonText == "NextPage")
                {
                    pageNumber++;
                    if (pageNumber > lastPage)
                        pageNumber = 0;
                } else
                {
                    ButtonInfo target = GetIndex(buttonText);
                    if (target != null)
                    {
                        if (target.isTogglable)
                        {
                            target.enabled = !target.enabled;
                            if (target.enabled)
                            {
                                NotifiLib.SendNotification("<color=grey>[</color><color=green>ENABLE</color><color=grey>]</color> " + target.toolTip);
                                if (target.enableMethod != null)
                                    try { target.enableMethod.Invoke(); } catch { }
                            }
                            else
                            {
                                NotifiLib.SendNotification("<color=grey>[</color><color=red>DISABLE</color><color=grey>]</color> " + target.toolTip);
                                if (target.disableMethod != null)
                                    try { target.disableMethod.Invoke(); } catch { }
                            }
                        }
                        else
                        {
                            NotifiLib.SendNotification("<color=grey>[</color><color=green>ENABLE</color><color=grey>]</color> " + target.toolTip);
                            if (target.method != null)
                                try { target.method.Invoke(); } catch { }
                        }
                    }
                    else
                        Debug.LogError(buttonText + " does not exist");
                }
            }
            RecreateMenu();
        }

        private static readonly Dictionary<string, (int Category, int Index)> cacheGetIndex = new Dictionary<string, (int Category, int Index)>(); // Looping through 800 elements is not a light task :/
        public static ButtonInfo GetIndex(string buttonText)
        {
            if (buttonText == null)
                return null;

            if (cacheGetIndex.ContainsKey(buttonText))
            {
                var CacheData = cacheGetIndex[buttonText];
                try
                {
                    if (buttons[CacheData.Category][CacheData.Index].buttonText == buttonText)
                        return buttons[CacheData.Category][CacheData.Index];
                }
                catch { cacheGetIndex.Remove(buttonText); }
            }

            int categoryIndex = 0;
            foreach (ButtonInfo[] buttons in buttons)
            {
                int buttonIndex = 0;
                foreach (ButtonInfo button in buttons)
                {
                    if (button.buttonText == buttonText)
                    {
                        try
                        {
                            cacheGetIndex.Add(buttonText, (categoryIndex, buttonIndex));
                        }
                        catch
                        {
                            if (cacheGetIndex.ContainsKey(buttonText))
                                cacheGetIndex.Remove(buttonText);
                        }

                        return button;
                    }
                    buttonIndex++;
                }
                categoryIndex++;
            }

            return null;
        }

        public static Vector3 RandomVector3(float range = 1f) =>
            new Vector3(UnityEngine.Random.Range(-range, range),
                        UnityEngine.Random.Range(-range, range),
                        UnityEngine.Random.Range(-range, range));

        public static Quaternion RandomQuaternion(float range = 360f) =>
            Quaternion.Euler(UnityEngine.Random.Range(0f, range),
                        UnityEngine.Random.Range(0f, range),
                        UnityEngine.Random.Range(0f, range));

        public static Color RandomColor(byte range = 255, byte alpha = 255) =>
            new Color32((byte)UnityEngine.Random.Range(0, range),
                        (byte)UnityEngine.Random.Range(0, range),
                        (byte)UnityEngine.Random.Range(0, range),
                        alpha);

        public static (Vector3 position, Quaternion rotation, Vector3 up, Vector3 forward, Vector3 right) TrueLeftHand()
        {
            Quaternion rot = GorillaTagger.Instance.leftHandTransform.rotation * GTPlayer.Instance.LeftHand.handRotOffset;
            return (GorillaTagger.Instance.leftHandTransform.position + GorillaTagger.Instance.leftHandTransform.rotation * GTPlayer.Instance.LeftHand.handOffset, rot, rot * Vector3.up, rot * Vector3.forward, rot * Vector3.right);
        }

        public static (Vector3 position, Quaternion rotation, Vector3 up, Vector3 forward, Vector3 right) TrueRightHand()
        {
            Quaternion rot = GorillaTagger.Instance.rightHandTransform.rotation * GTPlayer.Instance.RightHand.handRotOffset;
            return (GorillaTagger.Instance.rightHandTransform.position + GorillaTagger.Instance.rightHandTransform.rotation * GTPlayer.Instance.RightHand.handOffset, rot, rot * Vector3.up, rot * Vector3.forward, rot * Vector3.right);
        }

        public static void WorldScale(GameObject obj, Vector3 targetWorldScale)
        {
            Vector3 parentScale = obj.transform.parent.lossyScale;
            obj.transform.localScale = new Vector3(
                targetWorldScale.x / parentScale.x,
                targetWorldScale.y / parentScale.y,
                targetWorldScale.z / parentScale.z
            );
        }

        public static void FixStickyColliders(GameObject platform)
        {
            Vector3[] localPositions = new Vector3[]
            {
                new Vector3(0, 1f, 0),
                new Vector3(0, -1f, 0),
                new Vector3(1f, 0, 0),
                new Vector3(-1f, 0, 0),
                new Vector3(0, 0, 1f),
                new Vector3(0, 0, -1f)
            };
            Quaternion[] localRotations = new Quaternion[]
            {
                Quaternion.Euler(90, 0, 0),
                Quaternion.Euler(-90, 0, 0),
                Quaternion.Euler(0, -90, 0),
                Quaternion.Euler(0, 90, 0),
                Quaternion.identity,
                Quaternion.Euler(0, 180, 0)
            };
            for (int i = 0; i < localPositions.Length; i++)
            {
                GameObject side = GameObject.CreatePrimitive(PrimitiveType.Cube);
                try
                {
                    if (platform.GetComponent<GorillaSurfaceOverride>() != null)
                    {
                        side.AddComponent<GorillaSurfaceOverride>().overrideIndex = platform.GetComponent<GorillaSurfaceOverride>().overrideIndex;
                    }
                }
                catch { }
                float size = 0.025f;
                side.transform.SetParent(platform.transform);
                side.transform.position = localPositions[i] * (size / 2);
                side.transform.rotation = localRotations[i];
                WorldScale(side, new Vector3(size, size, 0.01f));
                side.GetComponent<Renderer>().enabled = false;
            }
        }

        private static int? noInvisLayerMask;
        public static int NoInvisLayerMask()
        {
            noInvisLayerMask ??= ~(
                1 << LayerMask.NameToLayer("TransparentFX") |
                1 << LayerMask.NameToLayer("Ignore Raycast") |
                1 << LayerMask.NameToLayer("Zone") |
                1 << LayerMask.NameToLayer("Gorilla Trigger") |
                1 << LayerMask.NameToLayer("Gorilla Boundary") |
                1 << LayerMask.NameToLayer("GorillaCosmetics") |
                1 << LayerMask.NameToLayer("GorillaParticle"));

            return noInvisLayerMask ?? GTPlayer.Instance.locomotionEnabledLayers;
        }

       
        public static GameObject menu;
        public static GameObject menuBackground;
        public static GameObject reference;
        public static GameObject canvasObject;

        public static SphereCollider buttonCollider;
        public static Camera TPC;
        public static Text fpsObject;



        // Data
        public static int pageNumber = 0;
        public static int buttonsType = 0;
        public static int _currentCategory;
        public static int currentCategory
        {
            get => _currentCategory;
            set
            {
                _currentCategory = value;
                pageNumber = 0;
            }
        }
    }
}
