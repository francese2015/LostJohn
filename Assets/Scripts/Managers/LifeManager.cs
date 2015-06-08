using UnityEngine;
using System.Collections;

public class LifeManager : MonoBehaviour {
		
	private static int lifes = DEFAULT_LIFES;

	private static float lastAccess = 0;

	public const int DEFAULT_LIFES = 10;
	
	private static LifeManager instance = null; 
	
	private LifeManager(){
		load ();
	}
	
	public static LifeManager getInstance(){
		if(instance == null){
			instance = new LifeManager();
		}
		return instance;
	}
	
	public void increaseLifes() {
		if (lifes < DEFAULT_LIFES) {
			lifes++;
			save ();
		}
	}

	public void increaseLifes(int l) {
		if (l < 0) {
			return;
		}
		if (lifes + l > DEFAULT_LIFES) {
			lifes = DEFAULT_LIFES;
		} else {
			lifes += l;
		}
		save ();
	}

	public int getLifes(){
		return lifes;
	}

	public void setLifes(int l) {
		lifes = l;
		save ();
	}

	public void reduceLifes(){
		if (lifes > 0) {
			lifes--;
		} else {
			lifes = 0;
			lastAccess = Time.time;
			//throw new System.AccessViolationException("Your lifes are finished");
		}
		save ();
	}

	public void save() {
		StorageManager.storeOnDisk(StorageManager.LIFES, lifes);
		StorageManager.storeOnDisk (StorageManager.LAST_ACCESS, lastAccess);
	}
	
	public void load() {
		setLifes(StorageManager.loadIntFromDisk (StorageManager.LIFES));
		lastAccess = StorageManager.loadFloatFromDisk (StorageManager.LAST_ACCESS);
	}
}

