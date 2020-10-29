using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Food : MonoBehaviour {

	public Image baseButtonImg;
	public Sprite baseButtonImgPressed;
	public Sprite invisprite;
	public Sprite barDefault;
	public Sprite baseDefault;

	void Start(){
		baseDefault = gameObject.GetComponent<SpriteRenderer>().sprite;
		barDefault = baseButtonImg.sprite;
	}

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
					GameObject objWithStats = GameObject.Find("Russ");
					Stats scrStats = objWithStats.GetComponent<Stats>();
					if (scrStats.coin >= 10 && scrStats.hunger < 95) {
						scrStats.hunger += 30;
						scrStats.coin -= 10;

						GameObject objWithAnim = GameObject.Find("Russ");
						Anim scrAnim = objWithAnim.GetComponent<Anim>();
						scrAnim.eating = true;
					}

					gameObject.GetComponent<SpriteRenderer>().sprite = baseButtonImgPressed;
					baseButtonImg.sprite = invisprite;
				}
			}
			if (touch.phase == TouchPhase.Ended) {
				gameObject.GetComponent<SpriteRenderer>().sprite = baseDefault;
				baseButtonImg.sprite = barDefault;
			}
		}
	}
}
