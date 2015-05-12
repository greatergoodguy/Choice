using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class GeneInfo : MonoBehaviour {
	
	private readonly string TAG = "GeneInfo";
	
	public Vector3 offset;
	
	public string message = "";
	
	void Awake() {
		
		Transform tInfo = transform.FindChild("Info");
//		if(tInfo == null || tInfo.GetComponent<ActorInfo>() == null) {
//			Object oClonerInfo = Resources.Load("Info", typeof(GameObject));
//			
//			GameObject goInfo = GameObject.Instantiate(oClonerInfo) as GameObject;
//			goInfo.transform.parent = transform;
//			goInfo.transform.localPosition = (new Vector3(0, 0, 0)) + offset;
//			info = goInfo.GetComponent<ActorInfo>();
//		}
//		else {
//			info = tInfo.GetComponent<ActorInfo>();
//		}
//		
//		info.Initiate(name, initialCurrentAge, initialMaxAge);
//		info.Hide();
	}
	
	void Start() {
		
	}
	
	void OnTriggerEnter(Collider other) {
		UtilLogger.Log(TAG, "OnTriggerEnter()");
//		info.Show();
	}
	
	void OnTriggerExit(Collider other) {
		UtilLogger.Log(TAG, "OnTriggerExit()");
//		info.Hide();
	}
	
}