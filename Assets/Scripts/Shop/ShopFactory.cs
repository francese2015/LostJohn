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

	private GameObject createShopItem(ShopItem item) {
		GameObject p = (GameObject) Instantiate (prefab, new Vector3 (startX, startY, 0), Quaternion.identity);
		p.name = item.name;
		applyProperties (p, item);
		p.transform.SetParent (transform);
		return p;
	}


	private void applyProperties(GameObject o, ShopItem i) {
		Transform[] tList = o.GetComponentsInChildren<Transform> ();

		//Debug.Log("aggiungendo " + i.name + ": " + i.description + ", " + i.coins);

		foreach (Transform t in tList) {
			if (t.name == "name") {
				t.gameObject.GetComponent<Text>().text = i.description;
			}

			if (t.name == "lvl") {
				t.gameObject.GetComponent<Text>().text = "lvl " + i.lvlToUnlock;
			}

			if (t.name == "coins") {
				if (i.coins > 0) {
					t.gameObject.GetComponent<Text>().text = i.coins + "";
				} else {
					t.gameObject.GetComponent<Text>().text = i.price + " €";

				}
			}

			if (t.name == "ico") {
				t.gameObject.GetComponent<Image>().sprite = getSprite(i.name);
			}

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
