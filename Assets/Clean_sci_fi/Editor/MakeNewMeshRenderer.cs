using UnityEngine;
using UnityEditor;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

//PROBLEM:
//This script is provided because I found that I didn't want to soak up too much texture space with static props
//needing a lot of UV space in lightmaps. My work-around is to not have the props (currently the barrel and crate)
//generate a second set of UVs for lightmaps. But I DO flag them as static and throwing shadows so that their
//shadows are baked into the level lighmaps. However I have found that the mesh renderer component for the props
//after a lightmap bake become corrupt in some way and are over-bright, ignoring normal maps etc.

//SOlUTION:
//My solution is to delete the corrupt mesh renderer component in the inspector and add a fresh one, then re-apply
//the original material. This script does that automatically (saving quite a lot of clicking if you have many props)
//when selected from the editor 'tools' menu.

//METHOD:
//1.	Make sure all your props are on a layer called 'Props'. If you don't have one just make one. I include this
//		as a failsafe. since you don't want to do this to anything except props.
//2.	Select all your props that need a fresh Mesh Renderer component.
//3.	Choose Tools/Renew Mesh Renderer from the editor 'Tools' menu.
//4.	That's it! Check to see it worked.

public class MakeNewMeshRenderer : ScriptableObject
{
	//private MeshRenderer oldMeshRenderer;
	private GameObject myProp;
	//private MeshRenderer newRenderer = null;

	[MenuItem ("Tools/Renew Mesh Renderer")]
	static void MenuRenewMeshRenderer()
	{
		Transform[] transforms = Selection.GetTransforms(SelectionMode.TopLevel | SelectionMode.OnlyUserModifiable);

		foreach(Transform myTransform in transforms)
		{
			var selObject = myTransform.gameObject;
			var selObjRenderer = selObject.GetComponent<MeshRenderer>();
			if (selObjRenderer != null)
			{
				var selObjMaterial = selObjRenderer.sharedMaterials[0];
				//Debug.Log ("Prop material = " + selObjMaterial);
				//Debug.Log ("Layer = " + selObject.layer);
				//Debug.Log ("Layer name = " + LayerMask.LayerToName(selObject.layer));
				if(LayerMask.LayerToName(selObject.layer)== "Props")
				{
					//Debug.Log ("Got a Prop!!");
					//Lets strip the old mesh renderer, add a new one and re-assign the old material
					Undo.DestroyObjectImmediate (selObjRenderer);
					var newObjRenderer = selObject.AddComponent<MeshRenderer>();
					newObjRenderer.sharedMaterial = selObjMaterial;
					newObjRenderer.castShadows = false;
					newObjRenderer.receiveShadows = false;
				}
			}
			else
			{
				Debug.Log ("Object has no mesh renderer!");
			}
		}
	}
}
