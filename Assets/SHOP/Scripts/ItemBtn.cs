using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBtn : MonoBehaviour {

	public bool confirmClick = false;
	public bool cancelClick = false;
	public Sprite uncheckedBoxSpr;
	public Sprite checkedBoxSpr;
	GameObject okObject;

	void Start (){
		Button button = gameObject.GetComponent<Button>();
		button.onClick.AddListener(ItemBtnPressed);

		/* // RESET UNLOCKS
		PlayerPrefs.SetInt ("BG_Item0", 0);
		PlayerPrefs.SetInt ("BG_Item1", 0);
		PlayerPrefs.SetInt ("BG_Item2", 0);	
		PlayerPrefs.SetInt ("HATItem0", 0);
		PlayerPrefs.SetInt ("HATItem1", 0);
		*/
	}

	void Update () {	
		string itemName = gameObject.name;
		int itemUnlocked = PlayerPrefs.GetInt (itemName, 0);

		if (Input.GetMouseButtonDown (0)) {	// Works for touch controls too.
			if (itemUnlocked == 0) {
				if (cancelClick) {
					cancelClick = false;
				} else {
					cancelClick = true;
				}

				if (confirmClick != cancelClick) {
					confirmClick = false;
					cancelClick = false;
					if (GameObject.Find ("thisOK") != null) {
						Destroy (GameObject.Find ("thisOK"));
					}
				}
			}
		}

		if(itemUnlocked == 1)
		{
			string itemID =  gameObject.name.Remove (0, 7);
			int itemIDNo = Convert.ToInt32(itemID);
			GameObject checkboxObj = GameObject.Find (gameObject.name + " Box");

			int ChooseList = PlayerPrefs.GetInt ("ShopType", 0);
			int alreadyEquipped = 0;
			switch (ChooseList) 
			{
			case 0:
				alreadyEquipped = PlayerPrefs.GetInt ("ActBGID", 0);
				break;
			case 1:
				//alreadyEquipped = PlayerPrefs.GetInt ("ActEGGID", 0);
				break;
			case 2:
				alreadyEquipped = PlayerPrefs.GetInt ("ActHATID", 0);
				break;
			}

			if (itemIDNo == alreadyEquipped){
				checkboxObj.GetComponent< Image > ().sprite = checkedBoxSpr;
			} else {
				checkboxObj.GetComponent< Image > ().sprite = uncheckedBoxSpr;
			}
		}
	}

	public void ItemBtnPressed () {
		string itemName = gameObject.name;
		int itemUnlocked = PlayerPrefs.GetInt (itemName, 0);
		if (itemUnlocked == 0) {
			if (confirmClick) {
				GameObject priceTag = GameObject.Find (gameObject.name + "/Price");
				string priceText = priceTag.GetComponent<Text> ().text;
				int itemPrice = Convert.ToInt32(priceText);
				if (PlayerPrefs.GetInt ("Coin", 0) >= itemPrice) {
					//print (itemName + " GET!");
					// 1. Save for buying this item
					PlayerPrefs.SetInt (itemName, 1);
					// 2. Take the coins
					int currentCoin = PlayerPrefs.GetInt ("Coin", 0);
					int changedCoin = currentCoin - itemPrice;
					PlayerPrefs.SetInt ("Coin", changedCoin);
					// 3. Delete and create the item list (in ItemListGen).
					GameObject thatListObj = GameObject.Find ("EventSystem");
					ItemListGen thatListScript = thatListObj.GetComponent<ItemListGen> ();
					thatListScript.RelistItem ();
				} else {
					StartCoroutine (RedBlink());
				}

					confirmClick = false;
					cancelClick = false;
					if (GameObject.Find ("thisOK") != null) {
						Destroy (GameObject.Find ("thisOK"));
					}
			} else {
				confirmClick = true;
				okObject = GameObject.Instantiate (GameObject.Find ("ConfirmOK"));
				okObject.name = "thisOK";
				okObject.transform.SetParent (gameObject.transform, false);
				okObject.GetComponent< RectTransform > ().position = gameObject.GetComponent< RectTransform > ().position;
			}
		}
		if (itemUnlocked == 1) {
			string itemID =  gameObject.name.Remove (0, 7);
			int itemIDNo = Convert.ToInt32(itemID);

			int ChooseList = PlayerPrefs.GetInt ("ShopType", 0);
			switch (ChooseList) 
			{
			case 0:
				PlayerPrefs.SetInt ("ActBGID", itemIDNo);
				break;
			case 1:
				//PlayerPrefs.SetInt ("ActEGGID", itemIDNo);
				break;
			case 2:
				PlayerPrefs.SetInt ("ActHATID", itemIDNo);
				break;
			}

			//print ("Background ID = "+gameObject.name.Remove(0,7));

		}
	}

	IEnumerator RedBlink(){
		GameObject priceTag = GameObject.Find (gameObject.name + "/Price");
		GameObject walletText = GameObject.Find ("Coin_Text");

		for(int blinkCount = 0; blinkCount < 3; blinkCount++)
		{
			walletText.GetComponent<Text> ().color = Color.red;
			priceTag.GetComponent<Text> ().color = Color.red;
			yield return new WaitForSeconds(.1f);
			walletText.GetComponent<Text> ().color = Color.black;
			priceTag.GetComponent<Text> ().color = Color.black;
			yield return new WaitForSeconds(.1f);
		}
	}
		
}
