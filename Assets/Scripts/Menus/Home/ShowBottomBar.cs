using UnityEngine;
using System.Collections;

/**
 * This script allows to move the bottom bar in the HOme screen.
 */
public class ShowBottomBar : MonoBehaviour {

	private GameObject settingButton;
	private GameObject leaderboardButton;
	private GameObject shopButton;

	private bool hidden = true;

	// bottom bar initial and final position 
	public Transform startPosition;
	public Transform endPosition;
	
	// the transaction time 
	public float timeInSec;
	private Vector3 velocity;
	// the transaction tollerance distance
	private float TOLLERANCE_FACTOR = 0.1f;

	// target object to move
	public GameObject objectToMove;

	void Start() {
		timeInSec *= Time.deltaTime;
		leaderboardButton = GameObject.FindGameObjectWithTag (GameTags.leaderboardButton);
		shopButton = GameObject.FindGameObjectWithTag (GameTags.shopButton);
		settingButton = GameObject.FindGameObjectWithTag (GameTags.settingButton);

	}
	
	public void moveBar() {
		while (!checkStopAnimation()) {
			move ();
		}
	}

	private void move() {
		if (hidden) {
			objectToMove.transform.position = Vector3.SmoothDamp (transform.position, endPosition.position, ref velocity, timeInSec);
			StartCoroutine(enableButtons(true));
		} else {
			objectToMove.transform.position = Vector3.SmoothDamp (transform.position, startPosition.position, ref velocity, timeInSec);
			StartCoroutine(enableButtons(false));
		}
	}

	/* 
	 * When the bar is moving check the tollerance factor. If the distance to cover is 
	 * lesser than the tollerance factor, the final position is considered reached and the
	 * animation stops.
	 */
	private bool checkStopAnimation() {
		Vector3 myEnd = (hidden ? endPosition.position : startPosition.position);

		float deltaX = Mathf.Abs (objectToMove.transform.position.x - myEnd.x);
		float deltaY = Mathf.Abs (objectToMove.transform.position.y - myEnd.y);
		
		if (deltaX <= TOLLERANCE_FACTOR && deltaY <= TOLLERANCE_FACTOR) {
			objectToMove.transform.position = myEnd;
			hidden = !hidden;
			return true;
		} else {
			return false;
		}
	}
	/*
	 * enable and disable the menu buttons when the bar is on and off.
	 * This solve the issue #19
	 */
	private IEnumerator enableButtons(bool state) {
		// used to delay the activation
		yield return new WaitForSeconds (0.1f);

		settingButton.GetComponent<BoxCollider2D> ().enabled = state;
		leaderboardButton.GetComponent<BoxCollider2D> ().enabled = state;
		shopButton.GetComponent<BoxCollider2D> ().enabled = state;
	}
}
