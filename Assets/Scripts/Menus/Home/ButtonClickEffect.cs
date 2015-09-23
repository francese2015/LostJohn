using UnityEngine;
using System.Collections;

/**
 * This script can be applied to all UI object to resize them when
 * they have been clicked. It increase the sprite's size when clicking 
 * and decreasing it when the clik is finished. 
 */
public class ButtonClickEffect : MonoBehaviour {

	private float scaleFactor = 1.1f;
	private string myName;
	private SpriteRenderer renderer;

	void Start () {
		myName = gameObject.name;
		renderer = gameObject.GetComponent<SpriteRenderer> ();
		if (renderer == null) {
			Debug.LogError("Can't change color because no sprite renderer is attached to this object");
		}
	}
	
	void Update () {
		// when click down 
		if (Input.GetMouseButtonDown(0)) {
			if (Utility.checkInput(gameObject)) {
				StartCoroutine(click ());
			}
		}
	}

	private IEnumerator click() {
		PlayClickSound.play();
		darkerColor (true);
		gameObject.transform.localScale /= scaleFactor;
		yield return new WaitForSeconds (0.15f);
		gameObject.transform.localScale *= scaleFactor;
		darkerColor (false);
	}

	
	/* 
	 * This method change the sprite's color with a darker color if 
	 * the given input is true, else the basic color is backported to white
	 */
	private void darkerColor(bool state) {
		renderer.color = state ? Color.gray : Color.white;
	}

}
