using UnityEngine;
using System.Collections;

public class PauseResume : MonoBehaviour {

	public GameObject pauseWindow;

	void Update () {
		// when click down 
		if (Input.GetMouseButtonDown (0)) {
			if (Utility.checkInput(gameObject)) {
				Destroy(pauseWindow, 0.1f);
				Time.timeScale = 1;
			}
		}
	}
}
