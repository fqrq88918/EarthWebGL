using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTouchHelper : MonoBehaviour {

	private bool isPressDown;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown()
	{
		isPressDown = true;

	}
		

	void OnMouseUp()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.acceleration,ouse) 
		RaycastHit hit;  
		if(Physics.Raycast(ray, out hit, Mathf.Infinity))  

		if (isPressDown)
			Application.OpenURL ("http://221.229.221.230:8090/china.html");
		else
			isPressDown = false;
	}
}
