using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {
		
	public const int DEFAULT_MULTIPLIER = 1;

	private static int multiplier = 1;

	private static int score = 0;

	private static int bestScore = 0;

	public static bool isLastScoreBest = false;
	
	private static ScoreManager instance = null; 

	private ScoreManager(){
		load ();
		save ();
	}

	public static ScoreManager getInstance(){
		if(instance == null){
			instance = new ScoreManager();
		}
		return instance;
	}
	

	public void resetScore() {
		score = 0;
	}
	
	public void increaseScore(){
		setScore (score + (1 * multiplier));
	}

	public void increaseScore(int s){
		setScore (score + (s * multiplier));
	}

	private void setScore(int s){
		score = s;
	}

	public int getScore(){
		return score;
	}


	public void setBestScore(int bs){
		if (bs > bestScore) {
			bestScore = bs;
			isLastScoreBest = true;
			Debug.Log("NEW RECOOORD " + isLastScoreBest);
			save ();
		} else {
			isLastScoreBest = false;
		}
	}

	public void checkBestScore() {
		if (score > bestScore) {
			setBestScore (score);
			isLastScoreBest = true;
		} else {
			isLastScoreBest = false;
		}
	}

	public int getBestScore(){
		return bestScore;
	}


	public void increaseMultiplier(){
		multiplier++;
	}

	public void setMultiplier(int m){
		multiplier = m;
	}

	public void restoreMultiplier(){
		multiplier = DEFAULT_MULTIPLIER;
	}

	public void save() {
		StorageManager.storeOnDisk (StorageManager.SCORE, score);
		StorageManager.storeOnDisk (StorageManager.BEST_SCORE, bestScore);
	}
	
	public void load() {
		setScore	(StorageManager.loadIntFromDisk (StorageManager.SCORE));
		setBestScore(StorageManager.loadIntFromDisk (StorageManager.BEST_SCORE));
	}

}

