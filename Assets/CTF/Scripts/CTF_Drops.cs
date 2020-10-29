using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTF_Drops : MonoBehaviour {

	void Update () {
		if (gameObject.transform.position.y < -2.4f) {
			Destroy (gameObject);
		}
	}
}
