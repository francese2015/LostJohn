using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/**
 * This script loads all necessary data to fill the recap menu
 */
public class LoadData : MonoBehaviour {

	public Text avoided;
	public Text best;
	public Text coins;
	public Text exp;
	public Text level;

	public GameObject record;
	public GameObject levelUp;


	// Use this for initialization
	void Start () {

		Debug.Log ("record? " + ScoreManager.isLastScoreBest);

		// if the performed score is the new best starts the NEW RECORD animation
		if (ScoreManager.isLastScoreBest) {
			record.SetActive (true);
		} 

		if (LevelManager.isLevelUp) {
			//Debug.Log ("level UP OK");
			levelUp.SetActive (true);
		} else {
			levelUp.SetActive (false);
		}

		// sets data in text canvases
		best.text = "" + ScoreManager.getInstance ().getBestScore ();
		avoided.text = "" + ScoreManager.getInstance ().getScore ();
		level.text = "lvl " + LevelManager.getInstance ().getLevel ();
		exp.text = "" + LevelManager.getInstance ().getExpToNextLevel ();
		coins.text = "" + ScoreManager.getInstance ().getActualCoins ();
	}


}
