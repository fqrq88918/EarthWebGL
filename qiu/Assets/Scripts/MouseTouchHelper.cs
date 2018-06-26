using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HighlightingSystem;
using UnityEngine.UI;
using DG.Tweening;

public class MouseTouchHelper : MonoBehaviour {

	private bool isPressWrong;

	private string currentPressName;

	public Transform textParent;

    private float clickTimer;

	// Use this for initialization
	void Start () {
		isPressWrong = false;
		currentPressName = "None";
	}
	
	// Update is called once per frame
	void Update () 
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition); 
		RaycastHit hit;  
		if (Physics.Raycast (ray, out hit)) 
		{
			//Debug.Log (hit.collider.name);
			if (hit.collider.name != "China") {
				//Debug.Log ("11111");
				isPressWrong = true;
			} 

			if (hit.collider.name != currentPressName)
			{
				if (textParent.Find (currentPressName) != null) 
				{
					textParent.Find (currentPressName).GetComponent<Text> ().DOFade (0f, 1f);
					textParent.Find (currentPressName).DOScale (0f, 1f);
				}
				currentPressName = hit.collider.name;
				if (textParent.Find (currentPressName) != null) 
				{
					textParent.Find (currentPressName).GetComponent<Text> ().DOFade (1f, 1f);
					textParent.Find (currentPressName).DOScale (1f, 1f);
				}
			}

		}

        if(!isPressWrong)
        {
            clickTimer++;
        }
	}

	void OnMouseDown()
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition); 
		RaycastHit hit;  
		if (Physics.Raycast (ray, out hit)) 
		{
			if (hit.collider.name == "China" ) 
			{
				isPressWrong = false;
                clickTimer = 0;
			}
		}
	}

	void OnMouseUp()
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition); 
		RaycastHit hit;  
		if (Physics.Raycast (ray, out hit))
		{
            if (hit.collider.name == "China" && !isPressWrong && clickTimer <= 20f) 
			{
				Application.OpenURL ("http://221.229.221.230:8090/china.html");
			}
		}

		isPressWrong = false;

	}
}
