using Parse;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Room1 : MonoBehaviour {

	private readonly string TAG = typeof(Room1).Name;

	public ParseObject poRoom1;
	string poRoom1_id;
	
	void Start() {
		UtilLogger.Log(TAG, "Start");
		ParseQuery<ParseObject> query = ParseObject.GetQuery("Room1");
		query.FindAsync().ContinueWith(t => {
			
			IEnumerable<ParseObject> results = t.Result;
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
		});	
	}

	void Update() {
	
	}

	public void ChoiceLocked() {
		if(poRoom1_id == null) {
			return;}

		ParseQuery<ParseObject> query = ParseObject.GetQuery("Room1");
		query.GetAsync(poRoom1_id).ContinueWith(t => {
			poRoom1 = t.Result;

			string key = "door_locked";
			poRoom1[key] = poRoom1.Get<int>(key) + 1;
			poRoom1.SaveAsync();
		});
	}

	public void ChoiceUnLocked() {
		if(poRoom1_id == null) {
			return;}

		ParseQuery<ParseObject> query = ParseObject.GetQuery("Room1");
		query.GetAsync(poRoom1_id).ContinueWith(t => {
			poRoom1 = t.Result;
			
			string key = "door_unlocked";
			poRoom1[key] = poRoom1.Get<int>(key) + 1;
			poRoom1.SaveAsync();
		});
	}
}
