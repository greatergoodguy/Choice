using UnityEngine;
using System.Collections;

public class EliteSFX : MonoBehaviour {

	Transform tBundle;

	void Awake() {
		tBundle = transform.FindChild("Bundle");
	}

	public Transform GetBundle() {
		return tBundle;
	}

	private AudioSource podiumBeep;
	public AudioSource PodiumBeep {
		get {
			if(podiumBeep == null) {
				podiumBeep = tBundle.FindChild("Podium Beep").GetComponent<AudioSource>();
			}
			return podiumBeep;
		}
	}

	private AudioSource invalid;
	public AudioSource Invalid {
		get {
			if(invalid == null) {
				invalid = tBundle.FindChild("Invalid").GetComponent<AudioSource>();
			}
			return invalid;
		}
	}
}
