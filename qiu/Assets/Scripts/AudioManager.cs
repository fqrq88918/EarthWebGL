using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour {
    public Button audioPlayButtion;

    public Button audioPauseButtion;

    public AudioSource audioSource;

	// Use this for initialization
	void Start () 
    {
        audioPlayButtion.onClick.AddListener(delegate
        {
            //Debug.Log("hahaha");
            AudioPause();
        });

        audioPauseButtion.onClick.AddListener(delegate
        {

            AudioPlay();
        });
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void AudioPlay()
    {
        audioPlayButtion.gameObject.SetActive(true);
        audioPauseButtion.gameObject.SetActive(false);
        audioSource.Play();
    }

    void AudioPause()
    {
        audioPlayButtion.gameObject.SetActive(false);
        audioPauseButtion.gameObject.SetActive(true);
        audioSource.Pause();
    }
}
