using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EliteGuidanceUI : MonoBehaviour {

	Transform tPanel;
	Text textMessage;
	
	public string Text
	{
		get { return textMessage.text; }
		set { textMessage.text = value; }
	}
	
	void Awake() {
		textMessage = transform.FindChild("Canvas/Panel/Message").GetComponent<Text>();
		tPanel = transform.FindChild("Canvas/Panel");
	}
	
	void Start() {
		Hide();
	}
	
	public void Show() {
		tPanel.gameObject.SetActive(true);
	}
	
	public void Hide() {
		tPanel.gameObject.SetActive(false);
	}
}
