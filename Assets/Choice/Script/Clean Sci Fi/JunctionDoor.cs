using UnityEngine;
using System.Collections;

public class JunctionDoor : MonoBehaviour {
	public Object targetDoor;
	public ParticleSystem targetParticles;
	public AudioClip doorOpenClip;
	public AudioClip doorCloseClip;
	
	void DoDoorTrigger (bool openOrClose)
	{
		Object currentTarget = targetDoor != null ? targetDoor : gameObject;
		Behaviour targetBehaviour = currentTarget as Behaviour;
		GameObject targetGameObject = currentTarget as GameObject;
		
		
		if (targetBehaviour != null)
			
			targetGameObject = targetBehaviour.gameObject;
		
		
		//door opening = true, closing = false
		if (openOrClose == true)
		{
			Debug.Log ("Door opening!");
			//targetGameObject.animation.Play ("Room_door_open");
			targetGameObject.animation.CrossFade ("Room_door_open");
			audio.clip = doorOpenClip;
			audio.Play ();
			if (targetParticles != null) targetParticles.Play();
		}
		else
		{
			//targetGameObject.animation.Play ("Room_door_close");
			targetGameObject.animation.CrossFade ("Room_door_close");
			audio.clip = doorCloseClip;
			audio.Play ();
			if (targetParticles != null) targetParticles.Play();
		}
		
	}

	public void Open() {
		DoDoorTrigger (true);
	}

	public void Close() {
		DoDoorTrigger (false);
	}
	
//	void OnTriggerEnter (Collider other) {
//		DoDoorTrigger (true);
//	}
//	
//	void OnTriggerExit (Collider other) {
//		DoDoorTrigger (false);
//	}
}
