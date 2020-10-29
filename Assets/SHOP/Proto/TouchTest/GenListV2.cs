using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenListV2 : MonoBehaviour {

	public GameObject Sample;
	public int LineLimit = 5;

	void Start () {
		int Line;
		for (Line = 0; Line < LineLimit; Line++) {	//for 5 Lines, in this case
			for (int perLine = 0; perLine < 3; perLine++) {
				GameObject created = GameObject.Instantiate (Sample);


				//created.transform.position = new Vector3 ((50 * perLine) - 50, (-50 * Line)+100, 0);
				if (LineLimit <= 5) created.transform.position = new Vector3 ((50 * perLine) - 50, (-50 * Line)+100, 0);
				if (LineLimit > 5) created.transform.position = new Vector3 (((50 * perLine) - 50), ((-50 * Line) + (24.998f * (LineLimit - 5)))+100, 0);
				//if (LineLimit > 5) created.transform.position = new Vector3 (((50 * perLine) - 50), ((-50 * Line) + (27.2727f * (LineLimit - 5)))+100, 0);
				//else 			created.transform.position = new Vector3 (((50 * perLine) - 50), ((-50 * Line) + (50 * (LineLimit - 6)) + 100), 0);
				created.transform.localScale = new Vector3 (20, 20);	//because buttons are oversized in this case
				created.transform.parent = GameObject.Find ("List Content").transform;

				/*
				if (LineLimit <= 5) 	created.transform.position = new Vector3 (((50 * perLine) - 50), ((-50 * Line) + 100), 0);
				else 			created.transform.position = new Vector3 (((50 * perLine) - 50), ((-50 * Line) + (50 * (LineLimit - 6)) + 100), 0);
				created.transform.localScale = new Vector3 (20, 20);	//because buttons are oversized in this case
				created.transform.parent = GameObject.Find ("List Content").transform;
				*/
			}
		}

		if (LineLimit > 5) {
			//GameObject itemframe = GameObject.Find ("List Content");
			GameObject.Find ("List Content").GetComponent< RectTransform >( ).sizeDelta = new Vector2 (183, 325 + (45.831f*(Line - 5)));
			GameObject.Find ("List Content").GetComponent< RectTransform >( ).localPosition = new Vector2 (0, 0 - (46*(Line - 5)));
			//GameObject.Find ("List Content").GetComponent< RectTransform >( ).localPosition = new Vector2 (0, 9999);
		}
	}
		
}
