using UnityEngine;
using System.Collections;

/**
 * This class allows to the main camera to follow the
 * Player in the Game Scene. Thats' the reason why it moves only 
 * in horizontal way.
 */
public class Camera_FollowPlayer : MonoBehaviour {

	private float offsetX;
	private Transform target;

	// Initialize the player and it's offset from the MainCamera
	void Start () {
		GameObject player_go = GameObject.FindGameObjectWithTag ("Player");
		if (player_go == null) {
			Debug.LogError("No elements with tag 'Player'");
			return;
		}
		target = player_go.transform;
		offsetX = transform.position.x - target.position.x;
	}
	
	// Follow the player on the X axe.
	void Update () {
		if (target != null) {
			Vector3 newPos = transform.position;
			newPos.x = target.position.x + offsetX;
			transform.position = newPos;
		}
	}
}
