using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShopList : MonoBehaviour {

	private const string oneLife = "buy_life";
	private const string tenLife = "buy_lifes";
	private const string exp1	 = "buy_exp";
	private const string exp2 	 = "buy_exp2";
	private const string shield 	   = "buy_shield";
	private const string coinsMul6     = "buy_mul";
	private const string BUY_1000coins = "buy_coins";

	private LevelManager levelManager;

	private static List<ShopItem> items;

	private static ShopList instance = new ShopList();

	private ShopList(){
		levelManager = LevelManager.getInstance ();
		items = createList ();
		save ();
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
		foreach (ShopItem i in items) {
			StorageManager.storeOnDisk(i.name, i.activatable);
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
		item.setAction (new ExtraLifeAction ());
		item.name = oneLife;
		item.description = "extra life";
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
		item.description = "10 extra lifes";
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
		item.description = "1/2 exp extra";
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
		item.description = "1/1 exp extra";
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
		item.description = "coins x2";
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
		item.description = "shield";
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
		item.description = "1000 coins pack";
		item.coins = 0;
		item.price = 0.49;
		item.expToUnlock = 10;
		item.available = false;
		item.activatable = false;
		item.permanent = false;
		return item;

	}

}
