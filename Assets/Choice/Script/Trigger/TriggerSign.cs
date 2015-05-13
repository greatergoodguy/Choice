using UnityEngine;
using System.Collections;

public class TriggerSign : MonoBehaviour {

	public readonly string TAG = typeof(TriggerSign).Name;

	public string message;

	bool isTriggered = false;

	void Update() {
		bool isShiftKeyDown = Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.LeftShift);
		if(isTriggered && isShiftKeyDown) {
			God.HelpUI.Hide();

			God.GuidanceUI.Text = "I am a good sign";
			God.GuidanceUI.Show();
		}
	}
	
	void OnTriggerEnter(Collider other) {
		UtilLogger.Log(TAG, "OnTriggerEnter()");
		God.HelpUI.Show();
		God.HelpUI.Text = "Press 'Shift' to read this sign";
		isTriggered = true;
	}
	
	void OnTriggerExit(Collider other) {
		UtilLogger.Log(TAG, "OnTriggerExit()");
		God.HelpUI.Hide();
		God.GuidanceUI.Hide();
		isTriggered = false;
	}
}
