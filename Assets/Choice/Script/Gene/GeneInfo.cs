﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class GeneInfo : MonoBehaviour {
	
	private readonly string TAG = typeof(GeneInfo).Name;
	
	public Vector3 offset;
	public string message = "";

	ActorInfo info;
	
	void Awake() {

		Object oClonerInfo = Resources.Load("Info", typeof(GameObject));

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
		if(Input.GetKeyDown(KeyCode.Z)) {

		}
	}

	void OnTriggerEnter(Collider other) {
		UtilLogger.Log(TAG, "OnTriggerEnter()");
		info.Show();
	}
	
	void OnTriggerExit(Collider other) {
		UtilLogger.Log(TAG, "OnTriggerExit()");
		info.Hide();
	}
	
}