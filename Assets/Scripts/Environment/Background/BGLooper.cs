using UnityEngine;
using System.Collections;

/**
 * This class is used to simulate the 
 * infinite background scrolling inside the Home menu.
 */
public class BGLooper : MonoBehaviour {

	private float bgOffset = 3f;

	/**
	 * When the background sprite collide with this box collider
	 * the sprite is moved back using as offset
	 * it's width and the number of sprites (bgOffset field)
	 */
	void OnTriggerEnter2D (Collider2D coll) {
		//Debug.Log("Collision with " + coll.name);

		float collWidth = ((BoxCollider2D)coll).size.x;
		float scaleFactor = coll.gameObject.transform.localScale.x;

		float bgWidth = collWidth * scaleFactor;
		//Debug.Log("Collider size = " + collWidth + " and scaleFactor = " + scaleFactor);

		Vector3 pos = coll.transform.position;
		pos.x += bgWidth * bgOffset;
		coll.transform.position = pos;
	}
}
