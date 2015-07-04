using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShopManager : MonoBehaviour {

	private static ShopManager instance = new ShopManager ();

	private List<ShopItem> items;

	private ShopList shopList;

	private CoinsManager coins;


	private ShopManager() {
		shopList = ShopList.getInstance ();
		coins = CoinsManager.getInstance ();
		this.items = ShopList.getInstance().getItems ();
	}

	public static ShopManager getInstance() {
		return instance;
	}

	public ShopItem getItem(string name) {
		foreach (ShopItem i in items) {
			if(i.name == name) {
				return i;
			}
		}
		return null;
	}

	public void buyItem(string itemName) {
		ShopItem item = getItem(itemName);

		if (item.coins == 0 && item.price > 0) {
			purchase (item);
			return;
		} else {
		
			if(item.price <= coins.getCoins()) {
				// spends coin and make the item activatable
				coins.spendCoins(item.coins);
				shopList.buyItem(item);
			
			} else {
				Debug.LogError ("You don't have enough coins to buy " + item.name);
			}
		
		}

	}

	public void purchase(ShopItem item) {
		Debug.LogError ("Purchasing operations not yet available.");
	}

}
