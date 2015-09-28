using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

	private float TOLLERANCE_FACTOR = 0.1f;
	private Vector3 velocity;

	// flag to move the target
	private bool moving;
	private bool canMove;


	public GameObject camera;
	public Transform homePos;

	private static Vector3 actualPos;
	private static GameObject source;
	private static GameObject target;

	/**
	 * When the camera is moved from a point to another source and target objects
	 * can need to be activated before the camera goes on them.
	 */
	public static void setActualPosition(Vector3 pos, GameObject objToActivate, GameObject objToDeactivate) {
		actualPos = pos;
		source = objToDeactivate;
		target = objToActivate;
	}

	void Update () {
		if (Input.GetKey (KeyCode.Escape)) {
			//if already in home then exit
			if (isHome()) {
				Debug.Log("Exit");
				Application.Quit();
			// if not in home then go to it
			} else {
				Debug.Log("Will move camera to Home");
				if(!moving) {
					canMove = true;

					if (target != null) {
						target.SetActive(true);
					}

				}
			}
		}

		if (canMove) {
			moving = true;
			moveCameraToHome();
			checkStopAnimation();
		}
	}

	private void moveCameraToHome() {
		camera.transform.position = Vector3.SmoothDamp (camera.transform.position, homePos.position, ref velocity, 0.1f);
	}


	
	/**
	 * Check if the target object's position is equal to the target position
	 * using a tollerance factor to approximate it. Than the object
	 * to deactivate is deactivated.
	 */
	private void checkStopAnimation() {
		if (isHome()) {
			camera.transform.position = homePos.position;
			canMove = false;
			moving = false;

			target = null;
			// deactive source object
			if (source != null) {
				source.SetActive(false);
			}
		}
	}


	private bool isHome() {
		float deltaX = Mathf.Abs (camera.transform.position.x - homePos.position.x);
		float deltaY = Mathf.Abs (camera.transform.position.y - homePos.position.y);
		return deltaX <= TOLLERANCE_FACTOR && deltaY <= TOLLERANCE_FACTOR;
	}
}
