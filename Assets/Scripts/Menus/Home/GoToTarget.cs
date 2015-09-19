using UnityEngine;
using System.Collections;

/**
 * This script allow to move an object (the target) 
 * from a position to another, using a specified time.
 * Furthermore, when it moves the target object, it can 
 * activate and/or deactivate an object.
 */
public class GoToTarget : MonoBehaviour {

	// value used to check the arrival position.
	private float TOLLERANCE_FACTOR = 0.1f;

	public GameObject objToActivate;
	public GameObject objToDeactivate;

	public GameObject objectToMove;

	public Transform startPosition;
	public Transform targetPosition;

	// FIXME:
	// In case EventSystem objects are involved in this action
	// it needs to be enabled/disabled to work
	// DON'T KNOW WHY
	public GameObject eventSystem;

	public float timeInSec;

	// vectors usend in the target movement.
	private Vector3 start;
	private Vector3 end;
	private Vector3 velocity;

	// flag to move the target
	private bool moving;
	private bool canMove;


	void Start () {
		//objectToMove = Camera.main.camera.transform;
		start = startPosition.position;
		end = targetPosition.position;
		Vector3 velocity = new Vector3 (0,10,0);
		canMove = false;
		moving = false;
	}


	/* 
	 * During the game, if this script's owner is clicked
	 * the animation start.
	 */
	void Update () {

		if (Input.GetMouseButtonUp (0)) {
			if(checkInput() == gameObject.name) {
				if(!moving) {
					canMove = true;
				}
			}
		}

		if (canMove) {
			moving = true;
			setActive(objToActivate,true);
			move ();
			checkStopAnimation();
		}

	}
	 
	private void move() {
		objectToMove.transform.position = Vector3.SmoothDamp (objectToMove.transform.position, end, ref velocity, timeInSec);
	}

	/**
	 * Check if the target object's position is equal to the target position
	 * using a tollerance factor to approximate it. Than the object
	 * to deactivate is deactivated.
	 */
	private void checkStopAnimation() {
		float deltaX = Mathf.Abs (objectToMove.transform.position.x - end.x);
		float deltaY = Mathf.Abs (objectToMove.transform.position.y - end.y);

		if (deltaX <= TOLLERANCE_FACTOR && deltaY <= TOLLERANCE_FACTOR) {
			objectToMove.transform.position = end;
			canMove = false;
			moving = false;
			setActive(objToDeactivate,false);

			if (eventSystem != null) {
				eventSystem.SetActive (false);
				eventSystem.SetActive (true);
			} 
			CameraManager.setActualPosition(end, objToDeactivate, objToActivate);
		}
	}


	private string checkInput() {
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
		if (hit.collider != null) {
			return hit.collider.gameObject.name;
		} else {
			return null;
		}
	}

	public void setActive(GameObject o, bool b) {
		if (o != null) {
			o.SetActive(b);
		}
	}

}
