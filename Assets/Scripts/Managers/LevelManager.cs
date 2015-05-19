using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
		
	public const int STARTING_GOAL = 50;

	private const float LEVEL_UP_FACTOR = 0.2f;

	public int NEXT_GOAL = 0;

	private int level = 1;

	private int exp = 0;

	private static LevelManager instance = null; 
	
	private LevelManager(){
		load ();
		calcNextLevel ();
		save ();
	}
	
	public static LevelManager getInstance(){
		if(instance == null){
			instance = new LevelManager();
		}
		return instance;
	}

	
	public void increaseExp(){
		setExp (this.exp + 1);
	}

	public void increaseExp(int e){
		setExp (this.exp + e);
	}

	private void setExp(int e){
		this.exp = e;
		calcLevel ();
	}
	
	public int getExps(){
		return this.exp;
	}


	private void increaseLevel(){
		this.level++;
	}
	
	public int getLevel(){
		return this.level;
	}

	public void setLevel(int l) {
		this.level = l;
	}

	private void calcLevel(){
		if (this.exp >= NEXT_GOAL) {
			increaseLevel();
			calcNextLevel();
		}
	}

	private void calcNextLevel(){
		if (this.level == 1) {
			NEXT_GOAL = STARTING_GOAL;
		} else {
			NEXT_GOAL += Mathf.RoundToInt(NEXT_GOAL * LEVEL_UP_FACTOR); 
		}
	}

	public void save() {
		StorageManager.storeOnDisk (StorageManager.LEVEL, this.level);
		StorageManager.storeOnDisk (StorageManager.EXP, this.exp);
		StorageManager.storeOnDisk (StorageManager.NEXT_GOAL, this.NEXT_GOAL);

	}
	
	public void load() {
		int l = StorageManager.loadIntFromDisk (StorageManager.LEVEL);
		setLevel(l > 0 ? l : 1);
		setExp(StorageManager.loadIntFromDisk (StorageManager.EXP));
		this.NEXT_GOAL = StorageManager.loadIntFromDisk (StorageManager.NEXT_GOAL);
	}

}

