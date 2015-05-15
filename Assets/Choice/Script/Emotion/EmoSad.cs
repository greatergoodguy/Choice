using UnityEngine;
using System.Collections;

public class EmoSad : MonoBehaviour {

	public static readonly string TAG = typeof(EmoSad).Name;

	void Start() {
		iTween.MoveBy(gameObject, iTween.Hash("y", 0.4, "easeType", "easeInOutSine", "loopType", "pingPong", "time", 2));
	}
}
