using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WalletCoin : MonoBehaviour {

	int coin;

	void Update () {
		coin = PlayerPrefs.GetInt ("Coin", 0);
		gameObject.GetComponent<Text>().text = coin.ToString();
	}
}
