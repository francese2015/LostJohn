	using UnityEngine;
using System.Collections;

/**
 * This script allow to load the recap menu after the game is finished.
 */
public class LoadRecap : MonoBehaviour {
	
	public GameObject recap;
	public Transform startPos;

	// objects list to set inactive
	public GameObject[] toDeactivate;

	/*
	 * Instantiate the recap menu and put it as child of main camera
	 */
	public void loadRecap() {
		deactivate ();
		GameObject.Instantiate (recap, startPos.position, Quaternion.identity);
		//recap.transform.parent = GameObject.FindGameObjectWithTag("MainCamera").transform;
	}

	private void deactivate() {
		for (int i = 0; i < toDeactivate.Length; i++) {
			toDeactivate[i].gameObject.SetActive(false);
		}
	}
}
