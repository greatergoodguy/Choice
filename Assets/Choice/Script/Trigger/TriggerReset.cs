using UnityEngine;
using System.Collections;

public class TriggerReset : MonoBehaviour {

	public readonly string TAG = typeof(TriggerReset).Name;

	bool isTriggered = false;

	void Update() {
		if(isTriggered && Input.GetKeyDown(KeyCode.R)) {
			God.Reset();
		}
	}

	void OnTriggerEnter(Collider other) {
		UtilLogger.Log(TAG, "OnTriggerEnter()");
		God.GuidanceUI.Show();
		God.GuidanceUI.Message = "Press 'R' to reset the game";
		isTriggered = true;
	}
	
	void OnTriggerExit(Collider other) {
		UtilLogger.Log(TAG, "OnTriggerExit()");
		God.GuidanceUI.Hide();
		isTriggered = false;
	}
}
