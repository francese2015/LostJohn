using UnityEngine;
using System.Collections;

/**
 * This script allows to put on the Home screen the regeneration life timer 
 * if no more lifes are available. When lifes are restored the ship is shown
 * so the game can start.
 */
public class ShowShipAndTimer : MonoBehaviour {

	private LifeManager lifeManager;
	private bool change = false;

	public GameObject ship;
	public GameObject timer;


	void Start () {
		lifeManager = LifeManager.getInstance();
	}
	
	void FixedUpdate() {
		if (lifeManager.getLifes () == 0) {
			showTimer ();
		} else {
			showShip();
		}
	}

	private void showTimer() {
		if (ship != null && timer != null) {
			timer.SetActive (true);
			ship.SetActive (false);
		}
	}


	private void showShip() {
		if (ship != null && timer != null) {
			// if the frame before the timer was on the screen
			timer.SetActive (false);
			ship.SetActive (true);
		}
	}
}
