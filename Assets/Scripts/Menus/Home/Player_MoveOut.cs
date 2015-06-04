using UnityEngine;
using System.Collections;

/**
 * This script is used when the user taps on the ship (Home) to start the game.
 * This script, holded by a sprite player, move the player itself on the right
 * making it colliding a collider which will start the game.
 */
public class Player_MoveOut : MonoBehaviour {

	public float time = 1;
	private bool canMove;
	
	void Start () {
		canMove = false;
	}
	
	void Update () {
		if (canMove) {
			transform.Translate(3 * Time.deltaTime, 0, 0);
		}
	}

	/**
	 * This method is invocked by external objects to
	 * start the animation.
	 */
	public void anim() {
		canMove = true;
	}


}
