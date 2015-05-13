using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EliteHelpUI : MonoBehaviour {

	Transform tCanvas;
	Text textMessage;
	
	public string Text
	{
		get { return textMessage.text; }
		set { textMessage.text = value; }
	}
	
	void Awake() {
		textMessage = transform.FindChild("Canvas/Panel/Message").GetComponent<Text>();
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
}
