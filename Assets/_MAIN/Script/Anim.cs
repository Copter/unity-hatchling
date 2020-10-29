using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim : MonoBehaviour {

	public Animator anim;

	//public bool blinking = false;
	public int tired = 0;
	public bool eating = false;
	public bool rubbed = false;
	public bool poked = false;

	// Use this for initialization
	void Start () {
		StartCoroutine(BlinkingAnim ());
	}

	// Update is called once per frame
	void Update () {
		anim.SetBool ("rubbed", rubbed);
		anim.SetBool ("poked", poked);

		anim.SetBool ("eating", eating);
		if (eating) {
			StartCoroutine (FinishEating ());
		}
			
		if (tired == 1) {
			if(anim.GetInteger("tired") == 1)	{anim.SetInteger ("tired", 2);}
			if(anim.GetInteger("tired") == 0)	{anim.SetInteger ("tired", 1);}
		}
		if (tired == 0) anim.SetInteger ("tired", tired);
	}

	IEnumerator BlinkingAnim (){
		anim.SetBool ("blinking", false);
		yield return new WaitForSeconds(9.66f);
		anim.SetBool ("blinking", true);
		yield return new WaitForSeconds(0.33f);
		StartCoroutine(BlinkingAnim ());
	}

	bool overlapFE = false;

	IEnumerator FinishEating (){
		if(!overlapFE)
		{
			overlapFE = true;
			yield return new WaitForSeconds (1.5f);
			eating = false;
			overlapFE = false;
		}
	}
}
