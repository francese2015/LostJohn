using UnityEngine;
using System.Collections;

/**
 * This script is invoked when the game start:
 * When the user cliks on the screen the foolowing actions are made:
 *  - the Tap sprite is destroyed
 *  - the player's movement script is activated;
 *  - the asteroig generator is activated.
 * In this way the game doesn't start until the user taps the screen.
 */
public class PressToStart : MonoBehaviour {

	private GameObject player;
	private GameObject tap;

	public GameObject asteroidGenerator;

	//object to rotate
	public float time = 10;
	public Transform playerTargetPos;
	


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		tap = GameObject.FindGameObjectWithTag ("tap");
		ScoreManager.getInstance ().resetScore ();
	}

	// Update is called once per frame
	void Update () {
		anim();
		if(Input.GetMouseButton(0)){
			startToPlay();
		}
	}

	/**
	 * Move the player's sprite from left to right for the given time.
	 * When the target position is reached, the script Camera_FollowTarget
	 * is enabled.
	 */
	void anim(){
		
		if(player != null) {

			float x = Mathf.Lerp(player.transform.position.x, playerTargetPos.position.x, time);
			Vector3 newPos = player.transform.position;
			newPos.x = x;
			player.transform.position = newPos;

			if (player.transform.position.x >= (playerTargetPos.position.x - 0.01)) {
				GetComponent<Camera_FollowPlayer>().enabled = true;
			}
		}
	}
	
	/**
	 * This method destroys the tap sprite, and enables the 
	 * Player_Movement script and the GeneratorV2 script.
	 */
	void startToPlay(){
		if(player != null) {
			player.GetComponent<Player_Movement> ().enabled = true;
			asteroidGenerator.GetComponent<GeneratorV3> ().enabled = true;
			Destroy (tap);
		}
	}



}
