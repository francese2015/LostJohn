using UnityEngine;
using System.Collections;

public class CoinsManager : MonoBehaviour {
		
	public const int DEFAULT_REDCOINS = 3;
	
	private  static int coins = 0;
	
	private static CoinsManager instance = null;

	private CoinsManager() {
		load ();
		save ();
	}
	
	public static CoinsManager getInstance(){
		if(instance == null){
			instance = new CoinsManager();
		}
		return instance;
	}


	public void increaseCoins(){
		setCoins (coins + 1);
	}

	public void increaseCoins(int c){
		setCoins (coins + c);
	}

	private void setCoins(int c){
		coins = c;
		save ();
	}
	
	public int getCoins(){
		return coins;
	}

	public void spendCoins(int amount){
		if(coins < amount){
			throw new System.AccessViolationException("Not enough coins");
			return;
		}
		coins -= amount;
		save ();
	}

	public bool canSpendCoins(int amount){
		return coins >= amount;
	}
	

	public void save() {
		StorageManager.storeOnDisk (StorageManager.COINS, coins);
	}

	public void load() {
		setCoins	(StorageManager.loadIntFromDisk(StorageManager.COINS));
	}

}

