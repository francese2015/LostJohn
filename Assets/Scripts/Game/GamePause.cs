using UnityEngine;
using System.Collections;

public class GamePause : MonoBehaviour {
	
	public GameObject pauseWindow;
	public Vector3 pausePosition; 


	void Update () {
		// when click down 
		if (Input.GetMouseButtonDown (0)) {
			if (Utility.checkInput(gameObject) && GameStatus.isPlayerAlive()) {
				pauseGame();
			}
		}
	}

	public void pauseGame() {
		if (Time.timeScale > 0) {
			Time.timeScale = 0;
			GameStatus.setGameInPause(true);
			//scaleButton(SCALE_FACTOR);
			Instantiate(pauseWindow, pausePosition, Quaternion.identity);
		}/* else {
			Time.timeScale = originalTimeScale;
			scaleButton(-SCALE_FACTOR);
		}*/
	}


	private void scaleButton(float f) {
		if (f > 0) {
			transform.localScale *= f;
		} else {
			transform.localScale /= f;
		}
	}

}
