using UnityEngine;
using System.Collections;

/**
 * This class is used to simulate the 
 * infinite background scrolling inside the Home menu.
 */
public class BackgroundLooper : MonoBehaviour {

	public GameObject startPoint;
	public float speed = 1f;
	
	// Move this object on the X axe.
	void Update() {
		Vector3 actualPos = transform.position;
		actualPos.x -= speed * Time.deltaTime;
		transform.position = actualPos;
	}

	/**
	 * When the background sprite collide with this box collider
	 * the sprite is moved back at the startPoint.
	 */
	void OnTriggerExit2D(Collider2D other) {
		if (other.name == "edge") {
			transform.position = startPoint.transform.position;
		}
	}
}
