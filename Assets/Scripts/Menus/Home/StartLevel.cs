using UnityEngine;
using System.Collections;

/**
 * This script make the game effectively start. When it is triggered
 * the actual score is resetted and the right game level is loaded.
 */
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