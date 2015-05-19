using UnityEngine;
using System.Collections;

public class ShowBottomBar : MonoBehaviour {

	private bool hidden = true;
	private bool canMove = false, moving = false;

	public Transform startPosition;
	public Transform endPosition;
	
	public float timeInSec;
	private Vector3 velocity;
	private float TOLLERANCE_FACTOR = 0.1f;

	public GameObject objectToMove;

	void Start() {
		timeInSec *= Time.deltaTime;
	}
	

	public void moveBar() {
		while (!checkStopAnimation()) {
			move ();
		}
	}

	private void move() {
		if (hidden) {
			objectToMove.transform.position = Vector3.SmoothDamp (transform.position, endPosition.position, ref velocity, timeInSec);
		} else {
			objectToMove.transform.position = Vector3.SmoothDamp (transform.position, startPosition.position, ref velocity, timeInSec);
		}
	}

	private bool checkStopAnimation() {
		Vector3 myEnd = (hidden ? endPosition.position : startPosition.position);

		float deltaX = Mathf.Abs (objectToMove.transform.position.x - myEnd.x);
		float deltaY = Mathf.Abs (objectToMove.transform.position.y - myEnd.y);
		
		if (deltaX <= TOLLERANCE_FACTOR && deltaY <= TOLLERANCE_FACTOR) {
			objectToMove.transform.position = myEnd;
			canMove = false;
			moving = false;
			hidden = !hidden;
			return true;
		} else {
			return false;
		}
	}
}
