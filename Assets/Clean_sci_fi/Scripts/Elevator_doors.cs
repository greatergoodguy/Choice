using UnityEngine;
using System.Collections;

public class Elevator_doors : MonoBehaviour {

	//public ElevatorManager myManager = null;

	public AudioClip doorOpenSFX;
	public AudioClip doorCloseSFX;
	public AnimationClip doorOpenAnim;
	public AnimationClip doorCloseAnim;
	public ParticleSystem targetParticles;
	private bool doorOpen = false;
	public bool innerDoor = false;
	private bool withSFX = false;
	
	void Awake()
	{
		if (!gameObject.GetComponent<AudioSource>())
			gameObject.AddComponent<AudioSource>();

		if(this.animation)
		{
			//Debug.Log ("I have an animation component");
		}
		else
		{
			//Debug.Log ("I do not have an animation component");
			gameObject.AddComponent("Animation");
			if(doorOpenAnim)
			{
				gameObject.animation.AddClip(doorOpenAnim,doorOpenAnim.name);
			}
			if(doorCloseAnim)
			{
				gameObject.animation.AddClip(doorCloseAnim,doorCloseAnim.name);
			}
		}
	}

	void Start()
	{
		//I am an inner door (meaning, I'm attached to the moving
		//elevator or platform, not the floor/level
		if ((innerDoor == true) && (doorOpenAnim))
		{
			Door_Open();
		}
		//Make doors play their SFX from now on

		withSFX = true;
	}

	void animateDoor(AnimationClip openOrCloseAnimClip, AudioClip myAudioClip, bool openCloseBool)
	{
		string animString = openOrCloseAnimClip.name.ToString();
		
		animation.CrossFade (animString);
		doorOpen = openCloseBool;
		if ((myAudioClip != null) && (withSFX == true))
		{
			audio.clip = myAudioClip;
			audio.Play ();
		}
	}

	public void Door_Open()
	{
		//Debug.Log ("Running Door_Open()");
		if ((doorOpenAnim != null) && (doorOpen == false))
		{
			animateDoor(doorOpenAnim, doorOpenSFX, true);
			if (targetParticles != null) targetParticles.Play();
			if(gameObject.GetComponent<BoxCollider>())
				gameObject.GetComponent<BoxCollider>().enabled = false;
		}
	}

	void Door_Close()
	{
		if ((doorCloseAnim != null) && (doorOpen == true))
		{
			animateDoor(doorCloseAnim, doorCloseSFX, false);
			if (targetParticles != null) targetParticles.Play();
			if(gameObject.GetComponent<BoxCollider>())
				gameObject.GetComponent<BoxCollider>().enabled = true;
		}
	}

}
