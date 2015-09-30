using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ShopFactory2 : MonoBehaviour {

	public GameObject shopItem;

	public Sprite[] icons;

	private List<ShopItem> items;
	private List<GameObject> itemsCompleted;


	void Start() {
		items = ShopManager.getInstance ().getShopItems ();
		createShop ();
	}

	private void createShop() {
		for (int i = 0; i < items.Count; i++) {
			createShopItem(items[i]);
		}
	}

	public GameObject createShopItem(ShopItem item) {
		GameObject go = Instantiate (shopItem) as GameObject;
		go.name = item.name;
		applyProperties (go, item);
		go.transform.SetParent (transform);
		go.GetComponent<RectTransform> ().localScale = Vector3.one;
		return go;
	}


	private void applyProperties(GameObject o, ShopItem i) {
		//Debug.Log("aggiungendo " + i.name + ": " + i.description + ", " + i.coins);

		GraphicButtonManager button =  o.GetComponent<GraphicButtonManager> ();
		button.setDescription(i.description);
		button.setLevel("lvl " + i.lvlToUnlock);

		button.setIco (getSprite (i.name));

		bool useCoin = i.price == 0;

		// already bought
		if (i.isActivatable()) {
			button.setBought ();
		// locked
		} else if (!i.isUnlocked ()) {
			button.setLocked ();
		// to buy
		} else {
			button.setCoins (useCoin ? (i.coins + "") : (i.price + " €"));
			button.setCoinsImage (useCoin);
			button.setBuyable ();
		}

	}


	private Sprite getSprite(string name) {
		for (int i = 0; i < icons.Length; i++) {
			if(icons[i].name == name) {
				return icons[i];
			}
		}
		return null;
	}
}
