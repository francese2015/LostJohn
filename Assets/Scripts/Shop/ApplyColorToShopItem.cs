using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ApplyColorToShopItem : MonoBehaviour {

	public Image background;

	private Color unavailable = Color.gray;
	private Color bought = Color.gray;

	
	void Start () {

		string itemName = transform.name;
		ShopItem item = ShopManager.getInstance ().getItem (itemName);

		int playerLevel = LevelManager.getInstance ().getLevel ();

		if (item.lvlToUnlock > playerLevel) {
			useUnavailableUI ();
		} 
	}

	private void useUnavailableUI() {
		background.color = unavailable;
	}

}
