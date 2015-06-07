using UnityEngine;
using System.Collections;

/**
 * This script can be applied to every object and allows 
 * to move them on X axe hust setting a positive/negative speed value.
 */
public class MoveOnX : MonoBehaviour {

	public float speed = -1f;
	private	Vector3 newPos;
		 
	void Start () {
		newPos = transform.position;
	}
	
	void Update () {
		newPos.x += speed * Time.deltaTime;
		transform.position = newPos;
	}
}
