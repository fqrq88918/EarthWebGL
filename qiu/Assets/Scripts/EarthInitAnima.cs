using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EarthInitAnima : MonoBehaviour {
    public GameObject text_1st;
    public GameObject text_2nd;
	public Text text_1st_UI;

    public CanvasGroup ui_2D;
    public Transform childCamera;

	// Use this for initialization
	void Start ()
    {
        text_1st.transform.DOScale(0.9f, 3f).SetDelay(4f).OnComplete(delegate {
            text_1st.transform.DOLocalRotate(new Vector3(0f,90f,0f), 1f).OnComplete(delegate {
                text_2nd.transform.localScale = Vector3.one * 0.8f;
                text_2nd.gameObject.SetActive(true);
                text_1st.gameObject.SetActive(false);
               

               
        });
            text_2nd.transform.DOLocalRotate(new Vector3(0f, 180f, 0f), 3f).OnComplete(delegate {

                text_2nd.transform.DOScale(0f, 0f).SetDelay(2f).OnComplete(delegate {
                    childCamera.parent = null;
                    text_2nd.SetActive(false);
//                    text_1st.transform.DOPause();
//                    text_1st.transform.localScale = Vector3.zero;
//                    text_1st.transform.localPosition = new Vector3(-5.49f, 3.45f, 0.06f);
//                    text_1st.transform.localEulerAngles = new Vector3(15.95f, 176.13f, -2.2f);
//                    text_1st.gameObject.SetActive(true);
                   // text_1st.transform.DOScale(Vector3.one * 0.5f, 1f).SetEase(Ease.OutBack);
					text_1st_UI.DOFade(1f,1f);
					text_1st_UI.transform.DOScale(0.5f,1f).SetEase(Ease.OutBack);
                    ui_2D.DOFade(1f, 2f);
                    CameraViewer.getInstance.isInitAnimaComplete = true;
                    CameraViewer.getInstance.StartRotate = false;
                });

            });
        });
	}
	
	// Update is called once per frame
	void Update () 
    {
       // Debug.Log(Camera.main.transform.localEulerAngles.y);
		if(Camera.main.transform.localEulerAngles.y > 355f && !CameraViewer.getInstance.isInitAnimaComplete)
        {
            CameraViewer.getInstance.StartRotate = true;

        }	
	}
}
