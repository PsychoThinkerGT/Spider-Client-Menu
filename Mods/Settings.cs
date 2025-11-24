using StupidTemplate.Menu;
using static StupidTemplate.Menu.Main;
using static StupidTemplate.Settings;

namespace StupidTemplate.Mods
{
    internal class SettingsMods
    {
        public static void Home()
        {
            Main.currentCategory = 0;
        }

        /*public static void EnterSettings()
        {
            buttonsType = 1;
            pageNumber = 0;
        }

        public static void MenuSettings()
        {
            buttonsType = 2;
            pageNumber = 0;
        }

        public static void MovementSettings()
        {
            buttonsType = 3;
            pageNumber = 0;
        }

        public static void ProjectileSettings()
        {
            buttonsType = 4;
            pageNumber = 0;
        }

        public static void Projectile1Settings()
        {
            buttonsType = 5;
            pageNumber = 0;
        }

        public static void EnterSafety()
        {
            buttonsType = 6;
            pageNumber = 0;
        }
        public static void EnterRoom()
        {
            buttonsType = 7;
            pageNumber = 0;
        }
        public static void EnterMovement()
        {
            buttonsType = 8;
            pageNumber = 0;
        }
        public static void EnterVisual()
        {
            buttonsType = 9;
            pageNumber = 0;
        }
        public static void EnterVrrig()
        {
            buttonsType = 10;
            pageNumber = 0;
        }
        public static void EnterAnimal()
        {
            buttonsType = 11;
            pageNumber = 0;
        }
        public static void EnterWorld()
        {
            buttonsType = 12;
            pageNumber = 0;
        }
        public static void EnterWater()
        {
            buttonsType = 13;
            pageNumber = 0;
        }
        public static void EnterTag()
        {
            buttonsType = 14;
            pageNumber = 0;
        }
        public static void EnterProjectile()
        {
            buttonsType = 15;
            pageNumber = 0;
        }
        public static void EnterProjectileV2()
        {
            buttonsType = 16;
            pageNumber = 0;
        }
        public static void EnterGlider()
        {
            buttonsType = 17;
            pageNumber = 0;
        }

        /*public static void EnterHalloween()
        {
            buttonsType = 17;
            pageNumber = 0;
        }

        public static void EnterRandom()
        {
            buttonsType = 18;
            pageNumber = 0;
        }

        public static void EnterCreds()
        {
            buttonsType = 19;
            pageNumber = 0;
        }*/

        public static void RightHand()
        {
            rightHanded = true;
        }

        public static void LeftHand()
        {
            rightHanded = false;
        }

        public static void EnableFPSCounter()
        {
            fpsCounter = true;
        }

        public static void DisableFPSCounter()
        {
            fpsCounter = false;
        }

        public static void EnableNotifications()
        {
            disableNotifications = false;
        }

        public static void DisableNotifications()
        {
            disableNotifications = true;
        }

        public static void EnableDisconnectButton()
        {
            disconnectButton = true;
        }

        public static void DisableDisconnectButton()
        {
            disconnectButton = false;
        }
    }
}
