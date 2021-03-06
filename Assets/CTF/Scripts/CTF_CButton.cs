using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CTF_CButton : MonoBehaviour {

	public Sprite baseButtonImg;
	public Sprite baseButtonImgPressed;
	public GameObject EndButtons;

	void Start(){
	}

	void Update()
	{
		if (!CTF_Russ.On) {
			Instantiate (EndButtons);
			Destroy (gameObject);
		}

		if (Input.touchCount > 0) 
		{
			Touch touch = Input.GetTouch (0);
			if(touch.phase == TouchPhase.Began)
			{
				Vector3 wp = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
				Vector2 touchPos = new Vector2 (wp.x, wp.y);
				if (GetComponent<Collider2D> () == Physics2D.OverlapPoint (touchPos)) 
				{
					gameObject.GetComponent<SpriteRenderer>().sprite = baseButtonImgPressed;
					CTF_Russ.Move = 1;
				}
			}
			if (touch.phase == TouchPhase.Ended) {
				gameObject.GetComponent<SpriteRenderer>().sprite = baseButtonImg;
			}
		}
	}
}
