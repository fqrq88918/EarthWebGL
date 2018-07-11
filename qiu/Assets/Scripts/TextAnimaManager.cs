using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TextAnimaManager : MonoBehaviour {
    public Text chinaText;

    public Text englishText;
	// Use this for initialization
	void Start ()
    {
        DoAnima();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void DoAnima()
    {
        chinaText.GetComponent<RectTransform>().DOAnchorPos3D(new Vector3(0f,-20f,0f), 4f);
        chinaText.GetComponent<RectTransform>().DOScale(Vector3.one * 0.1f,4f).OnComplete(
            delegate
            {
            englishText.GetComponent<RectTransform>().DOScale(Vector3.one, 2f).SetEase(Ease.OutBack);
                englishText.DOFade(1f, 2f);
            }
        );
       // DOTween.To(() => chinaText.fontSize, x => chinaText.fontSize = x, 18, 3f)

    }
}
