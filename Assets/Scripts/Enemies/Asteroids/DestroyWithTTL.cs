using UnityEngine;
using System.Collections;

/*
 * This script allow to destroy the gameobject that hold it
 * after a given time-to-live.
 */
public class DestroyWithTTL : MonoBehaviour {

	public float timeToLive = 3f;

	// Destroy the object after 'timeToLive' time.
	void Start () {
		Destroy (gameObject, timeToLive);
	}
}
