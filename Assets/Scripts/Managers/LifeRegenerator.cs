using UnityEngine;
using System.Collections;

public class LifeRegenerator : MonoBehaviour {
	// Default time between two life regeneration calls.
	System.TimeSpan DEFAULT_REGENERATION_TIME = new System.TimeSpan (0, 2, 0);

	// DateTime object that represents the last regeneration date and time.
	System.DateTime lastRegeneration;

	// Variable used to store the actual system time.
	System.DateTime now;

	// Effective time between two life regeneration calls.
	System.TimeSpan regenerationTime;

	LifeManager lifeManager;

	public const int DEFAULT_LIFES = 10;

	void Start () {
		load ();
		save ();
		regenerationTime = DEFAULT_REGENERATION_TIME;
		lifeManager = LifeManager.getInstance ();

		//lastRegeneration = System.DateTime.Now;
	}


	// Update is called once per frame
	void Update () {
		regenerationCheck ();
	}

	/*
	 * If enough time is passed grom the last life regeneration 
	 * then a new life is regenerated
	 */
	private void regenerationCheck() {
		System.TimeSpan diff = System.DateTime.Now.Subtract (lastRegeneration);

		if (diff.CompareTo(regenerationTime) >= 0) {
			rigenerateLifes(diff);
		} 
		/*else {
			Debug.Log("Aspetta ancora " + regenerationTime.Subtract(diff));
		}
		*/
	}

	/**
	 * Calculate and regenerates as much lifes as much time has been passed 
	 * from the last life regeneration call.
	 */
	private void rigenerateLifes(System.TimeSpan diffTime) {
	
		double diffSec = diffTime.TotalSeconds;
		double regenerationTimeInSec = regenerationTime.TotalSeconds;
		int lifes = (int) (diffSec / regenerationTimeInSec);

		Debug.LogWarning ("Lifes = " + lifes);

		lifeManager.increaseLifes (lifes);
		lastRegeneration = System.DateTime.Now;
		save();

	}

	public void save() {
		StorageManager.storeDateOnDisk (lastRegeneration);
	}

	public void load() {
		lastRegeneration = StorageManager.loadDateFromDisk ();
	}
}
