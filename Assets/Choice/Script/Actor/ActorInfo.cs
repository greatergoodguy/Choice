using UnityEngine;
using System.Collections;

public class ActorInfo : MonoBehaviour {

	private Transform tCanvas;
	private tk2dTextMesh tmText;


	void Awake() {
		tCanvas = transform.Find("Canvas");
		tmText = transform.Find("Canvas/Text").GetComponent<tk2dTextMesh>();
	}

	void Start() {
	
	}
	
	void Update() {
	
	}

	public void Initiate(string message) {
		tmText.text = message;
	}

	public void Show() {
		tCanvas.gameObject.SetActive(true);
	}
	
	public void Hide() {
		tCanvas.gameObject.SetActive(false);
	}
}
