using UnityEngine;
using System.Collections;

public class EliteHero : MonoBehaviour {

	MouseLook mouseLookHero;
	MouseLook mouseLookCamera;
	
	void Awake() {
		mouseLookHero = GetComponent<MouseLook>();
		mouseLookCamera = transform.FindChild("Main Camera").GetComponent<MouseLook>();
	}
	
	public void Freeze() {
		mouseLookHero.enabled = false;
		mouseLookCamera.enabled = false;
	}
	
	public void UnFreeze() {
		mouseLookHero.enabled = true;
		mouseLookCamera.enabled = true;
	}

	public void AttachSFX(EliteSFX eliteSFX) {
		eliteSFX.GetBundle().transform.parent = transform;
		eliteSFX.GetBundle().transform.localPosition = Vector3.zero;
	}
}
