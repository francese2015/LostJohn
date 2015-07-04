using UnityEngine;
using System.Collections;

/**
 * This script is holded by the TAP HERE sprite and is used to move 
 * left and right the sprite itself.
 */
public class TapHere_Movement : MonoBehaviour {

	void Start () {
		StartCoroutine (anim ());
	}

	void OnEnable () {
		StartCoroutine (anim ());
	}

	IEnumerator anim() {
		Vector3 pointA = transform.position;
		Vector3 pointB = new Vector3(pointA.x + 0.3f, pointA.y - 0.3f, 0);
		while (true) {
			// move the sprite rightward
			yield return StartCoroutine(MoveObject(transform, pointA, pointB, 1f));
			// move the sprite leftward
			yield return StartCoroutine(MoveObject(transform, pointB, pointA, 1f));
		}
	}
	
	IEnumerator MoveObject (Transform thisTransform, Vector3 startPos, Vector3 endPos, float time) {
		float i = 0.0f;
		float rate = 1.0f / time;
		while (i < 1.0f) {
			i += Time.deltaTime * rate;
			thisTransform.position = Vector3.Lerp(startPos, endPos, i);
			yield return null; 
		}
	}
}
