using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour {
	#region PUBLIC_VARIABLES
	public	Renderer objectRendere;
	public delegate void  MyDelegate();
	MyDelegate myDelegate;
	#endregion
	#region UNITY_CALLBACKS
	private void Update(){
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			if(myDelegate!=null)
				myDelegate();
			myDelegate += ChangePosition;
			myDelegate += ChangeColor;
			myDelegate = ChangeRotation;
		}
	}
	private void OnDisable(){
		myDelegate -= ChangePosition;
		myDelegate -= ChangeColor;
	}
	#endregion
	#region PRIVATE_FUNCTION
	void ChangePosition(){
		StartCoroutine (Movement (2f));
	}
	void ChangeColor(){
		objectRendere.material.color = Color.yellow;
	}
	void ChangeRotation(){
		transform.Rotate (0, 90, 0);
	}
	#endregion
	#region CO_ROUTINE
	IEnumerator Movement(float time){
		float i = 0;
		float rate = 1 / time;
		while(i<1){
			i += Time.deltaTime * rate;
			transform.position = Vector3.Lerp (Vector3.zero,Vector3.up*4,i);
			yield return null;
		}
	}
	#endregion
}
