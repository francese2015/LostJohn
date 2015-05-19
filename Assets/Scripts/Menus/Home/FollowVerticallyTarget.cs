using UnityEngine;
using System.Collections;

/**
 * This Scrpt follow a target game object only along the Y axe.
 */
public class FollowVerticallyTarget : MonoBehaviour {

	private float offsetY;
	public Transform target;

	// Use this for initialization
	void Start () {
		offsetY = transform.position.y - target.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null) {
			Vector3 newPos = transform.position;
			newPos.y = target.position.y + offsetY;
			transform.position = newPos;
		}
	}
}
