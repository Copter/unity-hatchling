using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTF_Spike : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collision){
		if (collision.collider.tag == "Good") {
			Destroy(gameObject);
		} 
	}
}
