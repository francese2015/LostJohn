using UnityEngine;
using System.Collections;

/*
 * This script allow to generate gameobjects randomly 
 * along the vertical axe. Two gameobjects will be generated 
 * after a random time, which must to be grater than 'timeMin'
 * param and lesser than 'timeMax' param. 
 */
public class GeneratorV2 : MonoBehaviour {
	
	public GameObject asteroidTransform;

	// good start values: 80 and 100
	public int timeMin, timeMax;

	// random value between timeMin and timeMax
	// to add to timeMin to generate a gameObject.
	// For actual usage a value of 70 seems good.
	public int timeOffset; 

	void Update () {
		timeOffset--;

		if(timeOffset < 0){
			Instantiate(asteroidTransform, where(),transform.rotation);
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
}





