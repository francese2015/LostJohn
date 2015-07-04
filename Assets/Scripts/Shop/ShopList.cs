using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShopList : MonoBehaviour {

	private const string oneLife = "OneLife";
	private const string tenLife = "TenLife";
	private const string exp1	 = "exp1";
	private const string exp2 	 = "exp2";
	private const string shield 	   = "shield";
	private const string coinsMul6     = "coinsMul6";
	private const string BUY_1000coins = "BUY_1000coins";

	private LevelManager levelManager;

	private static List<ShopItem> items;

	private static ShopList instance = new ShopList();

	private ShopList(){
		levelManager = LevelManager.getInstance ();
		items = createList ();
	}

	public static ShopList getInstance() {
		return instance;
	}

	public List<ShopItem> getItems() {
		return items;
	}

	public ShopItem getItem(int i) {
		if (i < items.Count) {
			return items[i];
		}
		Debug.LogError ("Index out of bound!");
		return null;
	}

//============================================

	private List<ShopItem> createList() {
		List<ShopItem> list = new List<ShopItem>();
		list.Add (getExtraLifeItem ());
		list.Add (getExtraLifesItem ());
		list.Add (getExpMultiplier1());
		list.Add (getExpMultiplier2());
		list.Add (getCoinsMultiplier6());
		list.Add (getShield());
		list.Add (getBUY1000coins());

		update (list);
		save ();
		return list;
	}
	
	public void update(List<ShopItem> list) {
		int actualExp = levelManager.getExps ();

		foreach (ShopItem item in list) {
			// check if activatable, i.e. the object was already bought
			bool activatable = StorageManager.loadBoolFromDisk(item.name);
			item.activatable = activatable;

			// if player has enough experience and the object 
			// and the object wasn't already bought then the item is available
			item.available = (!activatable) && (item.expToUnlock <= actualExp);

			// if the object is activatable and permanent, then it becomes free
			if(item.permanent && item.activatable) {
				item.coins = 0;
			}
		}
	}

	public void save() {
		foreach (ShopItem tmpItem in items) {
			StorageManager.storeOnDisk(tmpItem.name, tmpItem.activatable);
		}
	}

	public void buyItem(ShopItem item) {
		if (item.available) {
			item.activatable = true;
			item.activatable = false;
		}

		if (item.permanent) {
			item.coins = 0;
		}
		save ();
	}


	public ShopItem getItem(string name) {
		foreach (ShopItem i in items) {
			if(i.name == name) {
				return i;
			}
		}
		return null;
	}

	public void destroyItem(string itemName) {
		ShopItem item = getItem (itemName);
		if (item == null) {
			Debug.LogError("Cannot deactivate null item from shop list");
			return;
		}
		item.activatable = false;
		save ();
	}

//============= SHOP DATABASE ================

	private ShopItem getExtraLifeItem() {
		ShopItem item = new ShopItem ();
		item.name = oneLife;
		item.coins = 100;
		item.price = 0;
		item.expToUnlock = 50;
		item.available = false;
		item.activatable = false;
		item.permanent = false;
		return item;
	}

	private ShopItem getExtraLifesItem() {
		ShopItem item = new ShopItem ();
		item.name = tenLife;
		item.coins = 800;
		item.price = 0;
		item.expToUnlock = 200;
		item.available = false;
		item.activatable = false;
		item.permanent = false;
		return item;
	}

	private ShopItem getExpMultiplier1() {
		ShopItem item = new ShopItem ();
		item.name = exp1;
		item.coins = 5000;
		item.price = 0;
		item.expToUnlock = 1000;
		item.available = false;
		item.activatable = false;
		item.permanent = true;
		return item;
	}

	private ShopItem getExpMultiplier2() {
		ShopItem item = new ShopItem ();
		item.name = exp2;
		item.coins = 9000;
		item.price = 0;
		item.expToUnlock = 5000;
		item.available = false;
		item.activatable = false;
		item.permanent = true;
		return item;
	}

	private ShopItem getCoinsMultiplier6() {
		ShopItem item = new ShopItem ();
		item.name = coinsMul6;
		item.coins = 12000;
		item.price = 0;
		item.expToUnlock = 2500;
		item.available = false;
		item.activatable = false;
		item.permanent = false;
		return item;
	}

	private ShopItem getShield() {
		ShopItem item = new ShopItem ();
		item.name = shield;
		item.coins = 500;
		item.price = 0;
		item.expToUnlock = 6000;
		item.available = false;
		item.activatable = false;
		item.permanent = false;
		return item;
	}

	private ShopItem getBUY1000coins() {
		ShopItem item = new ShopItem ();
		item.name = BUY_1000coins;
		item.coins = 0;
		item.price = 0.49;
		item.expToUnlock = 10;
		item.available = false;
		item.activatable = false;
		item.permanent = false;
		return item;
	}

}
