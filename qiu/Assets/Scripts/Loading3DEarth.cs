using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading3DEarth : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		SceneManager.LoadSceneAsync ("earth");	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
