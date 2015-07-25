public class ShopItem {

	// items like extralife no need to save 
	// their state because they can always be bought 
	public bool ALWAYS_AVAILABLE;

	public Action action;

	public string name;
	public string description;
	public int coins;
	public double price;

	// level needed to make this item buyable
	public int lvlToUnlock;

	// an item is activatable when has been bought
	public bool activatable;

	// an item is permanent if cannot be bought again
	public bool permanent;


	public ShopItem () {
	}

	public void use() {
		if (action != null) {
			action.act ();
		}
	}

	public void setAction(Action a) {
		this.action = a;
	}


	public Action getAction() {
		return this.action;
	}

	public bool isUnlocked() {
		return LevelManager.getInstance ().getLevel () >= lvlToUnlock;
	}

	public bool isBought() {
		return activatable;
	}


	public bool canBeBought() {
		return this.isUnlocked () && !(this.isBought () && permanent);
	}


	public bool isActivatable() {
		return activatable;
	}
}


