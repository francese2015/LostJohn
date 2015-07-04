using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GadgetActivator : MonoBehaviour {

	private List<ShopItem> gadgets;
	private ShopList shopList;

	// Use this for initialization
	void Start () {
		shopList = ShopList.getInstance ();
		gadgets = shopList.getItems ();

		foreach (ShopItem item in gadgets) {
			activateInGame(item);
		}
	}
	
	private void activateInGame(ShopItem item) {
		if(item.activatable) {
			GameObject toActivate = GameObject.Find (item.name);
			toActivate.SetActive(true);
		}
	}

	public void deactivateGadget(string itemName) {
		shopList.destroyItem (itemName);
	}
}
