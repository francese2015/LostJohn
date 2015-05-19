using UnityEngine;
using System.Collections;

public class CoinsManager : MonoBehaviour {
		
	public const int DEFAULT_REDCOINS = 3;
	
	private  static int coins = 0;

	private  static int redCoins = 0;

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
	}
	
	public int getCoins(){
		return coins;
	}


	private void setRedCoins(int rc){
		redCoins = rc;
	}
	
	public int getRedCoins(){
		return redCoins;
	}

	public void spendCoins(int amount){
		if(coins < amount){
			throw new System.AccessViolationException("Not enough coins");
			return;
		}
		coins -= amount;
	}

	public bool canSpendCoins(int amount){
		return coins >= amount;
	}


	public void spendRedCoins(int amount){
		if(redCoins < amount){
			throw new System.AccessViolationException("Not enough coins");
			return;
		}
		redCoins -= amount;
	}

	
	public bool canSpendRedCoins(int amount){
		return redCoins >= amount;
	}

	public void save() {
		StorageManager.storeOnDisk (StorageManager.COINS, coins);
		StorageManager.storeOnDisk (StorageManager.REDCOINS, redCoins);
	}

	public void load() {
		setCoins	(StorageManager.loadIntFromDisk(StorageManager.COINS));
		setRedCoins	(StorageManager.loadIntFromDisk (StorageManager.REDCOINS));
	}

}

