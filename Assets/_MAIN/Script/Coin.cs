using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	void OnBecameInvisible() {
		Destroy(gameObject);
	}

	/*
	// Use this for initialization
	void Start () {
		Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D> ();
		rb.AddForce(transform.up * Random.Range(200, 501));
		rb.AddForce(transform.right * Random.Range(-200, 201));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	*/
}
