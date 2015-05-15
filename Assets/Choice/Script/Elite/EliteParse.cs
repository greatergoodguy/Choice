using Parse;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EliteParse : MonoBehaviour {

	private readonly string TAG = typeof(EliteParse).Name;

	ParseObject poRoom1;
	bool isLoadedRoom1 = false;

	void Start() {
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
				poRoom1.SaveAsync().ContinueWith(u => {
					isLoadedRoom1 = true;
				});

			}
			else {
				isLoadedRoom1 = true;
			}
		});
	}



	public void UpdateRoom1(bool isDoorLocked) {
		if(!isLoadedRoom1) {
			return;}

		if(isDoorLocked) {
			string key = "door_unlocked";
			poRoom1[key] = poRoom1.Get<int>(key) + 1;
		}
		else {
			string key = "door_locked";
			poRoom1[key] = poRoom1.Get<int>(key) + 1;
		}
		poRoom1.SaveAsync();
	}

}
