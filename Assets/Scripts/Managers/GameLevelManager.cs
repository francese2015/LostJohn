using UnityEngine;
using System.Collections;

public class GameLevelManager {

	public const int FIRST_LEVEL = 1;
	public const int HOME = 0;
	private static int level;

	private LifeManager lifes;
	private ScoreManager score;

	private static GameLevelManager instance = null;


	private GameLevelManager() {
		score = ScoreManager.getInstance ();
		lifes = LifeManager.getInstance ();
		load ();
		if (level == 0) {
			setLevel(FIRST_LEVEL);
		}
		save ();
	}
	
	public static GameLevelManager getInstance(){
		if(instance == null){
			instance = new GameLevelManager();
		}
		return instance;
	}


	public void loadLevel(){
		load ();
		if (lifes.getLifes() > 0) {
			lifes.reduceLifes();
			score.resetScore();
			Application.LoadLevel (level);
		} else {
			Application.LoadLevel (HOME);
		}
	}
	
	
	public void loadHome() {
		Application.LoadLevel (HOME);
	}
	


	private void setLevel(int l) {
		level = l;
		save ();
	}

	public int getLevel() {
		return level;
	}


	public void save() {
		StorageManager.storeOnDisk (StorageManager.GAME_LEVEL, level);
	}
	
	public void load() {
		setLevel(StorageManager.loadIntFromDisk(StorageManager.GAME_LEVEL));
	}
}
