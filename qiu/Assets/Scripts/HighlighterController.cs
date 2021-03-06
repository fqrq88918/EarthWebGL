﻿using UnityEngine;
using HighlightingSystem;
using DG.Tweening;
using UnityEngine.UI;


    public class HighlighterController : MonoBehaviour
    {
        protected Highlighter highlighter;
        private bool isMouseOver;
		
		protected void Awake()
		{
			highlighter = GetComponent<Highlighter>();
			if (highlighter == null)
			{
				highlighter = gameObject.AddComponent<Highlighter>();
			}
			
		}
		

//        protected void OnEnable()
//        {
//			gameObject.GetComponent<Highlighter> ().enabled = true;
//        }
//
//		protected void OnDisable()
//		{
//			gameObject.GetComponent<Highlighter> ().enabled = false;
//		}

        private void OnMouseOver()
        {
			
            highlighter.On();
        if(transform.childCount > 0)
        {
            for (int i = 0; i < transform.childCount;i++)
            {
                transform.GetChild(i).GetComponent<Highlighter>().On();
            }
        }
		else if(transform.parent.name != "Other" && transform.parent.childCount < 2)
        {
            transform.parent.GetComponent<Highlighter>().On();
        }
		else if(transform.parent.name != "Other" && transform.parent.childCount > 1)
		{
			for (int i = 0; i < transform.parent.childCount;i++)
			{
				transform.parent.GetChild(i).GetComponent<Highlighter>().On();
			}
			transform.parent.GetComponent<Highlighter>().On();
		}
        }
    }
