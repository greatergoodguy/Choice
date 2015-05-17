using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class TriggerPodium : MonoBehaviour {
	
	private readonly string TAG = typeof(TriggerPodium).Name;
	
	public Vector3 offset;
	public string message = "";

	bool isTriggered = false;
	ActorInfo info;

	[Serializable]
	public class ButtonClickedEvent : UnityEvent {}
	// Event delegates triggered on click.
	[SerializeField]
	private ButtonClickedEvent m_OnClick = new ButtonClickedEvent();
	
	void Awake() {
		
		GameObject oClonerInfo = (GameObject) Resources.Load("Info", typeof(GameObject));
		
		GameObject goInfo = GameObject.Instantiate(oClonerInfo) as GameObject;
		goInfo.transform.parent = transform;
		goInfo.transform.localPosition = (new Vector3(0, 0, 0)) + offset;
		info = goInfo.GetComponent<ActorInfo>();
		info.Initiate(message);
		info.Hide();
	}
	
	void Start() {
		
	}
	
	void Update() {
		if(isTriggered && Input.GetKeyDown(KeyCode.Z)) {
			God.SFX.PodiumBeep.Play();
			m_OnClick.Invoke();
		}
	}
	
	void OnTriggerEnter(Collider other) {
		UtilLogger.Log(TAG, "OnTriggerEnter()");
		info.Show();
		isTriggered = true;
	}
	
	void OnTriggerExit(Collider other) {
		UtilLogger.Log(TAG, "OnTriggerExit()");
		info.Hide();
		isTriggered = false;
	}
	
}