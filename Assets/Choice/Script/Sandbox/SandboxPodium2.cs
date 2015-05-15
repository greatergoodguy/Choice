using UnityEngine;
using System.Collections;

public class SandboxPodium2 : MonoBehaviour {

	private readonly string TAG = typeof(SandboxPodium1).Name;

	bool isTriggered = false;

	void Update() {
		if(isTriggered && Input.GetKeyDown(KeyCode.Z)) {
			God.Parse.UpdateRoom1(true);
		}
	}

	void OnTriggerEnter(Collider other) {
		UtilLogger.Log(TAG, "OnTriggerEnter()");
		isTriggered = true;
	}
	
	void OnTriggerExit(Collider other) {
		UtilLogger.Log(TAG, "OnTriggerExit()");
		isTriggered = false;
	}
}
