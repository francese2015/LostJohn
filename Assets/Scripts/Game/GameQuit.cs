using UnityEngine;
using System.Collections;

/**
 * This script quit the game if ESC button is pressed 
 * and brings the user to the Home. If already in Home 
 * scene the application quits.
 */
public class GameQuit : MonoBehaviour {

	public static bool GAME_IN_PAUSE;

	void Update () {
		if (Input.GetKey (KeyCode.Escape)) {
			if (Application.loadedLevel == 0) {
				Application.Quit ();
			} else {
				// pressing back user will not exit but will pause the game
				if (!GAME_IN_PAUSE) {
					pause();
				} 
			}
		}
	}


	private void pause() {
		GameObject.FindGameObjectWithTag (GameTags.pauseButton).GetComponent<GamePause> ().pauseGame ();
	}
}
