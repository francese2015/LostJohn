using UnityEngine;
using System.Collections;

/**
 * This script is holded by coin objects and allow them to 
 * start animation when they are collected
 */
public class ObjectCollected : MonoBehaviour {
	// position to reach
	private Vector3 upperPos;
	private bool anim = false;

	// animation speed
	public float speed = 5f;
	// distance to cover
	public float upperJump = 1;
	// explosion animation to instantiate 
	public GameObject explosion;

		
	void Start () {
		upperPos = transform.position;
		upperPos.y += upperJump;
	}

	// when the object is triggered the nimation starts
	void Update() {
		if (anim) {
			transform.position = Vector3.Lerp(transform.position, upperPos, speed * Time.deltaTime);
			explosionCheck();
		}
	}

	void explosionCheck() {
		if (transform.position.y >= upperPos.y - 0.2f) {
			Instantiate(explosion, upperPos, Quaternion.identity);
			Destroy(gameObject);
		}

	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Player") {
			anim = true;
		}
	}

}
