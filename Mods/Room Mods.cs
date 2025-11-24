using GorillaNetworking;
using Photon.Pun;
using Photon.Realtime;
using StupidTemplate.Notifications;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace StupidTemplate.Mods
{
    internal class RoomMods
    {
        #region ROOM
        public static void ConnectEU()
        {
            PhotonNetwork.ConnectToRegion("eu");
        }

        public static void ConnectAU()
        {
            PhotonNetwork.ConnectToRegion("au");
        }

        public static void ConnectAsia()
        {
            PhotonNetwork.ConnectToRegion("asia");
        }

        public static void ConnectToBestRegion()
        {
            PhotonNetwork.ConnectToBestCloudServer();
        }

        public static void LeaveOnEmptyLobby()
        {
            if (!PhotonNetwork.InRoom)
            {
                int count = PhotonNetwork.CurrentRoom.PlayerCount;
                if (count <= 1)
                {
                    PhotonNetwork.LeaveRoom();
                }
            }
        }

        public static void CreateHugeRoom()
        {
            if (!PhotonNetwork.IsConnectedAndReady)
            {
                RoomOptions opts = new RoomOptions { MaxPlayers = 20, IsVisible = true, IsOpen = true };
                PhotonNetwork.CreateRoom("Huge_" + UnityEngine.Random.Range(1000, 9999), opts);
            }
        }

        public static void RejoinRoom()//WIP
        {

        }

        public static void NotifyLobbyRegion()
        {
            string region = PhotonNetwork.CloudRegion;
            NotifiLib.SendNotification("<color=yellow>[INFO]</color> Region: " + region);
        }

        public static void DisableNetworkTriggers()
        {
            GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab").SetActive(false);
        }

        public static void EnableNetworkTriggers()
        {
            GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab").SetActive(true);
        }

        public static void CreatePriv()
        {
            PhotonNetworkController.Instance.AttemptToJoinSpecificRoom(string.Format("{0}", UnityEngine.Random.Range(10000, 99999)), 0);
        }

        public static void Disconnect()
        {
            PhotonNetwork.Disconnect();
        }

        public static void LobbyHop()
        {
            if (!PhotonNetwork.InRoom && IsON)
            {
                JoinRandomRoom();
            }

            if (ControllerInputPoller.instance.rightControllerSecondaryButton)
            {
                if (PhotonNetwork.InRoom)
                {
                    PhotonNetwork.Disconnect();
                }
                IsON = !IsON;
            }
        }

        private static void JoinRandomRoom()
        {
            if (!PhotonNetwork.InRoom)
            {
                JoinRandomNoDis();
            }
        }

        public static void QuitApp()
        {
            UnityEngine.Application.Quit();
        }

        public static void CreatePublic()
        {
            CreateRoom(RandomRoomName(), true);
        }

        public static void JoinRandomNoDis()
        {
            GorillaNetworkJoinTrigger component = GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab/JoinPublicRoom - Forest, Tree Exit").GetComponent<GorillaNetworkJoinTrigger>();
            PhotonNetworkController.Instance.AttemptToJoinPublicRoom(component, 0);
        }

        public static void JoinRandomWithDis()
        {
            PhotonNetwork.Disconnect();
            GorillaNetworkJoinTrigger component = GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab/JoinPublicRoom - Forest, Tree Exit").GetComponent<GorillaNetworkJoinTrigger>();
            PhotonNetworkController.Instance.AttemptToJoinPublicRoom(component, 0);
        }

        public static void LeftTriggerDisconnect()
        {
            if (ControllerInputPoller.instance.leftControllerIndexFloat == 1f)
            {
                PhotonNetwork.Disconnect();
            }
        }

        public static void RandomGhostCode()
        {
            string[] roomNames =
            {
                "666",
                "DAISY09",
                "PBBV",
                "SREN17",
                "SREN18",
                "AI",
                "GHOST",
                "J3VU",
                "RUN",
                "BOT",
                "TIPTOE",
                "SPIDER",
                "STATUE",
                "BANSHEE",
                "RABBIT",
                "ERROR",
                "ISEEYOUBAN"
            };
            int num = new System.Random().Next(roomNames.Length);
            PhotonNetworkController.Instance.AttemptToJoinSpecificRoom(roomNames[num], JoinType.Solo);
        }

        public static void JoinCode(string code)
        {
            PhotonNetworkController.Instance.AttemptToJoinSpecificRoom(code, JoinType.Solo);
        }

        public static void ConnectUSA()
        {
            PhotonNetwork.ConnectToRegion("usw");
        }

        public static void ConnectUSW()
        {
            PhotonNetwork.ConnectToRegion("eu");
        }

        public static void ConnectCAE()
        {
            PhotonNetwork.ConnectToRegion("cae");
        }

        public static void ConnectIU()
        {
            PhotonNetwork.ConnectToRegion("iu");
        }
        #endregion
        #region
        private static bool IsON = false;

        public static void CreateRoom(string roomName, bool isPublic)
        {
            PhotonNetworkController.Instance.currentJoinTrigger = GorillaComputer.instance.GetJoinTriggerForZone("forest");
            string platformTag = (string)typeof(PhotonNetworkController)
                .GetField("platformTag", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(PhotonNetworkController.Instance);

            RoomConfig roomConfig = new RoomConfig()
            {
                createIfMissing = true,
                isJoinable = true,
                isPublic = isPublic,
                MaxPlayers = 10,
                CustomProps = new ExitGames.Client.Photon.Hashtable()
            {
            { "gameMode", PhotonNetworkController.Instance.currentJoinTrigger.GetFullDesiredGameModeString() },
            { "platform", platformTag },
            { "queueName", GorillaComputer.instance.currentQueue }
        }
            };

            NetworkSystem.Instance.ConnectToRoom(roomName, roomConfig);
        }

        public static string RandomRoomName()
        {
            string text = GenerateRandomString(4);

            if (GorillaComputer.instance.CheckAutoBanListForName(text))
                return text;

            return RandomRoomName();
        }

        public static string GenerateRandomString(int length = 4)
        {
            string random = "";
            for (int i = 0; i < length; i++)
            {
                int rand = UnityEngine.Random.Range(0, 36);
                char c = rand < 26
                    ? (char)('A' + rand)
                    : (char)('0' + (rand - 26));
                random += c;
            }

            return random;
        }
        #endregion
    }
}
