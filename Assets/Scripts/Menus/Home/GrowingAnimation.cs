using UnityEngine;
using System.Collections;

/**
 * This script implements a simple animation to 
 * gradually increase and decrease the sprite's size.
 */
public class GrowingAnimation : MonoBehaviour {

	public float scaleFactor = 1.2f;
	
	IEnumerator Start () {
		Vector3 initialSize = transform.localScale;
		Vector3 finalSize = initialSize * scaleFactor;

		while (true) {
			yield return StartCoroutine(ScaleObject(transform, initialSize, finalSize, 1f));
			yield return StartCoroutine(ScaleObject(transform, finalSize, initialSize, 1f));
		}

	}


	IEnumerator ScaleObject (Transform thisTransform, Vector3 startSize, Vector3 endSize, float time) {
		float i = 0.0f;
		float rate = 1.0f / time;
		while (i < 1.0f) {
			i += Time.deltaTime * rate;
			thisTransform.localScale = Vector3.Lerp(startSize, endSize, i);
			yield return null; 
		}
	}
}
