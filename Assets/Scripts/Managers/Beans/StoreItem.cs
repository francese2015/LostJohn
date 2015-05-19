public class StoreItem {

	private string name;

	private int priceInCoins;

	private int priceInRedCoins;

	private string description;

	private bool unlocked;

	public StoreItem (string name, int coinPrice, string description) {
		this.name = name;
		this.priceInCoins = coinPrice;
		this.priceInRedCoins = -1;
		this.description = description;
		this.unlocked = false;
	}


	public StoreItem (string name, int coinPrice, int redCoinPrice, string description, bool unlocked) {
		this.name = name;
		this.priceInCoins = coinPrice;
		this.priceInRedCoins = redCoinPrice;
		this.description = description;
		this.unlocked = unlocked;
	}

	//FIXME: must add getters and setters

	public string getName() {
		return this.name;
	}


	public int getPriceInCoins() {
		return this.priceInCoins;
	}

	public int getPriceInRedCoins() {
		return this.priceInRedCoins;
	}

	public string getDescription() {
		return this.description;
	}

	public bool isUnlocked() {
		return this.unlocked;
	}

	public void setUnlocked( bool unlock) {
		this.unlocked = unlock;
	}

}


