using Parse;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Room1 : MonoBehaviour {

	private readonly string TAG = typeof(Room1).Name;
	
	string poRoom1_id;

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
		ParseQuery<ParseObject> query = ParseObject.GetQuery("Room1");
		query.FindAsync().ContinueWith(t => {
			
			IEnumerable<ParseObject> results = t.Result;

			ParseObject poRoom1 = null;
			foreach(ParseObject result in results) {
				poRoom1 = result;
				break;
			}
			if(poRoom1 == null) {
				poRoom1 = new ParseObject("Room1");
				poRoom1["door_unlocked"] = 0;
				poRoom1["door_locked"] = 0;
				poRoom1.SaveAsync();
			}
			poRoom1_id = poRoom1.ObjectId;
			UtilLogger.Log(TAG, "poRoom1_id: " + poRoom1_id);

			SetResultsMessage(poRoom1);
		});	
	}

	void Update() {
	
	}

	public void ChoiceLocked() {
		if(poRoom1_id == null) {
			return;}

		if(hasChosen) {
			God.SFX.Invalid.Play();
			return;
		}
		God.SFX.PodiumBeep.Play();

		ParseQuery<ParseObject> query = ParseObject.GetQuery("Room1");
		query.GetAsync(poRoom1_id).ContinueWith(t => {
			ParseObject poRoom1 = t.Result;

			string key = "door_locked";
			poRoom1[key] = poRoom1.Get<int>(key) + 1;
			poRoom1.SaveAsync();

			SetResultsMessage(poRoom1);
		});

		tResultsSign.gameObject.SetActive(true);
		hasChosen = true;
	}

	public void ChoiceUnLocked() {
		if(poRoom1_id == null) {
			return;}

		if(hasChosen) {
			God.SFX.Invalid.Play();
			return;
		}
		God.SFX.PodiumBeep.Play();

		ParseQuery<ParseObject> query = ParseObject.GetQuery("Room1");
		query.GetAsync(poRoom1_id).ContinueWith(t => {
			ParseObject poRoom1 = t.Result;
			
			string key = "door_unlocked";
			poRoom1[key] = poRoom1.Get<int>(key) + 1;
			poRoom1.SaveAsync();

			SetResultsMessage(poRoom1);
		});

		junctionDoor.Open();
		tResultsSign.gameObject.SetActive(true);
		hasChosen = true;
	}

	void SetResultsMessage(ParseObject poRoom1) {
		if(poRoom1 == null) {
			God.GuidanceUI.Message = "Results: \nYou have no friends.";
		}
		else {
			string key1 = "door_locked";
			int door_locked = poRoom1.Get<int>(key1);

			string key2 = "door_unlocked";
			int door_unlocked = poRoom1.Get<int>(key2);

			float percentLocked = 100 * ((float) door_locked) / (door_unlocked + door_locked);
			float percentUnlocked = 100 * ((float) door_unlocked) / (door_unlocked + door_locked);
			triggerResults.Message = "Results: \n" + percentLocked + "% of players locked the door.\n" + percentUnlocked + "% of players unlocked the door.";
		}
	}
}
