using Parse;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Room1 : MonoBehaviour {

	private readonly string TAG = typeof(Room1).Name;
	
	string poRoom_id;

	bool hasChosen = false;

	JunctionDoor junctionDoor;

	Transform tResultsSign;
	TriggerResults triggerResults;

	void Awake() {
		junctionDoor = transform.FindChild("Other/Junction 3 Port/Room_Door_UNLOCKED/Room_Door_Trigger").GetComponent<JunctionDoor>();

		tResultsSign = transform.FindChild("Results Sign");
		triggerResults = transform.FindChild("Results Sign").GetComponent<TriggerResults>();
		tResultsSign.gameObject.SetActive(false);
	}

	void Start() {
		UtilLogger.Log(TAG, "Start");
		ParseQuery<ParseObject> query = ParseObject.GetQuery(TAG);
		query.FindAsync().ContinueWith(t => {
			
			IEnumerable<ParseObject> results = t.Result;

			ParseObject poRoom = null;
			foreach(ParseObject result in results) {
				poRoom = result;
				break;
			}
			if(poRoom == null) {
				poRoom = new ParseObject(TAG);
				poRoom["door_unlocked"] = 0;
				poRoom["door_locked"] = 0;
				poRoom.SaveAsync();
			}
			poRoom_id = poRoom.ObjectId;
			UtilLogger.Log(TAG, "poRoom_id: " + poRoom_id);

			SetResultsMessage(poRoom);
		});	
	}

	public void Choice(string key) {
		if(poRoom_id == null) {
			God.SFX.Invalid.Play();
			return;}
		
		if(hasChosen) {
			God.SFX.Invalid.Play();
			return;
		}
		God.SFX.PodiumBeep.Play();
		
		ParseQuery<ParseObject> query = ParseObject.GetQuery(TAG);
		query.GetAsync(poRoom_id).ContinueWith(t => {
			ParseObject poRoom = t.Result;

			poRoom[key] = poRoom.Get<int>(key) + 1;
			poRoom.SaveAsync();
			
			SetResultsMessage(poRoom);
		});
		
		tResultsSign.gameObject.SetActive(true);
		hasChosen = true;
	}

	void SetResultsMessage(ParseObject poRoom) {
		if(poRoom == null) {
			God.GuidanceUI.Message = "Results: \nYou have no friends.";
		}
		else {
			string key1 = "door_locked";
			int door_locked = poRoom.Get<int>(key1);

			string key2 = "door_unlocked";
			int door_unlocked = poRoom.Get<int>(key2);

			float percentLocked = 100 * ((float) door_locked) / (door_unlocked + door_locked);
			float percentUnlocked = 100 * ((float) door_unlocked) / (door_unlocked + door_locked);
			triggerResults.Message = "Results: \n" + percentLocked + "% of players locked the door.\n" + percentUnlocked + "% of players unlocked the door.";
		}
	}
}
