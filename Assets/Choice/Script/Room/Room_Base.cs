using Parse;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Room_Base : MonoBehaviour {

	string poRoom_id;

	bool hasChosen = false;

	Transform tResultsSign;
	TriggerResults triggerResults;

	public abstract string GetRoomName();
	public abstract string GetResults(ParseObject poRoom);

	protected virtual void Awake() {
		tResultsSign = transform.FindChild("Results Sign");
		triggerResults = tResultsSign.GetComponent<TriggerResults>();
		tResultsSign.gameObject.SetActive(false);
	}

	protected virtual void Start() {
		string roomName = GetRoomName();

		ParseQuery<ParseObject> query = ParseObject.GetQuery(roomName);
		query.FindAsync().ContinueWith(t1 => {
			
			IEnumerable<ParseObject> results = t1.Result;
			
			ParseObject poRoom = null;
			foreach(ParseObject result in results) {
				poRoom = result;
				break;
			}
			if(poRoom == null) {
				poRoom = new ParseObject(roomName);
				poRoom.SaveAsync().ContinueWith(t2 => {
					poRoom_id = poRoom.ObjectId;
					UtilLogger.Log(GetRoomName(), "poRoom_id: " + poRoom_id);
				});
			}
			else {
				poRoom_id = poRoom.ObjectId;
				UtilLogger.Log(GetRoomName(), "poRoom_id: " + poRoom_id);
			}
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

		string roomName = GetRoomName();
		ParseQuery<ParseObject> query = ParseObject.GetQuery(roomName);
		query.GetAsync(poRoom_id).ContinueWith(t => {

			ParseObject poRoom = t.Result;

			if(poRoom.ContainsKey(key)) {
				poRoom[key] = poRoom.Get<int>(key) + 1;
			}
			else {
				poRoom[key] = 1;
			}
			poRoom.SaveAsync();
			SetResultsMessage(poRoom);
		});

		tResultsSign.gameObject.SetActive(true);
		hasChosen = true;
	}

	void SetResultsMessage(ParseObject poRoom) {
		string result = GetResults(poRoom);
		triggerResults.Message = result;
	}
}
