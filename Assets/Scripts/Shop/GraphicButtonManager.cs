using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GraphicButtonManager : MonoBehaviour {

	public Text name;
	public Text lvl;
	public Text coins;
	public Image coinsImage;
	public Image ico;
	public Image locked;
	public Image bought;

	public void setDescription(string s) {
		name.text = s;
	}

	public void setLevel(string s) {
		lvl.text = s;
	}

	public void setCoins(string s) {
		coins.text = s;
	}

	public void setCoinsImage(bool state) {
		coinsImage.enabled = state;
	}

	public void setIco(Sprite image) {
		ico.sprite = image;
	}

	// cannot be bought because no enough experience
	public void setLocked() {
		locked.enabled = true;
		bought.enabled = false;
		setCoins ("");
		setCoinsImage (false);
	}

	public void setBought() {
		locked.enabled = false;
		bought.enabled = true;
		setCoins ("");
		setCoinsImage (false);
	}

	public void setBuyable() {
		locked.enabled = false;
		bought.enabled = false;
	}

	
	public void update(ShopItem i) {
		//Debug.Log ("UPDATING " + i.name);
		bool useCoin = i.price == 0;;

		if (i.isActivatable()) {
			setBought ();
		} else if (!i.isUnlocked ()) {
			setLocked ();
		} else {
			setCoins (useCoin ? (i.coins + "") : (i.price + " €"));
			setCoinsImage (useCoin);
			setBuyable ();
		}

	}
}
