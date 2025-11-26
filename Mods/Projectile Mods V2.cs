using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

namespace StupidTemplate.Mods
{
    internal class ProjectileModsV2
    {
        #region Projectiles V2
        public static void SnowBallSpamV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = -675036877;
                int trail = 163790326;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position;
                Vector3 vel = GorillaLocomotion.GTPlayer.Instance.RightHand.velocityTracker.GetAverageVelocity(true, 0f);
                LaunchProjectile(proj, trail, pos, vel, Color.white);
            }
        }

        public static void SnowBallLaunchV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = -675036877;
                int trail = 163790326;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.transform.position;
                Vector3 vel = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 1000;
                LaunchProjectile(proj, trail, pos, vel, Color.white);
            }
        }

        public static void SnowBallRainV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = -675036877;
                int trail = 163790326;

                var col = Color.white;
                Vector3 pos = GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(Random.Range(-5f, 5f), 5f, Random.Range(-5f, 5f));
                Vector3 vel = GorillaLocomotion.GTPlayer.Instance.InstantaneousVelocity;
                LaunchProjectile(proj, trail, pos, vel, Color.white);
            }
        }

        public static void SnowBallImpactsV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = -675036877;
                int trail = 163790326;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.transform.position;
                Vector3 vel = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 80000;
                LaunchProjectile(proj, trail, pos, vel, Color.white);
            }
        }

        public static void WaterBalloonSpamV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = -1674517839;
                int trail = 16948542;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position;
                Vector3 vel = GorillaLocomotion.GTPlayer.Instance.RightHand.velocityTracker.GetAverageVelocity(true, 0f);
                LaunchProjectile(proj, trail, pos, vel, new Color32(0, 0, 250, 0));
            }
        }

        public static void WaterBalloonLaunchV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = -1674517839;
                int trail = 16948542;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.transform.position;
                Vector3 vel = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 1000;
                LaunchProjectile(proj, trail, pos, vel, new Color32(0, 0, 250, 0));
            }
        }

        public static void WaterBalloonRainsV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = -1674517839;
                int trail = 16948542;

                var col = Color.white;
                Vector3 pos = GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(Random.Range(-5f, 5f), 5f, Random.Range(-5f, 5f));
                Vector3 vel = GorillaLocomotion.GTPlayer.Instance.InstantaneousVelocity;
                LaunchProjectile(proj, trail, pos, vel, new Color32(0, 0, 250, 0));
            }
        }

        public static void WaterBalloonImpactsV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = -1674517839;
                int trail = 16948542;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.transform.position;
                Vector3 vel = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 80000;
                LaunchProjectile(proj, trail, pos, vel, new Color32(0, 0, 250, 0));
            }
        }

        public static void DeadShotSpamV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = 693334698;
                int trail = 163790326;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position;
                Vector3 vel = GorillaLocomotion.GTPlayer.Instance.RightHand.velocityTracker.GetAverageVelocity(true, 0f);
                LaunchProjectile(proj, trail, pos, vel, Color.green);
            }
        }

        public static void DeadShotLaunchV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = 693334698;
                int trail = 163790326;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.transform.position;
                Vector3 vel = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 1000;
                LaunchProjectile(proj, trail, pos, vel, Color.green);
            }
        }

        public static void DeadShotRainsV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = 693334698;
                int trail = 163790326;

                var col = Color.white;
                Vector3 pos = GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(Random.Range(-5f, 5f), 5f, Random.Range(-5f, 5f));
                Vector3 vel = GorillaLocomotion.GTPlayer.Instance.InstantaneousVelocity;
                LaunchProjectile(proj, trail, pos, vel, Color.green);
            }
        }

        public static void DeadShotImpactsV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = 693334698;
                int trail = 163790326;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.transform.position;
                Vector3 vel = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 80000;
                LaunchProjectile(proj, trail, pos, vel, Color.green);
            }
        }

        public static void IceSpamV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = -1671677000;
                int trail = 1848916225;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position;
                Vector3 vel = GorillaLocomotion.GTPlayer.Instance.RightHand.velocityTracker.GetAverageVelocity(true, 0f);
                LaunchProjectile(proj, trail, pos, vel, new Color(0f, 19f, 30f, 38f));
            }
        }

        public static void IceLaunchV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = -1671677000;
                int trail = 1848916225;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.transform.position;
                Vector3 vel = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 1000;
                LaunchProjectile(proj, trail, pos, vel, new Color(0f, 19f, 30f, 38f));
            }
        }

        public static void IceRainsV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = -1671677000;
                int trail = 1848916225;

                var col = Color.white;
                Vector3 pos = GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(Random.Range(-5f, 5f), 5f, Random.Range(-5f, 5f));
                Vector3 vel = GorillaLocomotion.GTPlayer.Instance.InstantaneousVelocity;
                LaunchProjectile(proj, trail, pos, vel, new Color(0f, 19f, 30f, 38f));
            }
        }

        public static void IceImpactsV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = -1671677000;
                int trail = 1848916225;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.transform.position;
                Vector3 vel = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 80000;
                LaunchProjectile(proj, trail, pos, vel, new Color(0f, 19f, 30f, 38f));
            }
        }

        public static void LeafSpamV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = 1705139863;
                int trail = 163790326;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position;
                Vector3 vel = GorillaLocomotion.GTPlayer.Instance.RightHand.velocityTracker.GetAverageVelocity(true, 0f);
                LaunchProjectile(proj, trail, pos, vel, Color.green);
            }
        }

        public static void LeafLaunchV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = 1705139863;
                int trail = 163790326;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.transform.position;
                Vector3 vel = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 1000;
                LaunchProjectile(proj, trail, pos, vel, Color.green);
            }
        }

        public static void LeafRainsV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = 1705139863;
                int trail = 163790326;

                var col = Color.white;
                Vector3 pos = GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(Random.Range(-5f, 5f), 5f, Random.Range(-5f, 5f));
                Vector3 vel = GorillaLocomotion.GTPlayer.Instance.InstantaneousVelocity;
                LaunchProjectile(proj, trail, pos, vel, Color.green);
            }
        }

        public static void LeafImpactsV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = 1705139863;
                int trail = 163790326;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.transform.position;
                Vector3 vel = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 80000;
                LaunchProjectile(proj, trail, pos, vel, Color.green);
            }
        }

        public static void CupidSpamV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = 825718363;
                int trail = 1848916225;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position;
                Vector3 vel = GorillaLocomotion.GTPlayer.Instance.RightHand.velocityTracker.GetAverageVelocity(true, 0f);
                LaunchProjectile(proj, trail, pos, vel, Color.white);
            }
        }

        public static void CupidLaunchV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = 825718363;
                int trail = 1848916225;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.transform.position;
                Vector3 vel = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 1000;
                LaunchProjectile(proj, trail, pos, vel, Color.white);
            }
        }

        public static void CupidRainsV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = 825718363;
                int trail = 1848916225;

                var col = Color.white;
                Vector3 pos = GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(Random.Range(-5f, 5f), 5f, Random.Range(-5f, 5f));
                Vector3 vel = GorillaLocomotion.GTPlayer.Instance.InstantaneousVelocity;
                LaunchProjectile(proj, trail, pos, vel, Color.white);
            }
        }

        public static void CupidImpactsV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = 825718363;
                int trail = 1848916225;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.transform.position;
                Vector3 vel = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 80000;
                LaunchProjectile(proj, trail, pos, vel, Color.white);
            }
        }

        public static void SlingShotSpamV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = -820530352;
                int trail = 1432124712;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position;
                Vector3 vel = GorillaLocomotion.GTPlayer.Instance.RightHand.velocityTracker.GetAverageVelocity(true, 0f);
                LaunchProjectile(proj, trail, pos, vel, Color.white);
            }
        }

        public static void SlingShotLaunchV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = -820530352;
                int trail = 1432124712;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.transform.position;
                Vector3 vel = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 1000;
                LaunchProjectile(proj, trail, pos, vel, Color.white);
            }
        }

        public static void SlingShotRainsV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = -820530352;
                int trail = 1432124712;

                var col = Color.white;
                Vector3 pos = GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(Random.Range(-5f, 5f), 5f, Random.Range(-5f, 5f));
                Vector3 vel = GorillaLocomotion.GTPlayer.Instance.InstantaneousVelocity;
                LaunchProjectile(proj, trail, pos, vel, Color.white);
            }
        }

        public static void SlingShotImpactsV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = -820530352;
                int trail = 1432124712;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.transform.position;
                Vector3 vel = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 80000;
                LaunchProjectile(proj, trail, pos, vel, Color.white);
            }
        }

        public static void GaySpamV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = 1511318966;
                int trail = 16948542;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position;
                Vector3 vel = GorillaLocomotion.GTPlayer.Instance.RightHand.velocityTracker.GetAverageVelocity(true, 0f);
                LaunchProjectile(proj, trail, pos, vel, Color.white);
            }
        }

        public static void GayLaunchV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = 1511318966;
                int trail = 16948542;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.transform.position;
                Vector3 vel = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 1000;
                LaunchProjectile(proj, trail, pos, vel, Color.white);
            }
        }

        public static void GayRainsV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = 1511318966;
                int trail = 16948542;

                var col = Color.white;
                Vector3 pos = GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(Random.Range(-5f, 5f), 5f, Random.Range(-5f, 5f));
                Vector3 vel = GorillaLocomotion.GTPlayer.Instance.InstantaneousVelocity;
                LaunchProjectile(proj, trail, pos, vel, Color.white);
            }
        }

        public static void GayImpactsV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = 1511318966;
                int trail = 16948542;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.transform.position;
                Vector3 vel = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 80000;
                LaunchProjectile(proj, trail, pos, vel, Color.white);
            }
        }

        public static void SpiderSpamV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = -790645151;
                int trail = -1232128945;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position;
                Vector3 vel = GorillaLocomotion.GTPlayer.Instance.RightHand.velocityTracker.GetAverageVelocity(true, 0f);
                LaunchProjectile(proj, trail, pos, vel, Color.white);
            }
        }

        public static void SpiderLaunchV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = -790645151;
                int trail = -1232128945;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.transform.position;
                Vector3 vel = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 1000;
                LaunchProjectile(proj, trail, pos, vel, Color.white);
            }
        }

        public static void SpiderRainsV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = -790645151;
                int trail = -1232128945;

                var col = Color.white;
                Vector3 pos = GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(Random.Range(-5f, 5f), 5f, Random.Range(-5f, 5f));
                Vector3 vel = GorillaLocomotion.GTPlayer.Instance.InstantaneousVelocity;
                LaunchProjectile(proj, trail, pos, vel, Color.white);
            }
        }

        public static void SpiderImpactsV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = -790645151;
                int trail = -1232128945;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.transform.position;
                Vector3 vel = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 80000;
                LaunchProjectile(proj, trail, pos, vel, Color.white);
            }
        }

        public static void MoltenSpamV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = -1280105888;
                int trail = -1;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position;
                Vector3 vel = GorillaLocomotion.GTPlayer.Instance.RightHand.velocityTracker.GetAverageVelocity(true, 0f);
                LaunchProjectile(proj, trail, pos, vel, Color.red);
            }
        }

        public static void MoltenLaunchV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = -1280105888;
                int trail = -1;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.transform.position;
                Vector3 vel = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 1000;
                LaunchProjectile(proj, trail, pos, vel, Color.red);
            }
        }

        public static void MoltenRainsV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = -1280105888;
                int trail = -1;

                var col = Color.white;
                Vector3 pos = GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(Random.Range(-5f, 5f), 5f, Random.Range(-5f, 5f));
                Vector3 vel = GorillaLocomotion.GTPlayer.Instance.InstantaneousVelocity;
                LaunchProjectile(proj, trail, pos, vel, Color.red);
            }
        }

        public static void MoltenImpactsV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = -1280105888;
                int trail = -1;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.transform.position;
                Vector3 vel = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 80000;
                LaunchProjectile(proj, trail, pos, vel, Color.red);
            }
        }

        public static void RockSpamV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = -622368518;
                int trail = 16948542;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position;
                Vector3 vel = GorillaLocomotion.GTPlayer.Instance.RightHand.velocityTracker.GetAverageVelocity(true, 0f);
                LaunchProjectile(proj, trail, pos, vel, Color.white);
            }
        }

        public static void RockLaunchV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = -622368518;
                int trail = 16948542;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.transform.position;
                Vector3 vel = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 1000;
                LaunchProjectile(proj, trail, pos, vel, Color.white);
            }
        }

        public static void RockRainsV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = -622368518;
                int trail = 16948542;

                var col = Color.white;
                Vector3 pos = GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(Random.Range(-5f, 5f), 5f, Random.Range(-5f, 5f));
                Vector3 vel = GorillaLocomotion.GTPlayer.Instance.InstantaneousVelocity;
                LaunchProjectile(proj, trail, pos, vel, Color.white);
            }
        }

        public static void RockImpactsV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = -622368518;
                int trail = 16948542;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.transform.position;
                Vector3 vel = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 80000;
                LaunchProjectile(proj, trail, pos, vel, Color.white);
            }
        }

        public static void VotingRockSpamV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = -235083827;
                int trail = 16948542;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position;
                Vector3 vel = GorillaLocomotion.GTPlayer.Instance.RightHand.velocityTracker.GetAverageVelocity(true, 0f);
                LaunchProjectile(proj, trail, pos, vel, Color.white);
            }
        }

        public static void VotingRockLaunchV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = -235083827;
                int trail = 16948542;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.transform.position;
                Vector3 vel = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 1000;
                LaunchProjectile(proj, trail, pos, vel, Color.white);
            }
        }

        public static void VotingRockRainsV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = -235083827;
                int trail = 16948542;

                var col = Color.white;
                Vector3 pos = GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(Random.Range(-5f, 5f), 5f, Random.Range(-5f, 5f));
                Vector3 vel = GorillaLocomotion.GTPlayer.Instance.InstantaneousVelocity;
                LaunchProjectile(proj, trail, pos, vel, Color.white);
            }
        }

        public static void VotingRockImpactsV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = -235083827;
                int trail = 16948542;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.transform.position;
                Vector3 vel = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 80000;
                LaunchProjectile(proj, trail, pos, vel, Color.white);
            }
        }

        public static void HalloweenSpamV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = 1077936051;
                int trail = 1848916225;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position;
                Vector3 vel = GorillaLocomotion.GTPlayer.Instance.RightHand.velocityTracker.GetAverageVelocity(true, 0f);
                LaunchProjectile(proj, trail, pos, vel, Color.white);
            }
        }

        public static void HalloweenLaunchV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = 1077936051;
                int trail = 1848916225;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.transform.position;
                Vector3 vel = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 1000;
                LaunchProjectile(proj, trail, pos, vel, Color.white);
            }
        }

        public static void HalloweenRainsV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = 1077936051;
                int trail = 1848916225;

                var col = Color.white;
                Vector3 pos = GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(Random.Range(-5f, 5f), 5f, Random.Range(-5f, 5f));
                Vector3 vel = GorillaLocomotion.GTPlayer.Instance.InstantaneousVelocity;
                LaunchProjectile(proj, trail, pos, vel, Color.white);
            }
        }

        public static void HalloweenImpactsV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = 1077936051;
                int trail = 1848916225;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.transform.position;
                Vector3 vel = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 80000;
                LaunchProjectile(proj, trail, pos, vel, Color.white);
            }
        }

        public static void FishFoodSpamV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = -1509512060;
                int trail = 16948542;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position;
                Vector3 vel = GorillaLocomotion.GTPlayer.Instance.RightHand.velocityTracker.GetAverageVelocity(true, 0f);
                LaunchProjectile(proj, trail, pos, vel, Color.white);
            }
        }

        public static void FishFoodLaunchV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = -1509512060;
                int trail = 16948542;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.transform.position;
                Vector3 vel = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 1000;
                LaunchProjectile(proj, trail, pos, vel, Color.white);
            }
        }

        public static void FishFoodRainsV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = -1509512060;
                int trail = 16948542;

                var col = Color.white;
                Vector3 pos = GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(Random.Range(-5f, 5f), 5f, Random.Range(-5f, 5f));
                Vector3 vel = GorillaLocomotion.GTPlayer.Instance.InstantaneousVelocity;
                LaunchProjectile(proj, trail, pos, vel, Color.white);
            }
        }

        public static void FishFoodImpactsV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = -1509512060;
                int trail = 16948542;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.transform.position;
                Vector3 vel = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 80000;
                LaunchProjectile(proj, trail, pos, vel, Color.white);
            }
        }

        public static void ScienceSpamV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = -716425086;
                int trail = 163790326;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position;
                Vector3 vel = GorillaLocomotion.GTPlayer.Instance.RightHand.velocityTracker.GetAverageVelocity(true, 0f);
                LaunchProjectile(proj, trail, pos, vel, Color.blue);
            }
        }

        public static void ScienceLaunchV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = -716425086;
                int trail = 163790326;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.transform.position;
                Vector3 vel = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 1000;
                LaunchProjectile(proj, trail, pos, vel, Color.blue);
            }
        }

        public static void ScienceRainsV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = -716425086;
                int trail = 163790326;

                var col = Color.white;
                Vector3 pos = GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(Random.Range(-5f, 5f), 5f, Random.Range(-5f, 5f));
                Vector3 vel = GorillaLocomotion.GTPlayer.Instance.InstantaneousVelocity;
                LaunchProjectile(proj, trail, pos, vel, Color.blue);
            }
        }

        public static void ScienceImpactsV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = -716425086;
                int trail = 163790326;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.transform.position;
                Vector3 vel = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 80000;
                LaunchProjectile(proj, trail, pos, vel, Color.blue);
            }
        }

        public static void DragonSpamV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = PoolUtils.GameObjHashCode(GameObject.Find("Environment Objects/05Maze_PersistentObjects/GlobalObjectPools/DragonSlingshotProjectile_PrefabV Variant(PoolIndex=1)"));
                int trail = 163790326;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position;
                Vector3 vel = GorillaLocomotion.GTPlayer.Instance.RightHand.velocityTracker.GetAverageVelocity(true, 0f);
                LaunchProjectile(proj, trail, pos, vel, Color.red);
            }
        }

        public static void DragonLaunchV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = PoolUtils.GameObjHashCode(GameObject.Find("Environment Objects/05Maze_PersistentObjects/GlobalObjectPools/DragonSlingshotProjectile_PrefabV Variant(PoolIndex=1)"));
                int trail = 163790326;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.transform.position;
                Vector3 vel = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 1000;
                LaunchProjectile(proj, trail, pos, vel, Color.red);
            }
        }

        public static void DragonRainsV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = PoolUtils.GameObjHashCode(GameObject.Find("Environment Objects/05Maze_PersistentObjects/GlobalObjectPools/DragonSlingshotProjectile_PrefabV Variant(PoolIndex=1)"));
                int trail = 163790326;

                var col = Color.white;
                Vector3 pos = GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(Random.Range(-5f, 5f), 5f, Random.Range(-5f, 5f));
                Vector3 vel = GorillaLocomotion.GTPlayer.Instance.InstantaneousVelocity;
                LaunchProjectile(proj, trail, pos, vel, Color.red);
            }
        }

        public static void DragonImpactsV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = PoolUtils.GameObjHashCode(GameObject.Find("Environment Objects/05Maze_PersistentObjects/GlobalObjectPools/DragonSlingshotProjectile_PrefabV Variant(PoolIndex=1)"));
                int trail = 163790326;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.transform.position;
                Vector3 vel = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 80000;
                LaunchProjectile(proj, trail, pos, vel, Color.red);
            }
        }

        public static void DevilSpamV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = PoolUtils.GameObjHashCode(GameObject.Find("Environment Objects/05Maze_PersistentObjects/GlobalObjectPools/DevilBowProjectile Variant(PoolIndex=0)"));
                int trail = -1;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position;
                Vector3 vel = GorillaLocomotion.GTPlayer.Instance.RightHand.velocityTracker.GetAverageVelocity(true, 0f);
                LaunchProjectile(proj, trail, pos, vel, Color.white);
            }
        }

        public static void DevilLaunchV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = PoolUtils.GameObjHashCode(GameObject.Find("Environment Objects/05Maze_PersistentObjects/GlobalObjectPools/DevilBowProjectile Variant(PoolIndex=0)"));
                int trail = -1;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.transform.position;
                Vector3 vel = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 1000;
                LaunchProjectile(proj, trail, pos, vel, Color.white);
            }
        }

        public static void DevilRainsV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = PoolUtils.GameObjHashCode(GameObject.Find("Environment Objects/05Maze_PersistentObjects/GlobalObjectPools/DevilBowProjectile Variant(PoolIndex=0)"));
                int trail = -1;

                var col = Color.white;
                Vector3 pos = GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(Random.Range(-5f, 5f), 5f, Random.Range(-5f, 5f));
                Vector3 vel = GorillaLocomotion.GTPlayer.Instance.InstantaneousVelocity;
                LaunchProjectile(proj, trail, pos, vel, Color.white);
            }
        }

        public static void DevilImpactsV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = PoolUtils.GameObjHashCode(GameObject.Find("Environment Objects/05Maze_PersistentObjects/GlobalObjectPools/DevilBowProjectile Variant(PoolIndex=0)"));
                int trail = -1;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.transform.position;
                Vector3 vel = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 80000;
                LaunchProjectile(proj, trail, pos, vel, Color.white);
            }
        }

        public static void AppleSpamV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = 1918888813;
                int trail = -1;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.position;
                Vector3 vel = GorillaLocomotion.GTPlayer.Instance.RightHand.velocityTracker.GetAverageVelocity(true, 0f);
                LaunchProjectile(proj, trail, pos, vel, Color.white);
            }
        }

        public static void AppleLaunchV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = 1918888813;
                int trail = -1;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.transform.position;
                Vector3 vel = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 1000;
                LaunchProjectile(proj, trail, pos, vel, Color.white);
            }
        }

        public static void AppleRainsV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = 1918888813;
                int trail = -1;

                var col = Color.white;
                Vector3 pos = GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(Random.Range(-5f, 5f), 5f, Random.Range(-5f, 5f));
                Vector3 vel = GorillaLocomotion.GTPlayer.Instance.InstantaneousVelocity;
                LaunchProjectile(proj, trail, pos, vel, Color.white);
            }
        }

        public static void AppleImpactsV2()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int proj = 1918888813;
                int trail = -1;

                var col = Color.white;
                Vector3 pos = GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.transform.position;
                Vector3 vel = -GorillaLocomotion.GTPlayer.Instance.RightHand.controllerTransform.up * Time.deltaTime * 80000;
                LaunchProjectile(proj, trail, pos, vel, Color.white);
            }
        }
        #endregion
        #region VARS
        public static float projectiletimeout = 0.1f;

        private static void LaunchProjectile(int projHash, int trailHash, Vector3 pos, Vector3 vel, Color col)
        {
            var projectile = ObjectPools.instance.Instantiate(projHash).GetComponent<SlingshotProjectile>();
            if (trailHash != -1)
            {
                var trail = ObjectPools.instance.Instantiate(trailHash).GetComponent<SlingshotProjectileTrail>();
                trail.AttachTrail(projectile.gameObject, false, false);
            }
            var counter = 0;
            projectile.Launch(pos, vel, NetworkSystem.Instance.LocalPlayer, false, false, counter++, 1, true, col);
        }
        #endregion
    }
}
