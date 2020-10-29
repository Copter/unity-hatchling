using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

	public Sprite[] bgSet = new Sprite[3];

	void Start () {
		int bgHat = PlayerPrefs.GetInt ("ActBGID", 0);
		GetComponent<SpriteRenderer> ().sprite = bgSet [bgHat];
	}
}
