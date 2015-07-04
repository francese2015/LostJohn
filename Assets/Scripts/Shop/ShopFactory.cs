using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShopFactory : MonoBehaviour {

	public GameObject itemsList;


	void Start() {
		// get items of shop
		List<ShopItem> list = ShopList.getInstance ().getItems ();

		//create a scrollable list
		ScrollableList scrollScript = GetComponent<ScrollableList> ();
		scrollScript.createList (itemsList, list.Count);

		//get the scrollable list
		List<GameObject> instantiatedList = scrollScript.getItemList ();
		createShop ();
	}

	private void createShop() {
		
	}
}
