using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamepad : MonoBehaviour {

	public GameObject CoinDrop;

	// Use this for initialization
	void Start () {
		//int gameRewardDrops = PlayerPrefs.GetInt ("GameReward", 0);
		for (int i = 0; i < Mathf.Min(20, PlayerPrefs.GetInt ("GameReward", 0)); i++) {
			RightCornerCoinDropper ();
		}
		PlayerPrefs.SetInt ("GameReward", 0);
	}

	bool pressed = false;

	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) 
		{
			Touch touch = Input.GetTouch (0);
			if(touch.phase == TouchPhase.Began)
			{
				Vector3 wp = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
				Vector2 touchPos = new Vector2 (wp.x, wp.y);
				if (GetComponent<Collider2D> () == Physics2D.OverlapPoint (touchPos)) 
				{
					transform.rotation = Quaternion.Euler(0, 0, -30);
					transform.localScale = new Vector3 (.8f, .8f, 0);
					pressed = true;
				}
			}
			if (touch.phase == TouchPhase.Ended) 
			{
				if (pressed) 
				{
					SceneManager.LoadScene("CTF");
				}
			}
		}
	}

	void RightCornerCoinDropper(){
		GameObject theCoin = Instantiate (CoinDrop);
		theCoin.transform.position = gameObject.transform.position;
		theCoin.GetComponent<Rigidbody2D>().AddForce(transform.up * Random.Range(0, 201));
		theCoin.GetComponent<Rigidbody2D>().AddForce(transform.right * Random.Range(-200, 1));

		if (theCoin.transform.position.y < -10) {
			Destroy (theCoin);
		}
	}
}
