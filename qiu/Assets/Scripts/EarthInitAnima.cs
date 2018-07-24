using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EarthInitAnima : MonoBehaviour {
    public Text text_1st;
    public Text text_1st_Screen;
    public Text text_2nd_Screen;

	// Use this for initialization
	void Start ()
    {
        text_1st.transform.DOScale(1f, 3f).SetDelay(4f).OnComplete(delegate {
                text_1st.transform.DOLocalRotate(Vector3.zero, 2f).OnComplete(delegate {
                text_1st.gameObject.SetActive(false);
                text_1st_Screen.gameObject.SetActive(true);
                text_1st_Screen.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-543f, -53f),1f).OnComplete(delegate {
                    text_2nd_Screen.DOFade(1f, 1f);
                    text_2nd_Screen.transform.DOScale(0.5f, 1f);

                });
        });

        });
	}
	
	// Update is called once per frame
	void Update () 
    {
       // Debug.Log(Camera.main.transform.localEulerAngles.y);
        if(Camera.main.transform.localEulerAngles.y > 355f)
        {
            CameraViewer.getInstance.StartRotate = true;

        }	
	}
}
