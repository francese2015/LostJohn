using UnityEngine;
using System.Collections;

public class StartLevel : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter2D(Collider2D coll){
		ScoreManager score = ScoreManager.getInstance ();
		score.resetScore ();
		score.save ();

		GameLevelManager game = GameLevelManager.getInstance ();
		game.loadLevel ();
	}
}