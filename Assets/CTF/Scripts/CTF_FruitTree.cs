using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTF_FruitTree : MonoBehaviour {

	public GameObject Fruit;
	public GameObject Spike;

	public float Speed = 3;

	void Start () {
			StartCoroutine (FruitLoops ());
			//StartCoroutine (SpikeLoops ());
			StartCoroutine (Accelerate ());
	}

	IEnumerator FruitLoops() {
		float period = 2*3/Speed;
		yield return new WaitForSeconds (period);

		int rando = Random.Range (0,3);
		GameObject obj = Instantiate (Fruit);
		if (rando == 1) obj.transform.position = new Vector3 (-2, 3.5f, 0);
		if (rando == 2) obj.transform.position = new Vector3 (2, 3.5f, 0);
		if (rando == 0) obj.transform.position = new Vector3 (0, 3.5f, 0);
		obj.GetComponent<Rigidbody2D>().velocity = new Vector2 ( obj.GetComponent<Rigidbody2D>().velocity.x, -Speed);

		yield return new WaitForSeconds (period/2);

		int rand = Random.Range (0,2);
		if(rand == 1){
			rando = Random.Range (0,3);
			obj = Instantiate (Spike);
			if (rando == 1) obj.transform.position = new Vector3 (-2, 3.5f, 0);
			if (rando == 2) obj.transform.position = new Vector3 (2, 3.5f, 0);
			if (rando == 0) obj.transform.position = new Vector3 (0, 3.5f, 0);
			obj.GetComponent<Rigidbody2D>().velocity = new Vector2 ( obj.GetComponent<Rigidbody2D>().velocity.x, -Speed);
		}

		yield return new WaitForSeconds (period/2);

		rando = Random.Range (0,3);
		obj = Instantiate (Fruit);
		if (rando == 1) obj.transform.position = new Vector3 (-2, 3.5f, 0);
		if (rando == 2) obj.transform.position = new Vector3 (2, 3.5f, 0);
		if (rando == 0) obj.transform.position = new Vector3 (0, 3.5f, 0);
		obj.GetComponent<Rigidbody2D>().velocity = new Vector2 ( obj.GetComponent<Rigidbody2D>().velocity.x, -Speed);

		yield return new WaitForSeconds (period);

		rand = Random.Range (0,2);
		if(rand == 1){
			rando = Random.Range (0,3);
			obj = Instantiate (Spike);
			if (rando == 1) obj.transform.position = new Vector3 (-2, 3.5f, 0);
			if (rando == 2) obj.transform.position = new Vector3 (2, 3.5f, 0);
			if (rando == 0) obj.transform.position = new Vector3 (0, 3.5f, 0);
			obj.GetComponent<Rigidbody2D>().velocity = new Vector2 ( obj.GetComponent<Rigidbody2D>().velocity.x, -Speed);
		}

		rando = Random.Range (0,3);
		obj = Instantiate (Fruit);
		if (rando == 1) obj.transform.position = new Vector3 (-2, 3.5f, 0);
		if (rando == 2) obj.transform.position = new Vector3 (2, 3.5f, 0);
		if (rando == 0) obj.transform.position = new Vector3 (0, 3.5f, 0);
		obj.GetComponent<Rigidbody2D>().velocity = new Vector2 ( obj.GetComponent<Rigidbody2D>().velocity.x, -Speed);

		if (CTF_Russ.On) StartCoroutine (FruitLoops());
	}

	/*IEnumerator SpikeLoops() {
		float period = 3*3/Speed;
		yield return new WaitForSeconds (period);

		int rand = Random.Range (0,2);
		if(rand == 1){
			int rando = Random.Range (0,3);
			GameObject obj = Instantiate (Spike);
			if (rando == 1) obj.transform.position = new Vector3 (-2, 3.5f, 0);
			if (rando == 2) obj.transform.position = new Vector3 (2, 3.5f, 0);
			if (rando == 0) obj.transform.position = new Vector3 (0, 3.5f, 0);
			obj.GetComponent<Rigidbody2D>().velocity = new Vector2 ( obj.GetComponent<Rigidbody2D>().velocity.x, -Speed);
		}

		if (CTF_Russ.On) StartCoroutine (SpikeLoops());
	}*/

	IEnumerator Accelerate(){
		yield return new WaitForSeconds(6);
		Speed += .5f;
		if (CTF_Russ.On) StartCoroutine (Accelerate());
	}
}
