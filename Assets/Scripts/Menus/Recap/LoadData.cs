using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadData : MonoBehaviour {

	public Text avoided;
	public Text best;
	public Text coins;
	public Text lifes;
	public Text level;

	public GameObject record;
	
	// Use this for initialization
	void Start () {

		Debug.Log ("record? " + ScoreManager.isLastScoreBest);

		if (ScoreManager.isLastScoreBest) {
			record.SetActive (true);
		} else {
			record.SetActive(false);
		}

		best.text = "" + ScoreManager.getInstance ().getBestScore ();
		avoided.text = "" + ScoreManager.getInstance ().getScore ();

		lifes.color = Color.red;
	//	lifes.text = "x " + LifeManager.getInstance ().getLifes ();

		int exp = LevelManager.getInstance ().getExps ();
		lifes.text = "exp " + exp;
		coins.text = "next " + (LevelManager.getInstance ().NEXT_GOAL - exp);

		level.text = "lvl " + LevelManager.getInstance ().getLevel ();

		CoinsManager.getInstance ().save ();
		ScoreManager.getInstance ().save ();
		ScoreManager.getInstance ().save ();
		LifeManager.getInstance ().save ();
		LevelManager.getInstance ().save ();
	}
	
	// Update is called once per frame
	void Update () {

	}
}
