using UnityEngine;
using System.Collections;

public class switchEmissive : MonoBehaviour {

	public int materialIndex = 0;
	public string textureName = "_Illum";
	public bool illumOn = false;
	public float howBright = 1.0f;
	private float offValue;
	
	public void lightItUp(bool illumOn)
	{
		offValue = renderer.materials[ materialIndex ].GetFloat("_EmissionLM");

		if(illumOn == true)
		{
			if( renderer.enabled )
			{
				renderer.materials[ materialIndex ].SetFloat("_EmissionLM", offValue + howBright);
			}
			else
			{
				renderer.materials[ materialIndex ].SetFloat("_EmissionLM", offValue);
			}
		}
	}
	
	void Update() 
	{
		//lightItUp(illumOn);
	}
}
