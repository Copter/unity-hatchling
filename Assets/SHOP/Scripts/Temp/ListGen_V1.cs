using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListGen_V1 : MonoBehaviour {

	public GameObject listContent;
	public GameObject itemLine;
	public GameObject[] bg_ItemSet = new GameObject[3];

	void Start () 
	{
		BG_CreateList ();
	}

	public void RelistItem ()
	{
		//print ("Relisting Items...");
		GameObject oldList = GameObject.Find ("List Content");
		//Destroy (oldList);
		oldList.SetActive(false);

		BG_CreateList ();
	}

	void BG_CreateList ()
	{
		if (GameObject.Find ("List Content") == null) 
		{
			GameObject newFrame = GameObject.Instantiate (listContent);
			newFrame.name = "List Content";
			newFrame.transform.SetParent (GameObject.Find ("Viewport").transform, false);
			GameObject.Find ("Scroll View").GetComponent< ScrollRect > ().content = newFrame.GetComponent< RectTransform > ();
		}


		int Line;
		for (Line = 0; Line * 3 < bg_ItemSet.Length; Line++) 
		{
			GameObject lineDiv = GameObject.Instantiate (itemLine);
			lineDiv.transform.SetParent(GameObject.Find ("List Content").transform);
			lineDiv.transform.position = new Vector3 (/*0.2f*/0, (.03f * Line)/*+ 2.4f*/, 0);

			for (int perLine = 0; perLine < 3; perLine++) 
			{
				if ((3 * Line) + perLine < bg_ItemSet.Length) 
				{
					int itemID = (3 * Line) + perLine;
					string itemTag = "BGItem" + itemID;
					int itemUnlocked = PlayerPrefs.GetInt (itemTag, 0);

					GameObject created = GameObject.Instantiate (bg_ItemSet [itemID]);
					created.name = itemTag;
					created.transform.position = new Vector3 ((1.2f * perLine)-1.2f, 0, 0);
					// THE NUMBER (?? * (LineLimit - 5)) WORKS WITH "THE DISTANCE BETWEEN ITEMS WHEN LAID ON CANVAS."
					// PROBABLY ONLY WORKS FOR THIS SCREEN SIZE
					// IF "THE DISTANCE BETWEEN ITEMS WHEN LAID ON CANVAS" IS CHANGE, CHANGE THIS NUMBER PROPOTIONALLY TO THAT.
					created.transform.localScale = new Vector3 (.03f, .03f);	// CHANGE BUTTON SIZE
					created.transform.SetParent (lineDiv.transform);

					if (itemUnlocked == 1) {
						GameObject priceTag = GameObject.Find (created.name + "/Price");
						Destroy (priceTag);

						GameObject checkboxObj = GameObject.Instantiate (GameObject.Find ("Checkbox"));
						checkboxObj.name = created.name +" Box";
						checkboxObj.transform.SetParent (created.transform, false);
						checkboxObj.GetComponent< RectTransform > ().position = created.GetComponent< RectTransform > ().position;
					}
				}
			}
		}
	}

}
