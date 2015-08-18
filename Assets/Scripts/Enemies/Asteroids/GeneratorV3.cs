using UnityEngine;
using System.Collections;

/*
 * This script allow to generate gameobjects randomly 
 * along the vertical axe. Two gameobjects will be generated 
 * after a random time, which must to be grater than 'timeMin'
 * param and lesser than 'timeMax' param. 
 */
public class GeneratorV3 : MonoBehaviour {
	
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


	void FixedUpdate () {
		timeOffset--;

		if(timeOffset < 0){
			GameObject toInstantiate = instantiateRandomObject();
			Instantiate(toInstantiate, where(),transform.rotation);
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
		wait ();
		int rand = Random.Range (0, coinGroups.Length);
		return coinGroups [rand];
	}
}





