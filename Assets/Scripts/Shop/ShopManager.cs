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

	public List<ShopItem> getShopItems(){
		return items;
	}

	public ShopItem getItem(string name) {
		foreach (ShopItem i in items) {
			if(i.name == name) {
				return i;
			}
		}
		return null;
	}

	public bool buyItem(string itemName) {
		Debug.Log ("trying to buy " + items);
		ShopItem item = getItem(itemName);

		if (item.coins == 0 && item.price > 0) {
			purchase (item);
			return false;
		} else {
		
			if(item.price <= coins.getCoins()) {
				// spends coin and make the item activatable
				coins.spendCoins(item.coins);
				shopList.buyItem(item);
				return true;
			
			} else {
				Debug.LogError ("You don't have enough coins to buy " + item.name);
			}
		
		}
		return false;
	}

	public void purchase(ShopItem item) {
		Debug.LogError ("Purchasing operations not yet available.");
	}

}
