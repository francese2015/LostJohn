using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
		
	public const int DEFAULT_MULTIPLIER = 0;

	public const int STARTING_GOAL = 50;

	private const float LEVEL_UP_FACTOR = 1.5f;

	public int NEXT_GOAL = STARTING_GOAL;

	private int level = 1;

	private int exp = 0;

	private float multiplier = DEFAULT_MULTIPLIER;

	private bool levelIncreased = false;

	public static bool isLevelUp = false;

	private static LevelManager instance = new LevelManager();

	int i = 0;
	
	private LevelManager(){
		load ();
	}
	
	public static LevelManager getInstance(){
		return instance;
	}


	public void setMultiplier(float mul) {
		this.multiplier = mul;
		save ();
	}

	public float getMultiplier() {
		return this.multiplier;
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
		save ();
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
		NEXT_GOAL = ng;

	}

	public int calcExtraExp(int exp) {
		return (int) (exp * multiplier);
	}


	public int getPreviousGoal() {
		return (int) (NEXT_GOAL / LEVEL_UP_FACTOR);
	}

	public bool isLevelIncreased() {
		return levelIncreased;
	}

	private void checkLevel(){
		// synchronization
		lock (this) {
			if (exp >= NEXT_GOAL) {
				level++;
				NEXT_GOAL = Mathf.RoundToInt(NEXT_GOAL * LEVEL_UP_FACTOR);
				isLevelUp = true;
				save();
			}
		}
	}

	public void save() {

		StorageManager.storeOnDisk (StorageManager.LEVEL, this.level);
		StorageManager.storeOnDisk (StorageManager.EXP, this.exp);
		StorageManager.storeOnDisk (StorageManager.NEXT_GOAL, this.NEXT_GOAL);
		StorageManager.storeOnDisk (StorageManager.MULTIPLIER, this.multiplier);
	}
	
	public void load() {

		int ng = StorageManager.loadIntFromDisk (StorageManager.NEXT_GOAL);
		NEXT_GOAL = ng < STARTING_GOAL ? STARTING_GOAL : ng;

		exp = StorageManager.loadIntFromDisk (StorageManager.EXP);

		int l = StorageManager.loadIntFromDisk (StorageManager.LEVEL);
		this.level = l > 0 ? l : 1;

		float mul = StorageManager.loadFloatFromDisk (StorageManager.MULTIPLIER);
		this.multiplier = mul;

		isLevelUp = false;

		save ();
		//Debug.Log("caricato dal disco [lvl = " + level  + "] - [exp = " + exp + "] - [next goal = " + NEXT_GOAL + "]");
	}

}

