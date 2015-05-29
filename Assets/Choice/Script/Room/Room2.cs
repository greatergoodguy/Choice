using Parse;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Room2 : MonoBehaviour {

	private readonly string TAG = typeof(Room2).Name;
	
	string poRoom_id;
	
	bool hasChosen = false;

	Transform tResultsSign;
	TriggerResults triggerResults;

	void Awake() {
		tResultsSign = transform.FindChild("Results Sign");
		triggerResults = transform.FindChild("Results Sign").GetComponent<TriggerResults>();
		tResultsSign.gameObject.SetActive(false);
	}

	void Start() {
		UtilLogger.Log(TAG, "Start");
		ParseQuery<ParseObject> query = ParseObject.GetQuery("Room2");
		query.FindAsync().ContinueWith(t => {
			
			IEnumerable<ParseObject> results = t.Result;
			
			ParseObject poRoom = null;
			foreach(ParseObject result in results) {
				poRoom = result;
				break;
			}
			if(poRoom == null) {
				poRoom = new ParseObject(TAG);
				poRoom["apple"] = 0;
				poRoom["banana"] = 0;
				poRoom["pineapple"] = 0;
				poRoom["watermelon"] = 0;
				poRoom.SaveAsync();
			}
			poRoom_id = poRoom.ObjectId;
			UtilLogger.Log(TAG, "poRoom_id: " + poRoom_id);

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
			
//			SetResultsMessage(poRoom);
		});
		
		tResultsSign.gameObject.SetActive(true);
		hasChosen = true;
	}
}
