﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System.IO;

public class ConfigEarth : MonoBehaviour {
	private Button urlButton;

	//public Text _text;

	public string serverPath;

	public Material ChinaMa;
    public Material AfghanistanMa;
    public Material UnitedStatesofAmeriaMa;
    public Material CanadaMa;
    public Material BrazilMa;
    public Material RussiaMa;
    public Material AntarticaMa;
    public Material AustraliaMa;
    public Material IndiaMa;
    public Material SaudiArabiaMa;
    public Material ArgentinaMa;
    public Material IranMa;
    public Material SudanMa;
    public Material IndonesiaMa;
    public Material LybiaMa;
    public Material AlgeriaMa;
	// Use this for initialization
	void Start () {
//		urlButton = GetComponent<Button> ();
//		urlButton.onClick.AddListener (delegate {
//			Debug.Log("yayaya");
//			Application.OpenURL ("http://www.baidu.com");
//		});

		serverPath = Application.absoluteURL + "/../Config.xml";
        //serverPath = "file://" + Application.dataPath + "/Config.xml";
        Debug.Log(serverPath);
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
            Debug.Log(www.text);
			//_text.text = www.text;
			xmlDoc.LoadXml (www.text);
			XmlNode chinaColorNode = xmlDoc.SelectSingleNode("infos/ChinaColor");
            ChinaMa.color = HexToColor(chinaColorNode.Attributes ["value"].Value);

            XmlNode AfghanistanColorNode = xmlDoc.SelectSingleNode("infos/AfghanistanColor");
            AfghanistanMa.color = HexToColor(AfghanistanColorNode.Attributes["value"].Value);

            XmlNode UnitedStatesofAmeriaColorNode = xmlDoc.SelectSingleNode("infos/UnitedStatesofAmeriaColor");
            UnitedStatesofAmeriaMa.color = HexToColor(UnitedStatesofAmeriaColorNode.Attributes["value"].Value);

            XmlNode CanadaColorNode = xmlDoc.SelectSingleNode("infos/CanadaColor");
            CanadaMa.color = HexToColor(CanadaColorNode.Attributes["value"].Value);

            XmlNode BrazilColorNode = xmlDoc.SelectSingleNode("infos/BrazilColor");
            BrazilMa.color = HexToColor(BrazilColorNode.Attributes["value"].Value);

            XmlNode RussiaColorNode = xmlDoc.SelectSingleNode("infos/RussiaColor");
            RussiaMa.color = HexToColor(RussiaColorNode.Attributes["value"].Value);

            XmlNode AntarticaColorNode = xmlDoc.SelectSingleNode("infos/AntarticaColor");
            AntarticaMa.color = HexToColor(AntarticaColorNode.Attributes["value"].Value);

            XmlNode AustraliaColorNode = xmlDoc.SelectSingleNode("infos/AustraliaColor");
            AustraliaMa.color = HexToColor(AustraliaColorNode.Attributes["value"].Value);

            XmlNode IndiaColorNode = xmlDoc.SelectSingleNode("infos/IndiaColor");
            IndiaMa.color = HexToColor(IndiaColorNode.Attributes["value"].Value);

            XmlNode SaudiArabiaColorNode = xmlDoc.SelectSingleNode("infos/SaudiArabiaColor");
            SaudiArabiaMa.color = HexToColor(SaudiArabiaColorNode.Attributes["value"].Value);

            XmlNode ArgentinaColorNode = xmlDoc.SelectSingleNode("infos/ArgentinaColor");
            ArgentinaMa.color = HexToColor(ArgentinaColorNode.Attributes["value"].Value);

            XmlNode IranColorNode = xmlDoc.SelectSingleNode("infos/IranColor");
            IranMa.color = HexToColor(IranColorNode.Attributes["value"].Value);

            XmlNode SudanColorNode = xmlDoc.SelectSingleNode("infos/SudanColor");
            SudanMa.color = HexToColor(SudanColorNode.Attributes["value"].Value);

            XmlNode IndonesiaColorNode = xmlDoc.SelectSingleNode("infos/IndonesiaColor");
            IndonesiaMa.color = HexToColor(IndonesiaColorNode.Attributes["value"].Value);

            XmlNode LybiaColorNode = xmlDoc.SelectSingleNode("infos/LybiaColor");
            LybiaMa.color = HexToColor(LybiaColorNode.Attributes["value"].Value);

            XmlNode AlgeriaColorNode = xmlDoc.SelectSingleNode("infos/AlgeriaColor");
            AlgeriaMa.color = HexToColor(AlgeriaColorNode.Attributes["value"].Value);
		}

		yield return new WaitForEndOfFrame ();
		if (CompleteHandler != null)
			CompleteHandler();

	}

    public Color HexToColor(string hex)
    {
        byte br = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte bg = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte bb = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
       // byte cc = byte.Parse(hex.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
        float r = br / 255f;
        float g = bg / 255f;
        float b = bb / 255f;
       // float a = cc / 255f;
       // Debug.Log(new Color(r, g, b, a));
        return new Color(r, g, b, 1);
    }

    public static string ColorToHex(Color color)
    {
        int r = Mathf.RoundToInt(color.r * 255.0f);
        int g = Mathf.RoundToInt(color.g * 255.0f);
        int b = Mathf.RoundToInt(color.b * 255.0f);
        int a = Mathf.RoundToInt(color.a * 255.0f);
        string hex = string.Format("{0:X2}{1:X2}{2:X2}{3:X2}", r, g, b, a);
        Debug.Log(hex);
        return hex;
    }

  

   
}
