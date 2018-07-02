using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLoadAllConfig : MonoBehaviour {
	public Button button1;

	public Button button2;
	// Use this for initialization
	void Start () {
		//string serverPath1 = "file://" + Application.dataPath + "/Config.xml";
		//string serverPath2 = "file://" + Application.dataPath + "/Config2.xml";
		string serverPath1 = Application.absoluteURL + "/../Config.xml";
		string serverPath2 = Application.absoluteURL + "/../Config2.xml";
		button1.onClick.AddListener(delegate {
			StartCoroutine(ConfigEarth.getInstance.ReadXml(serverPath1));
		});
		button2.onClick.AddListener(delegate {
			StartCoroutine(ConfigEarth.getInstance.ReadXml(serverPath2));
		});
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
