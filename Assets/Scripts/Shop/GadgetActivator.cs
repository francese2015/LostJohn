using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GadgetActivator : MonoBehaviour {

	private static List<ShopItem> gadgets;
	private ShopList shopList;

	private static GadgetActivator instnce = new global::GadgetActivator();

	private GadgetActivator(){
	}

	public static GadgetActivator getInstance() {
		return instnce;
	}


	public void activate(string itemName) {
		Debug.Log("activating " + itemName);
		ShopItem gadget = ShopManager.getInstance ().getItem (itemName);
		gadget.use ();

		if (gadget.ALWAYS_AVAILABLE) {
			ShopManager.getInstance().destroyItem(itemName);
		}
	}
}
