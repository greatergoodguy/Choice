using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EliteDebugUI : MonoBehaviour {

	Transform tCanvas;
	Text textAudioEnabled;

	public bool IsVisible {
		get {
			return tCanvas.gameObject.activeSelf;
		}
	}
	
	void Awake() {
		textAudioEnabled = transform.FindChild("Canvas/Panel/Audio Enabled Text").GetComponent<Text>();
		tCanvas = transform.FindChild("Canvas");
	}
	
	void Start() {
		Hide();
	}
	
	public void Show() {
		tCanvas.gameObject.SetActive(true);
	}
	
	public void Hide() {
		tCanvas.gameObject.SetActive(false);
	}

	public void SetAudioEnabled(bool isAudioEnabled) {
		if(isAudioEnabled) {
			textAudioEnabled.text = "Audio Enabled: " + true;
		}
		else {
			textAudioEnabled.text = "Audio Enabled: " + false;
		}
	}
}
