using UnityEngine;
using System.Collections;

/**
 * This script belongs to the echanical arm in the 
 * Home scene. enables and disables the objects in input
 * to show just one of them per time.
 */
public class AnimateScreen : MonoBehaviour {


	// Time of the mechanical arm's screen refreshing.
	private int milliSec = 3;

	// The object to show on the screen
	public GameObject text1;
	public GameObject text2;

	// Time from the last screen update.
	private float lastCall;

	/* Initialize the lastCall and
	 * enables the first object and 
	 * disables the second one.
	 */
	void Start () {
		lastCall = Time.time;
		text1.SetActive (true);
		text2.SetActive (false);
	}

	/**
	 * Alternately enables objects.
	 */
	void Update () {
		if (Time.time - lastCall >= milliSec) {
			change();
			lastCall = Time.time;
		}
	}

	private void change() {
		text1.SetActive (!text1.activeSelf);
		text2.SetActive (!text2.activeSelf);
	}

}
