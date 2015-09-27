using UnityEngine;
using System.Collections;

/**
 * This script quit the game if ESC button is pressed 
 * and brings the user to the Home. If already in Home 
 * scene the application quits.
 */
public class GameQuit : MonoBehaviour {
	
	void FixedUpdate () {
		if (Input.GetKey (KeyCode.Escape)) {

			if (Application.loadedLevel == 0) {
				Application.Quit ();
			} else {
				//Debug.Log("Clicked BACK. Game is " + (GAME_IN_PAUSE ? "" : " not") + " in pause");
				// pressing back user will not exit but will pause the game
				if (!GameStatus.isGamePaused()) {
					pause();
				} 
			}
		}
	}


	private void pause() {
		GameObject.FindGameObjectWithTag (GameTags.pauseButton).GetComponent<GamePause> ().pauseGame ();
	}
}
