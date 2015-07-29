using UnityEngine;
using System.Collections;

public class BackgroundAnim : MonoBehaviour {

	public GameObject startPoint;
	public float speed = 1f;

	private Vector3 translation;

	void Start() {
		translation = new Vector3 (-speed, 0, 0);
	}

	// Move this object on the X axe.
	void Update() {
		transform.Translate (translation);
	}


	/**
	 * When the background sprite collide with this box collider
	 * the sprite is moved back at the startPoint.
	 */
	void OnTriggerExit2D(Collider2D coll) {
		if (coll.name == "edge") {
			transform.position = startPoint.transform.position;
		}
	}
}
