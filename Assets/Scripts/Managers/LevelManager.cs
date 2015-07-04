using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
		
	public const int STARTING_GOAL = 50;

	private const float LEVEL_UP_FACTOR = 1.5f;

	public int NEXT_GOAL = STARTING_GOAL;

	private int level = 1;

	private int exp = 0;

	private bool levelIncreased = false;

	private static LevelManager instance = null; 
	
	private LevelManager(){
		load ();
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
		checkLevel ();
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


	public int getExpToNextLevel() {
		return NEXT_GOAL - exp;
	}


	public int getExptInPercentage() {
		//e.g   next = 10
		// 		range = 30
		//		result = 33%
		int next = NEXT_GOAL - getExpToNextLevel ();
		int range = NEXT_GOAL - getPreviousGoal ();
		return (next / range) * 100; 
	}

	public int getNextGoal() {
		return NEXT_GOAL;
	}

	private void setNextGoal(int ng) {
		if (ng > STARTING_GOAL) {
			NEXT_GOAL = ng;
		} else {
			NEXT_GOAL = STARTING_GOAL;
		}
	}


	public int getPreviousGoal() {
		return (int) (NEXT_GOAL / LEVEL_UP_FACTOR);
	}

	public bool isLevelIncreased() {
		return levelIncreased;
	}

	private void checkLevel(){
		if (exp >= NEXT_GOAL) {
			level++;
			NEXT_GOAL = (int)(NEXT_GOAL * LEVEL_UP_FACTOR);
			StorageManager.storeOnDisk(StorageManager.LEVELUP, 1);
			save ();
		} else {
			StorageManager.storeOnDisk(StorageManager.LEVELUP, 0);
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
		exp = StorageManager.loadIntFromDisk (StorageManager.EXP);
		setNextGoal(StorageManager.loadIntFromDisk (StorageManager.NEXT_GOAL));
		//Debug.Log("caricato dal disco [lvl = " + level  + "] - [exp = " + exp + "] - [next goal = " + NEXT_GOAL + "]");
	}

}

