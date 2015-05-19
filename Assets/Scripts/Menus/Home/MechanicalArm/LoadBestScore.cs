using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/**
 * Script used to load the best score and set it to 
 * the text object holded by this script's owner.
 */
public class LoadBestScore : MonoBehaviour {

	void Start () {
		int best = ScoreManager.getInstance ().getBestScore ();
		GetComponent<Text> ().text = "" + best;
	}
}
