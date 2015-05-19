using UnityEngine;
using UnityEngine.UI;

using System.Collections;

/**
 * Script used to load the lifes number and set it to 
 * the text object holded by this script's owner.
 */
public class LoadLifes : MonoBehaviour {

	void Start () {
		int lifes = LifeManager.getInstance ().getLifes ();
		GetComponent<Text> ().text = "" + lifes;
	
	}
}
