using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour {

	public Vector2 startPos;
	public Vector2 direction;
	//public bool directionChosen;
	void Update()
	{
		// Track a single touch as a direction control.
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);

			// Handle finger movements based on touch phase.
			switch (touch.phase)
			{
			// Record initial touch position.
			case TouchPhase.Began:
				startPos = touch.position;
				//directionChosen = false;
				break;

				// Determine direction by comparing the current touch position with the initial one.
			case TouchPhase.Moved:
				direction = touch.position - startPos;
				float deltaX = Mathf.Abs (touch.position.x - startPos.x);
				float deltaY = Mathf.Abs (touch.position.y - startPos.y);
				float swipeRadius = Mathf.Sqrt ((deltaX * deltaX) + (deltaY * deltaY));
				// Radius for the swipe to be registered
				if(swipeRadius > 5){
					print ("Swipe!");
				}
				break;

				// Report that a direction has been chosen when the finger is lifted.
			case TouchPhase.Ended:
				//directionChosen = true;
				break;
			}
		}
	}
}
