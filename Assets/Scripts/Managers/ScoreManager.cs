using UnityEngine;
using System.Collections;

public class ScoreManager {

	private int score = 0;

	private int coins = 0;

	private int bestScore = 0;

	public static bool isLastScoreBest = false;
	
	private static ScoreManager instance = null; 

	private ScoreManager(){
	}

	public static ScoreManager getInstance(){
		if(instance == null){
			instance = new ScoreManager();
			instance.load ();
			//instance.save ();
		}
		return instance;
	}
	

	public void resetScore() {
		this.score = 0;
		this.coins = 0;
	}


	public void increaseActualCoin() {
		this.coins++;
	}

	public void increaseScore() {
		this.score++;
		Debug.LogWarning ("ScoreManager dice: SCORE = " + score);
	}
	
	public int getScore(){
		return this.score;
	}

	public int getActualCoins() {
		return this.coins;
	}

	public void setBestScore(int bs){
		if (bs > this.bestScore) {
			this.bestScore = bs;
			isLastScoreBest = true;
		} else {
			isLastScoreBest = false;
		}
	}

	public bool checkBestScore() {
		if (this.score > this.bestScore) {
			setBestScore (score);
			isLastScoreBest = true;
		} else {
			isLastScoreBest = false;
		}
		return isLastScoreBest;
	}

	public int getBestScore(){
		return this.bestScore;
	}
	

	public void save() {
		StorageManager.storeOnDisk (StorageManager.SCORE, score);
		StorageManager.storeOnDisk (StorageManager.BEST_SCORE, bestScore);
	}
	
	public void load() {
		score =	(StorageManager.loadIntFromDisk (StorageManager.SCORE));
		setBestScore(StorageManager.loadIntFromDisk (StorageManager.BEST_SCORE));
	}
}

