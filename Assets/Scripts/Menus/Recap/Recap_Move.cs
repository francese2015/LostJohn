using UnityEngine;
using System.Collections;

/**
 * Script invocked byt the recap menu to animate it.
 */
public class Recap_Move : MonoBehaviour {
	// final position
	private Vector3 endPos;

	// animation time
	public float timeInSec = 0.1f;

	// used by smooth function
	Vector3 velocity = Vector3.zero;

	// Use this for initialization
	void Start () {
		endPos = transform.position;
		endPos.y += 3;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.SmoothDamp (transform.position, endPos, ref velocity, timeInSec);
	}
}
