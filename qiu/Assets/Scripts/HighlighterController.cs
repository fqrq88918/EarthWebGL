using UnityEngine;
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

        }
    }
