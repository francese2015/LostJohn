using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ShopFactory : MonoBehaviour {

	public GameObject prefab;

	public Sprite[] icons;

	public float Ydist = 2;
	public float startY = -11.4f;
	public float startX = -2.3f;

	private List<ShopItem> items;
	private List<GameObject> itemsCompleted;


	void Start() {
		items = ShopManager.getInstance ().getShopItems ();
		createShop ();
	}

	private void createShop() {
		for (int i = 0; i < items.Count; i++) {
			createShopItem(items[i]);
			startY -= Ydist;
		}
	}

	public GameObject createShopItem(ShopItem item) {
		GameObject p = (GameObject) Instantiate (prefab, new Vector3 (startX, startY, 0), Quaternion.identity);
		p.name = item.name;
		applyProperties (p, item);
		p.transform.SetParent (transform);
		return p;
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
