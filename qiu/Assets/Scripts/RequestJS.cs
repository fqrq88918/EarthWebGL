using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestJS : MonoBehaviour
{
    public GameObject[] gameObj;
    // Use this for initialization
    void Start()
    {
        Application.ExternalCall("changeProgressSpeed");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowObj(string _str)
    {
        if (_str == "responce")
            foreach (GameObject _g in gameObj)
            {
                _g.SetActive(true);
            }
    }

    public void CallConfig(string configPath)
    {
        string serverPath = Application.absoluteURL + "/../" + configPath;
        StartCoroutine(ConfigEarth.getInstance.ReadXml(serverPath));
    }
}
