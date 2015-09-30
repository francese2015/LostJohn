using UnityEngine;
using System.Collections;

/**
 * This script is used when the user taps on the ship (Home) to start the game.
 * This script is holded by the object which contain the sprite player, making it rotate.
 */
public class Player_RollingOut : MonoBehaviour {

	private GameObject player;
	public float speed = 100f;
	
	void Start () {
		player = gameObject;
		speed *= 100;
	}
		
	void Update () {
		player.transform.Rotate(0, 0, -speed * Time.deltaTime);
	}
	

}
