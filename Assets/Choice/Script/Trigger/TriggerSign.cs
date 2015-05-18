using UnityEngine;
using System.Collections;

public class TriggerSign : MonoBehaviour {

	public readonly string TAG = typeof(TriggerSign).Name;

	public string message;

	bool isTriggered = false;
	bool isSignShowing = false;

	void Update() {
		bool isShiftKeyDown = Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.LeftShift);
		if(isTriggered && isShiftKeyDown && !isSignShowing) {
			God.HelpUI.Hide();

			God.Hero.Freeze();

			God.GuidanceUI.Message = "I am a good sign";
			God.GuidanceUI.Extra = "Press 'Shift' to Exit";
			God.GuidanceUI.Show();
			isSignShowing = true;
		}
		else if(isTriggered && isShiftKeyDown && isSignShowing) {

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
