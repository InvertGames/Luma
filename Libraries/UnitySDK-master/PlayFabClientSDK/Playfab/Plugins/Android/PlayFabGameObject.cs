using UnityEngine;
using System.Collections;

namespace PlayFab
{
	public class PlayFabGameObject : MonoBehaviour
	{
		public void GCMRegistered(string id)
		{
			PlayFabGoogleCloudMessaging.registrationComplete (id, null);
		}

		public void GCMRegisterError(string error)
		{
			PlayFabGoogleCloudMessaging.registrationComplete (null, error);
		}

		public void GCMMessageReceived(string message)
		{
			PlayFabGoogleCloudMessaging.messageReceived (message);
		}
	}

}