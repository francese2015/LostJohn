public class ShopItem {

	public Action action;

	public string name;
	public string description;
	public int coins;
	public double price;
	public int lvlToUnlock;
	public bool available;
	public bool activatable;
	public bool permanent;


	public ShopItem () {
	}

	public void use() {
		action.act ();
	}

	public void setAction(Action a) {
		this.action = a;
	}


	public Action getAction() {
		return this.action;
	}

}


