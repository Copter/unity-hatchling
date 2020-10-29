using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rub_2 : MonoBehaviour {

	public Vector2 startPos;
	public Vector2 direction;
	public bool swipeNotTap = false;
	public bool inRange = false;
	public GameObject CoinDrop;

	void Update()
	{
		GameObject objWithAnim = GameObject.Find("Russ");
		Anim scrAnim = objWithAnim.GetComponent<Anim>();
		scrAnim.poked = false;
		// Track a single touch as a direction control.
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);
			scrAnim.rubbed = false;

			// Handle finger movements based on touch phase.
			switch (touch.phase)
			{
			// Record initial touch position.
			case TouchPhase.Began:
				startPos = touch.position;
				Vector3 wp = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
				Vector2 touchPos = new Vector2 (wp.x, wp.y);
					if (GetComponent<Collider2D> () == Physics2D.OverlapPoint (touchPos)) 
					{
						inRange = true;
					}
				break;

				// Determine direction by comparing the current touch position with the initial one.
			case TouchPhase.Moved:
				direction = touch.position - startPos;
				float deltaX = Mathf.Abs (touch.position.x - startPos.x);
				float deltaY = Mathf.Abs (touch.position.y - startPos.y);
				float swipeRadius = Mathf.Sqrt ((deltaX * deltaX) + (deltaY * deltaY));
				// Radius for the swipe to be registered
				if (swipeRadius > 10) {
					Vector3 wp2 = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
					Vector2 touchPos2 = new Vector2 (wp2.x, wp2.y);
					if (GetComponent<Collider2D> () == Physics2D.OverlapPoint (touchPos2)) {
						//print ("Rub!");
						GameObject objWithStats = GameObject.Find ("Russ");
						Stats scrStats = objWithStats.GetComponent<Stats> ();
						scrStats.joy += 0.1f; 

						scrAnim.rubbed = true;

						//Temporary Coin Source
						if (Random.value <= 0.01) {
							scrStats.coin += 1;
							CoinDropper ();
						}
					}
					swipeNotTap = true;
				}
				break;

				// Report that a direction has been chosen when the finger is lifted.
			case TouchPhase.Ended:
				
				scrAnim.rubbed = false;

				if (swipeNotTap == false) {
					if (inRange) {
						//print ("Rub!");
						GameObject objWithStats = GameObject.Find ("Russ");
						Stats scrStats = objWithStats.GetComponent<Stats> ();
						scrStats.joy += 0.5f; 

						scrAnim.poked = true;

						//Temporary Coin Source
						if (Random.value <= 0.05) {
							scrStats.coin += 1;
							CoinDropper ();
						}
					}
				}
				swipeNotTap = false;
				inRange = false;

				//GameObject objWithAnim = GameObject.Find("Russ");
				//Anim scrAnim = objWithAnim.GetComponent<Anim>();

				break;
			}
		}
	}

	void CoinDropper(){
		GameObject theCoin = Instantiate (CoinDrop);
		theCoin.transform.position = gameObject.transform.position;
		theCoin.GetComponent<Rigidbody2D>().AddForce(transform.up * Random.Range(200, 501));
		theCoin.GetComponent<Rigidbody2D>().AddForce(transform.right * Random.Range(-200, 201));

		if (theCoin.transform.position.y < -10) {
			Destroy (theCoin);
		}
	}
}