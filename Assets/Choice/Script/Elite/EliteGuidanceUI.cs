using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EliteGuidanceUI : MonoBehaviour {

	Transform tCanvas;
	Text textMessage;
	Text textExtra;
	
	public string Message
	{
		get { return textMessage.text; }
		set { textMessage.text = value; }
	}

	public string Extra
	{
		get { return textExtra.text; }
		set { textExtra.text = value; }
	}


	void Awake() {
		tCanvas = transform.FindChild("Canvas");
		textMessage = transform.FindChild("Canvas/Panel/Message").GetComponent<Text>();
		textExtra = transform.FindChild("Canvas/Panel/Extra").GetComponent<Text>();

		Message = "";
		Extra = "";
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
