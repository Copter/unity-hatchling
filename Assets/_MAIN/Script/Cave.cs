using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cave : MonoBehaviour {

	public Sprite Stage0;
	public Sprite Stage1;
	public Sprite Stage2;
	public Sprite Stage3;
	public Sprite Stage4;


	void Update () {
		GameObject objWithStats = GameObject.Find ("Russ");
		Stats scrStats = objWithStats.GetComponent<Stats> ();

		if(scrStats.coin >= 0)	gameObject.GetComponent<SpriteRenderer>().sprite = Stage0;
		if(scrStats.coin >= 10)	gameObject.GetComponent<SpriteRenderer>().sprite = Stage1;
		if(scrStats.coin >= 50)	gameObject.GetComponent<SpriteRenderer>().sprite = Stage2;
		if(scrStats.coin >= 100)	gameObject.GetComponent<SpriteRenderer>().sprite = Stage3;
		if(scrStats.coin >= 500)	gameObject.GetComponent<SpriteRenderer>().sprite = Stage4;
	}
}
