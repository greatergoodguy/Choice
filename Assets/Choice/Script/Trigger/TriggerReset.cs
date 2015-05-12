using UnityEngine;
using System.Collections;

public class TriggerReset : MonoBehaviour {

	public readonly string TAG = typeof(TriggerReset).Name;

	void Update() {
		if(Input.GetKeyDown(KeyCode.R)) {
			God.Reset();
		}
	}

	void OnTriggerEnter(Collider other) {
		UtilLogger.Log(TAG, "OnTriggerEnter()");
		God.GuidanceUI.Show();
		God.GuidanceUI.Text = "Press 'R' to reset the game";
	}
	
	void OnTriggerExit(Collider other) {
		UtilLogger.Log(TAG, "OnTriggerExit()");
		God.GuidanceUI.Hide();
		God.GuidanceUI.Text = "";
	}
}
