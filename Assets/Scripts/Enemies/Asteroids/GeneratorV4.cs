using UnityEngine;
using System.Collections;

/*
 * This script allow to generate gameobjects randomly 
 * along the vertical axe. Two gameobjects will be generated 
 * after a random time, which must to be grater than 'timeMin'
 * param and lesser than 'timeMax' param. 
 */
public class GeneratorV4 : MonoBehaviour {

	private const int MIN_TIME_MIN = 40;
	private const int MIN_TIME_MAX = 60;
	private int TIME_REDUCER = 4;
	
	public GameObject asteroidTransform;
	public GameObject[] coinGroups;

	// good start values: 80 and 100
	public int timeMin, timeMax;

	// random value between timeMin and timeMax
	// to add to timeMin to generate a gameObject.
	// For actual usage a value of 70 seems good.
	public int timeOffset; 

	private const int ASTEROID_PROBABILITY = 80;
	private const int COINS_PROBABILITY = 100 - ASTEROID_PROBABILITY;

	//number of asteroids created
	private int numAsteroids = 0;

	void FixedUpdate () {
		timeOffset--;

		if(timeOffset < 0){
			GameObject toInstantiate = instantiateRandomObject();
			Instantiate(toInstantiate, where(),transform.rotation);
			checkDifficulty();
			wait();
		}
	}

	// Sets a new offset random value.
	void wait() { 
		timeOffset = Random.Range (timeMin, timeMax);
	}

	// Generates the random Y position.
	private Vector3 where(){
		float yrand =  Random.Range (-1.5f, 1.5f);
		return new Vector3(transform.position.x, yrand, transform.position.z);
	}

	private GameObject instantiateRandomObject() {
		ArrayList probs = new ArrayList();
		probs.Add (ASTEROID_PROBABILITY);
		probs.Add (COINS_PROBABILITY);

		int randomObj = Utility.randomElementWithProbability (probs);
		//Debug.Log (randomObj == 0 ? "ASTEROID" : "COIN");
		return randomObj == 0 ? asteroidTransform : randomCoinGroup();
	}

	/* 
	 * Randomly choose a coin group and increade the 
	 * time to generate the next item
	 */
	private GameObject randomCoinGroup() {
		if (coinGroups.Length != 0) {		
			wait ();
			int rand = Random.Range (0, coinGroups.Length);
			return coinGroups [rand];
		}
		return asteroidTransform;
	}

	/**
	 * increase the number of asteroids. Every 10 asteroids, the 
	 * timeMin and timeMax variables are decreased until they reach their min values.
	 */
	private void checkDifficulty() {
		numAsteroids++;
		Debug.Log ("#" + numAsteroids);

		if (numAsteroids % 10 == 0) {
			if (timeMin - TIME_REDUCER > MIN_TIME_MIN) {
				Debug.Log("Increasing difficulty!");
				timeMin -= TIME_REDUCER;
			}

			if (timeMax - TIME_REDUCER > MIN_TIME_MAX) {
				timeMax -= TIME_REDUCER;
			}

			if (numAsteroids >= 70 && TIME_REDUCER > 0) {
				TIME_REDUCER--;
				Debug.Log("Time reducer = " + TIME_REDUCER);
			}
		}
	}
}





