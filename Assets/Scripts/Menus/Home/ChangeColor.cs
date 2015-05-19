using UnityEngine;
using System.Collections;

/*
 * This script allows to change gradually the color 
 * of the sprite that holds it.
 */
public class ChangeColor : MonoBehaviour {

	IEnumerator Start () {
		Color start = Color.white;
		Color end = Color.gray;

		while (true) {
			yield return StartCoroutine(ColorObject(transform, start, end, 1f));
			yield return StartCoroutine(ColorObject(transform, end, start, 1f));
		}
	}


	IEnumerator ColorObject (Transform thisTransform, Color start, Color end, float time) {
		float i = 0.0f;
		float rate = 1.0f / time;
		while (i < 1.0f) {
			i += Time.deltaTime * rate;
			GetComponent<SpriteRenderer>().color = Color.Lerp(start, end, i);
			yield return null; 
		}
	}
}
