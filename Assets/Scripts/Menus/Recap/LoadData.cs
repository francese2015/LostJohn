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

		if (StorageManager.loadIntFromDisk(StorageManager.LEVELUP) > 0) {
			Debug.Log ("level UP OK");
			levelUp.SetActive (true);
		} else {
			levelUp.SetActive (false);
			Debug.Log("no level up");
		}

		// sets data in text canvases
		best.text = "" + ScoreManager.getInstance ().getBestScore ();
		avoided.text = "" + ScoreManager.getInstance ().getScore ();
		level.text = "lvl " + LevelManager.getInstance ().getLevel ();
		coins.text = "" + ScoreManager.getInstance ().getActualCoins ();
		exp.text = "" + LevelManager.getInstance ().getExpToNextLevel ();
	}


}
