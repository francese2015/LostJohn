using UnityEngine;
using System.Collections;

/**
 * This script quit the game if ESC button is pressed 
 * and brings the user to the Home. If already in Home 
 * scene the application quits.
 */
public class GameQuit : MonoBehaviour {

	void Update () {
		if (Input.GetKey (KeyCode.Escape)) {
			if (Application.loadedLevel == 0) {
				Application.Quit();
			} else {
				GameLevelManager.getInstance().loadHome();
			}
		}
	}
}
