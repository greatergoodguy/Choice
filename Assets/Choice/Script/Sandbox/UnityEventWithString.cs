using UnityEngine;
using UnityEngine.Events;
using System.Collections;


public class UnityEventWithString : MonoBehaviour {

	[System.Serializable]
	public class OnValueChanged : UnityEvent<string> { };
	public OnValueChanged onValueChanged;

	public void Boom(string key) {

	}
}
