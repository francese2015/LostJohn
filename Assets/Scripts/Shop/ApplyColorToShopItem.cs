using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ApplyColorToShopItem : MonoBehaviour {
	
	void Start () {

		string itemName = transform.name;
		int lvlToUnlock = ShopManager.getInstance ().getItem (itemName).lvlToUnlock;
		int playerLevel = LevelManager.getInstance ().getLevel ();

		if (lvlToUnlock > playerLevel) {
			changeColor ();
		}
	}

	private void changeColor() {
		//9D9D9DFF
		Transform[] tList = GetComponentsInChildren<Transform> ();
		
		foreach (Transform t in tList) {
			if (t.name == "background") {
				t.gameObject.GetComponent<Image> ().color = Color.gray;
			}
		}
	}

}
