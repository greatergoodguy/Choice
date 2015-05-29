using Parse;
using UnityEngine;
using System.Collections;

public class Room3 : Room_Base {

	private readonly string TAG = typeof(Room3).Name;

	void Awake() {
		base.Awake();
		UtilLogger.Log(TAG, "Awake()");
	}

	void Start() {
		base.Start();
		UtilLogger.Log(TAG, "Start()");
	}

	public override string GetRoomName() {
		return TAG;
	}

	public override string GetResults(ParseObject poRoom) {
		if(poRoom == null) {
			return "Results: \nYou have no friends.";
		}

		string key1 = "lawyer";
		int value1 = 0;
		if(poRoom.ContainsKey(key1)) {
			value1 = poRoom.Get<int>(key1);
		}

		string key2 = "writer";
		int value2 = 0;
		if(poRoom.ContainsKey(key2)) {
			value2 = poRoom.Get<int>(key2);
		}

		string key3 = "sports_physician";
		int value3 = 0;
		if(poRoom.ContainsKey(key3)) {
			value3 = poRoom.Get<int>(key3);
		}

		int total = value1 + value2 + value3;
		float percent1 = 100 * ((float) value1) / total;
		float percent2 = 100 * ((float) value2) / total;
		float percent3 = 100 * ((float) value3) / total;

		string messageChunk0 = "Results: \n";
		string messageChunk1 = percent1 + "% of players chose Lawyer.\n";
		string messageChunk2 = percent2 + "% of players chose Writer.\n";
		string messageChunk3 = percent3 + "% of players chose Sports Physician... because they are stupid.\n";
		return messageChunk0 + messageChunk1 + messageChunk2 + messageChunk3;
	}
}
