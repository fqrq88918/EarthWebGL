using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLoadAllConfig : MonoBehaviour {
	public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;
    public Button button6;
    public Button button7;

    private string serverPath1;
    private string serverPath2;
    private string serverPath3;
    private string serverPath4;
    private string serverPath5;
    private string serverPath6;
    private string serverPath7;
   
	// Use this for initialization
	void Start () {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            
            serverPath1 = Application.absoluteURL + "/../高血压人数.xml";
            serverPath2 = Application.absoluteURL + "/../高血脂人数.xml";
            serverPath3 = Application.absoluteURL + "/../糖尿病人数.xml";
            serverPath4 = Application.absoluteURL + "/../高压.xml";
            serverPath5 = Application.absoluteURL + "/../低压.xml";
            serverPath6 = Application.absoluteURL + "/../血糖.xml";
            serverPath7 = Application.absoluteURL + "/../血氧.xml";
           
        }
        else
        {
            serverPath1 = "file://" + Application.dataPath + "/高血压人数.xml";
            serverPath2 = "file://" + Application.dataPath + "/高血脂人数.xml";
            serverPath3 = "file://" + Application.dataPath + "/糖尿病人数.xml";
            serverPath4 = "file://" + Application.dataPath + "/高压.xml";
            serverPath5 = "file://" + Application.dataPath + "/低压.xml";
            serverPath6 = "file://" + Application.dataPath + "/血糖.xml";
            serverPath7 = "file://" + Application.dataPath + "/血氧.xml";

        }
		
		
		button1.onClick.AddListener(delegate {
            StartCoroutine(ConfigEarth.getInstance.ReadPadCountXml(serverPath1));
		});
		button2.onClick.AddListener(delegate {
            StartCoroutine(ConfigEarth.getInstance.ReadPadCountXml(serverPath2));
		});
        button3.onClick.AddListener(delegate {
            StartCoroutine(ConfigEarth.getInstance.ReadPadCountXml(serverPath3));
        });
        button4.onClick.AddListener(delegate {
            StartCoroutine(ConfigEarth.getInstance.ReadPadCountXml(serverPath4));
        });
        button5.onClick.AddListener(delegate {
            StartCoroutine(ConfigEarth.getInstance.ReadPadCountXml(serverPath5));
        });
        button6.onClick.AddListener(delegate {
            StartCoroutine(ConfigEarth.getInstance.ReadPadCountXml(serverPath6));
        });
        button7.onClick.AddListener(delegate {
            StartCoroutine(ConfigEarth.getInstance.ReadPadCountXml(serverPath7));
        });

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
