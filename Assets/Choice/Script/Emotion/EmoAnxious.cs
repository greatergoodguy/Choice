using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EmoAnxious : MonoBehaviour {

	public static readonly string TAG = typeof(EmoAnxious).Name;

	List<Hashtable> hashesTranslate = new List<Hashtable>();
	int hashIndexTranslate = 0;

	List<Hashtable> hashesRotate = new List<Hashtable>();
	int hashIndexRotate = 0;

	void Awake() {
		float durationBob = 0.08f;
		float durationHold = 0.8f;
		float durationRotate = 0.4f;

		hashesTranslate.Add(iTween.Hash("y", 0.1, "easeType", "easeInOutSine", "oncomplete", "OnCompleteTranslate", "time", durationBob));
		hashesTranslate.Add(iTween.Hash("y", -0.1, "easeType", "easeInOutSine", "oncomplete", "OnCompleteTranslate", "time", durationBob));
		hashesTranslate.Add(iTween.Hash("y", 0.1, "easeType", "easeInOutSine", "oncomplete", "OnCompleteTranslate", "time", durationBob));
		hashesTranslate.Add(iTween.Hash("y", -0.1, "easeType", "easeInOutSine", "oncomplete", "OnCompleteTranslate", "time", durationBob));
		hashesTranslate.Add(iTween.Hash("y", 0.1, "easeType", "easeInOutSine", "oncomplete", "OnCompleteTranslate", "time", durationBob));
		hashesTranslate.Add(iTween.Hash("y", -0.1, "easeType", "easeInOutSine", "oncomplete", "OnCompleteTranslate", "time", durationBob));
		hashesTranslate.Add(iTween.Hash("y", 0.1, "easeType", "easeInOutSine", "oncomplete", "OnCompleteTranslate", "time", durationBob));
		hashesTranslate.Add(iTween.Hash("y", -0.1, "easeType", "easeInOutSine", "oncomplete", "OnCompleteTranslate", "time", durationBob));

		hashesRotate.Add(iTween.Hash("y", 0.15, "easeType", "easeInOutSine",  "oncomplete", "OnCompleteRotate", "time", durationRotate));
		hashesRotate.Add(iTween.Hash("y", 0, "easeType", "easeInOutSine",  "oncomplete", "OnCompleteRotate", "time", durationHold));
		hashesRotate.Add(iTween.Hash("y", -0.15, "easeType", "easeInOutSine", "oncomplete", "OnCompleteRotate", "time", durationRotate));
		hashesRotate.Add(iTween.Hash("y", 0, "easeType", "easeInOutSine",  "oncomplete", "OnCompleteRotate", "time", durationHold));
		hashesRotate.Add(iTween.Hash("y", -0.15, "easeType", "easeInOutSine", "oncomplete", "OnCompleteRotate", "time", durationRotate));
		hashesRotate.Add(iTween.Hash("y", 0, "easeType", "easeInOutSine",  "oncomplete", "OnCompleteRotate", "time", durationHold));
		hashesRotate.Add(iTween.Hash("y", 0.15, "easeType", "easeInOutSine",  "oncomplete", "OnCompleteRotate", "time", durationRotate));
		hashesRotate.Add(iTween.Hash("y", 0, "easeType", "easeInOutSine",  "oncomplete", "OnCompleteRotate", "time", durationHold));
	}

	void Start() {
		if(hashIndexTranslate < hashesTranslate.Count) {
			iTween.MoveBy(gameObject, hashesTranslate[hashIndexTranslate]);
		}

		if(hashIndexRotate < hashesRotate.Count) {
			iTween.RotateBy(gameObject, hashesRotate[hashIndexRotate]);
		}
	}

	void OnCompleteTranslate() {
		hashIndexTranslate++;
		if(hashIndexTranslate >= hashesTranslate.Count) {
			hashIndexTranslate = 0;
		}

		iTween.MoveBy(gameObject, hashesTranslate[hashIndexTranslate]);
	}

	void OnCompleteRotate() {
		hashIndexRotate++;
		if(hashIndexRotate >= hashesRotate.Count) {
			hashIndexRotate = 0;
		}
		
		iTween.RotateBy(gameObject, hashesRotate[hashIndexRotate]);
	}
}
