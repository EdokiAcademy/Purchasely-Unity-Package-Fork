using System;
using UnityEngine;

namespace PurchaselyRuntime
{
	internal class StartProxy : AndroidJavaProxy
	{
		private readonly Action<bool, string> _onStartCompleted;

		internal StartProxy(Action<bool, string> onStartCompleted) : base("com.purchasely.unity.proxy.StartProxy")
		{
			Debug.Log("Creating StartProxy with onStartCompleted");
			_onStartCompleted = onStartCompleted;
		}

		public void onStartCompleted(bool success, string error)
		{
			Debug.Log("StartProxy onStartCompleted called with success: " + success + " and error: " + error);
			AsyncCallbackHelper.Instance.Queue(() => _onStartCompleted(success, error));
		}
	}
}