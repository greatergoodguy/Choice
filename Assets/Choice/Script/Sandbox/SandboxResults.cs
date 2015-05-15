using Parse;
using UnityEngine;
using System.Collections;

public class SandboxResults : MonoBehaviour {
	public readonly string TAG = typeof(SandboxResults).Name;
	
	bool isTriggered = false;
	
	void Update() {
	}
	
	void OnTriggerEnter(Collider other) {
		UtilLogger.Log(TAG, "OnTriggerEnter()");
		God.GuidanceUI.Show();

		ParseObject poRoom1 = God.Parse.poRoom1;
		if(poRoom1 == null) {
			God.GuidanceUI.Text = "Results: \nYou have no friends.";
		}
		else {
			string key1 = "door_locked";
			int door_locked = poRoom1.Get<int>(key1);

			string key2 = "door_unlocked";
			int door_unlocked = poRoom1.Get<int>(key2);

			float percentLocked = ((float) door_locked) / (door_unlocked + door_locked);
			float percentUnlocked = ((float) door_unlocked) / (door_unlocked + door_locked);
			God.GuidanceUI.Text = "Results: \n" + percentLocked + "% of players locked the door.\n" + percentUnlocked + "% of players unlocked the door.";
		}
		isTriggered = true;
	}
	
	void OnTriggerExit(Collider other) {
		UtilLogger.Log(TAG, "OnTriggerExit()");
		God.GuidanceUI.Hide();
		isTriggered = false;
	}

}
