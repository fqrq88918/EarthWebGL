using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;

public class TestHerfUrl : MonoBehaviour {
	private Button urlButton;

	public Text _text;

	public string serverPath;

	public Material testMa;
	// Use this for initialization
	void Start () {
		urlButton = GetComponent<Button> ();
		urlButton.onClick.AddListener (delegate {
			Debug.Log("yayaya");
			Application.OpenURL ("http://www.baidu.com");
		});

		serverPath = Application.absoluteURL + "/../Config.xml";
		StartCoroutine(ReadPadCountXml (serverPath,delegate {
			
		}));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator ReadPadCountXml(string Url, System.Action CompleteHandler = null)
	{


		XmlDocument xmlDoc = new XmlDocument ();
		WWW www = new WWW (Url);
		yield return www;
		if (www.isDone)
		{
			//_text.text = www.text;
			xmlDoc.LoadXml (www.text);
			XmlNode chinaColorNode = xmlDoc.SelectSingleNode("infos/chinaColor");
			testMa.color *= float.Parse (chinaColorNode.Attributes ["value"].Value);
		}

		yield return new WaitForEndOfFrame ();
		if (CompleteHandler != null)
			CompleteHandler();

	}
}
