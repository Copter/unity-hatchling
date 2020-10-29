using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch (0);
			if (touch.phase == TouchPhase.Began) {
				Vector3 wp = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
				Vector2 touchPos = new Vector2 (wp.x, wp.y);
				if (GetComponent<Collider2D> () == Physics2D.OverlapPoint (touchPos)) {
					//print (System.DateTime.Now);
					print (SecondStamp());
				}
			}
		}
	}

	void OnApplicationQuit()
	{
		//Debug.Log("Application closed at " + SecondStamp() + " local seconds.");
	}

	long SecondStamp () {
		long ticksToSeconds = Convert.ToInt64(Mathf.Pow(10, 7));
		long localSeconds = System.DateTime.Now.Ticks / ticksToSeconds;
		//print (localSeconds);
		return (localSeconds);
	}
}
