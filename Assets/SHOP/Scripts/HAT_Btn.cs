﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HAT_Btn : MonoBehaviour {

	public Sprite baseButtonImg;
	public Sprite baseButtonImgPressed;

	void Update()
	{
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
					PlayerPrefs.SetInt ("ShopType", 2);
					GameObject thatListObj = GameObject.Find ("EventSystem");
					ItemListGen thatListScript = thatListObj.GetComponent<ItemListGen> ();
					thatListScript.RelistItem ();
				}
			}
			if (touch.phase == TouchPhase.Ended) {
				gameObject.GetComponent<SpriteRenderer>().sprite = baseButtonImg;
			}
		}
	}
}
