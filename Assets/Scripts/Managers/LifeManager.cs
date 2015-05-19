using UnityEngine;
using System.Collections;

public class LifeManager : MonoBehaviour {
		
	private static int lifes = 10;

	private static float lastAccess = 0;

	public const int DEFAULT_LIFES = 10;

	public const int DEFAULT_REGENERATION_TIME = 5 * 60 * 1000; //5 min

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


	public int getLifes(){
		return lifes;
	}

	public void setLifes(int l) {
		lifes = l;
	}

	public void reduceLifes(){
		if (lifes > 0) {
			lifes--;
		} else {
			lifes = 0;
			lastAccess = Time.time;
			//throw new System.AccessViolationException("Your lifes are finished");
		}
	}
	

	/**
	 * FIXME: if lastAccess - Time.time > DEFAULT_REGENERATION_TIME then true else false
	 */
	public bool canRegenerateLifes(){
		return((lastAccess - Time.time) >= DEFAULT_REGENERATION_TIME);
	}

	public void regenerteLifes(){
		if (canRegenerateLifes()) {
			lifes = DEFAULT_LIFES;
		}
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

