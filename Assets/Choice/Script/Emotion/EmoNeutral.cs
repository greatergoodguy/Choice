using UnityEngine;
using System.Collections;

public class EmoNeutral : MonoBehaviour {

	public static readonly string TAG = typeof(EmoNeutral).Name;

	void Start() {
		iTween.MoveBy(gameObject, iTween.Hash("y", 0.4, "easeType", "easeInOutSine", "loopType", "pingPong", "time", 1));
	}
}
