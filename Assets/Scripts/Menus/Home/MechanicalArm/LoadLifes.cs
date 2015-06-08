using UnityEngine;
using UnityEngine.UI;

using System.Collections;

/**
 * Script used to load the lifes number and set it to 
 * the text object holded by this script's owner.
 */
public class LoadLifes : MonoBehaviour {

	LifeManager lifeManager;

	void Start() {
		lifeManager = LifeManager.getInstance ();
	}

	void FixedUpdate () {
		int lifes = lifeManager.getLifes ();
		GetComponent<Text> ().text = "" + lifes;
	
	}
}
