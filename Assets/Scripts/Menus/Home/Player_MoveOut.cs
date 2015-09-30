using UnityEngine;
using System.Collections;

/**
 * This script is used when the user taps on the ship (Home) to start the game.
 * This script, holded by a sprite player, move the player itself on the right
 * making it colliding a collider which will start the game.
 */
public class Player_MoveOut : MonoBehaviour {

	public float speed = 3;

	
	void Update () {
		transform.Translate(speed * Time.deltaTime, 0, 0);
	}

}
