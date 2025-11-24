using Photon.Pun;
using StupidTemplate.Mods;
using UnityEngine;
using static StupidTemplate.Menu.Main;
using static StupidTemplate.Settings;

namespace StupidTemplate.Classes
{
	public class Button : MonoBehaviour
	{
		public string relatedText;

		public static float buttonCooldown = 0f;
		
		public void OnTriggerEnter(Collider collider)
		{
			if (Time.time > buttonCooldown && collider == buttonCollider && menu != null)
			{
                buttonCooldown = Time.time + 0.2f;
                GorillaTagger.Instance.StartVibration(rightHanded, GorillaTagger.Instance.tagHapticStrength / 2f, GorillaTagger.Instance.tagHapticDuration / 2f);
                VRRig.LocalRig.PlayHandTapLocal(Codes.ButtonSoundIndex, rightHanded, 0.4f);
                if (PhotonNetwork.InRoom && GetIndex("Serversided Button Sounds [UND]").enabled)
                {
                    GorillaTagger.Instance.myVRRig.GetView.RPC("RPC_PlayHandTap", RpcTarget.Others, new object[] {
                        Codes.ButtonSoundIndex,
                        rightHanded,
                        150f
                    });
                    Codes.FlushRpcs();
                }
                Toggle(this.relatedText);
            }
		}
	}
}
