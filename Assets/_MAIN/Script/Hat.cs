using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hat : MonoBehaviour {

	public Sprite[] hatSet = new Sprite[3];

	// Use this for initialization
	void Start () {
		int equippedHat = PlayerPrefs.GetInt ("ActHATID", 0);
		GetComponent<SpriteRenderer> ().sprite = hatSet [equippedHat];
		//GetComponent<SpriteRenderer> ().sprite = hatSet [2];	//TEST
	}

	int laugh;
	
	// Update is called once per frame
	void Update () {
		GameObject objWithAnim = GameObject.Find("Russ");
		//Animator animComp = objWithAnim.GetComponent<Animator>();
		Anim scrAnim = objWithAnim.GetComponent<Anim>();
		if (scrAnim.poked) {
			StartCoroutine(PokedHat ());
		}
		else if (scrAnim.rubbed) {
			StartCoroutine(RubbedHat ());
		} 
		else if (scrAnim.tired == 1 && laugh == 0) {
			StartCoroutine(TiredHat ());
		}  
		else if (laugh == 0){
			StartCoroutine(HappyHat ());
		}
	}

	IEnumerator TiredHat (){
		yield return new WaitForSeconds(0.1f);
		transform.position = new Vector3 (0.60f, -1);
	}

	IEnumerator HappyHat (){
		yield return new WaitForSeconds(0.1f);
		transform.position = new Vector3 (-0.10f, -0.01f);
	}
	IEnumerator RubbedHat (){
		yield return new WaitForSeconds(0.1f);
		transform.position = new Vector3 (-0.03f, 0.32f);
	}
	IEnumerator PokedHat (){
		laugh += 1;
		for (int i = 0; i < 7; i++) {
			yield return new WaitForSeconds (0.1f);
			transform.position = new Vector3 (-0.03f, 0.32f);
		}
		laugh -= 1;
	}

}
