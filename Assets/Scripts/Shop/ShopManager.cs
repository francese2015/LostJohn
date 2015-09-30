using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShopManager {

	private static ShopManager instance = new ShopManager ();

	private List<ShopItem> items;
	
	private CoinsManager coins;

	private ShopManager() {
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

	public bool canBuyItem(string itemName) {
		ShopItem item = getItem(itemName);
		return canBuyItem (item);
	}

	public bool canBuyItem(ShopItem item) {
		bool coinsCondition = CoinsManager.getInstance().canSpendCoins(item.coins);
		bool lvlCondition = LevelManager.getInstance ().getLevel() >= item.lvlToUnlock;
		Debug.Log("can buy " + item.name + "?  " + (coinsCondition && lvlCondition));
		return coinsCondition && lvlCondition;
	}
	
	public bool buyItem(string itemName) {
		ShopItem item = getItem(itemName);

		if (item.coins == 0 && item.price > 0) {
			purchase (item);
			return false;
		} else {
		
			if(canBuyItem(item)) {
				// spends coin and make the item activatable
				coins.spendCoins(item.coins);
				setItemAsBought(item);
				return true;
			
			} else {
				Debug.LogError ("You don't have enough coins to buy " + item.name);
			}
		
		}
		return false;
	}



	private void setItemAsBought(ShopItem item) {
		item.activatable = true;
		
		if (item.permanent) {
			item.coins = 0;
		}
		saveItemState (item);
	}



	private void saveItemState(ShopItem item) {
		if (!item.ALWAYS_AVAILABLE) {
			StorageManager.storeOnDisk (item.name, item.activatable);
		}
	}


	public void destroyItem(string itemName) {
		//Debug.LogError ("destroying " + itemName);
		ShopItem item = getItem (itemName);

		if (item == null) {
			Debug.LogError("Cannot deactivate null item from shop list");
			return;
		}
		item.activatable = false;

		saveItemState (item);
	}


	public void purchase(ShopItem item) {
		Debug.LogError ("Purchasing operations not yet available.");
	}

}
