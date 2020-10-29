using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldButton : MonoBehaviour {

	public Sprite baseButtonImg;
	public Sprite baseButtonImgPressed;

	void Start(){
	}

	void Update()
	{
		if (Input.touchCount > 0) 
		{
			float holdTime = 0;
			holdTime += Input.GetTouch(0).deltaTime;
			Touch touch = Input.GetTouch (0);
			//if(touch.phase == TouchPhase.Began)
			if(holdTime >= 0.5f)
			{
				Vector3 wp = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
				Vector2 touchPos = new Vector2 (wp.x, wp.y);
				if (GetComponent<Collider2D> () == Physics2D.OverlapPoint (touchPos)) 
				{
					gameObject.GetComponent<SpriteRenderer>().sprite = baseButtonImgPressed;
				}
			}
			if (touch.phase == TouchPhase.Ended) {
				gameObject.GetComponent<SpriteRenderer>().sprite = baseButtonImg;
				holdTime = 0;
			}
		}
	}
}
