using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GAME_RetryBtn : MonoBehaviour {

	public Sprite baseButtonImgPressed;

	void Start(){
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
					gameObject.GetComponent<SpriteRenderer>().sprite = baseButtonImgPressed;
					SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
				}
			}
		}
	}
}