using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CTF_Russ : MonoBehaviour {

	public Sprite RussLeft;
	public Sprite RussMiddle;
	public Sprite RussRight;
	public Sprite Ouch;

	public Text ScoreText;
	public Text BestText;

	static public bool On = true;
	static public int Move = 1;
	public int Score = 0;
	public int highscore;

	bool rewardGiven;
	public int wallet;
	public int earned;

	// Use this for initialization
	void Start () {
		On = true;
		rewardGiven = false;
		highscore = PlayerPrefs.GetInt ("highscore", 0);
		BestText.text = highscore.ToString();
		float energy = PlayerPrefs.GetFloat ("Energy", 100);
		PlayerPrefs.SetFloat ("Energy", energy - 10);
	}
	
	// Update is called once per frame
	void Update () {
		if (On) {
			if (Move == 0) {
				transform.position = new Vector3 (-2, -2, 0);
				GetComponent<SpriteRenderer> ().sprite = RussLeft;
			}
			if (Move == 1) {
				transform.position = new Vector3 (0, -2, 0);
				GetComponent<SpriteRenderer> ().sprite = RussMiddle;
			}
			if (Move == 2) {
				transform.position = new Vector3 (2, -2, 0);
				GetComponent<SpriteRenderer> ().sprite = RussRight;
			}
		}

		ScoreText.text = Score.ToString();
		if (Score > highscore) {
			BestText.text = Score.ToString();
		}

		// TEMPORARY RESTART //
		if(!On){
			int best = PlayerPrefs.GetInt ("highscore", 0);
			if (Score > best) 
			{
				PlayerPrefs.SetInt ("highscore", Score);
			}

			if (!rewardGiven) {
				wallet = PlayerPrefs.GetInt ("Coin", 0);
				earned = Score / 5;
				if (
					PlayerPrefs.GetFloat("Joy", 100)>=50 &&
					PlayerPrefs.GetFloat("Hunger", 100)>=50 &&
					PlayerPrefs.GetFloat("Energy", 100)>=50
				) 
				{
					earned = earned * 2;
				}
				PlayerPrefs.SetInt ("Coin", wallet + earned);
				int gameReward = PlayerPrefs.GetInt ("GameReward", 0);
				PlayerPrefs.SetInt ("GameReward", gameReward + earned);
				rewardGiven = true;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		if (collision.collider.tag == "Good") {
			if (On)
				Score += 1;
			Destroy (collision.collider.gameObject);
		} 
		if (collision.collider.tag == "Bad") {
			GetComponent<SpriteRenderer> ().sprite = Ouch;
			On = false;
			Destroy (collision.collider.gameObject);
		}
	}
}
