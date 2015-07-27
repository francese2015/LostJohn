using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * When a shop item is available means that it can be bought 
 * with coins or money. When an item is bought then it become 
 * activatable. If the item is permanent is will remain activatable
 * forever, that means it can not be bought again; viceversa,
 * if it is not permanent then it can be bought again.
 * 
 * For this reason, when an item is activatable its price becomes 0.
 */
public class ShopList : MonoBehaviour {

	public const string oneLife  = "buy_life";
	public const string tenLifes = "buy_lifes";
	public const string exp1	  = "buy_exp";
	public const string exp2 	  = "buy_exp2";
	public const string shield 	   = "buy_shield";
	public const string coinsMul      = "buy_mul";
	public const string BUY_1000coins = "buy_coins";

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
		list.Add (getCoinsMultiplier());
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

			// if the object is activatable and permanent, then it becomes free
			if(item.permanent && item.activatable) {
				item.coins = 0;
			}
		}
	}

	public ShopItem getItem(string name) {
		foreach (ShopItem i in items) {
			if(i.name == name) {
				return i;
			}
		}
		return null;
	}



//============= SHOP DATABASE ================

	private ShopItem getExtraLifeItem() {
		ShopItem item = new ShopItem ();

		item.setAction (new ExtraLifeAction ());

		item.name = oneLife;
		item.ALWAYS_AVAILABLE = true;
		item.permanent = false;
		item.lvlToUnlock = 2;
		item.description = "extra life";

		item.activatable = StorageManager.loadBoolFromDisk(oneLife);

		setProperCoins (item, 100, 0);
		return item;
	}

	private ShopItem getExtraLifesItem() {
		ShopItem item = new ShopItem ();

		item.setAction (new ExtraLifesAction ());

		item.name = tenLifes;
		item.ALWAYS_AVAILABLE = true;
		item.permanent = false;
		item.lvlToUnlock = 4;
		item.description = "10 extra lifes";

		item.activatable = StorageManager.loadBoolFromDisk(tenLifes);

		setProperCoins (item, 800, 0);
		return item;
	}

	private ShopItem getExpMultiplier1() {
		ShopItem item = new ShopItem ();

		item.setAction (new ExtraExp1Action());

		item.name = exp1;
		item.ALWAYS_AVAILABLE = false;
		item.permanent = true;
		item.lvlToUnlock = 10;
		item.description = "50% exp extra";
		
		item.activatable = StorageManager.loadBoolFromDisk(exp1);

		setProperCoins (item, 5000, 0);
		return item;

	}

	private ShopItem getExpMultiplier2() {
		ShopItem item = new ShopItem ();

		item.setAction (new ExtraExp2Action());

		item.name = exp2;
		item.ALWAYS_AVAILABLE = false;
		item.permanent = true;
		item.lvlToUnlock = 20;
		item.description = "100% exp extra";
		
		item.activatable = StorageManager.loadBoolFromDisk(exp2);

		setProperCoins (item, 9000, 0);
		return item;
	}

	private ShopItem getCoinsMultiplier() {
		ShopItem item = new ShopItem ();

		item.setAction (null);

		item.name = coinsMul;
		item.ALWAYS_AVAILABLE = false;
		item.permanent = true;
		item.lvlToUnlock = 25;
		item.description = "coins x2";
		
		item.activatable = StorageManager.loadBoolFromDisk(coinsMul);

		setProperCoins (item, 12000, 0);
		return item;

	}

	private ShopItem getShield() {
		ShopItem item = new ShopItem ();

		item.setAction (null);
		
		item.name = shield;
		item.ALWAYS_AVAILABLE = false;
		item.permanent = false;
		item.lvlToUnlock = 8;
		item.description = "shield";
		
		item.activatable = StorageManager.loadBoolFromDisk(shield);

		setProperCoins (item, 500, 0);
		return item;

	}

	private ShopItem getBUY1000coins() {
		ShopItem item = new ShopItem ();

		item.setAction (null);
		
		item.name = BUY_1000coins;
		item.ALWAYS_AVAILABLE = true;
		item.permanent = false;
		item.lvlToUnlock = 1;
		item.description = "1000 coins pack";
		
		item.activatable = StorageManager.loadBoolFromDisk(BUY_1000coins);

		setProperCoins (item, 0, 0.49);
		return item;

	}

	private void setProperCoins(ShopItem i, int coins, double price) {
			i.coins = coins;
			i.price = price;
	}

}
