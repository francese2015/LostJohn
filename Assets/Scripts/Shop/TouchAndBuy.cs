using UnityEngine;
using System.Collections;

/**
 * This script can be applied to all UI object to resize them when
 * they have been clicked. It increase the sprite's size when clicking 
 * and decreasing it when the clik is finished. 
 */
public class TouchAndBuy : MonoBehaviour {

	private float scaleFactor = 1.02f;
	private string myName;
	private bool clicked = false;

	void Start () {
		myName = gameObject.name;
	}
	
	void Update () {
		// when click down 
		if (Input.GetMouseButtonDown(0)) {
			if(checkInput() == myName) {
				if(!clicked) {
					clicked = true;
					scaleUp(true);
					clickSound();

				}
			}
		}
		// when click is finished
		if (Input.GetMouseButtonUp(0)) {
			if(checkInput() == myName) {
				if(clicked) {
					scaleUp(false);
					clicked = false;
				}
			}
		}
	}

	/**
	 * Increase or decrease the object's local size when it is clicked
	 */
	private void scaleUp(bool pressed) {
		if (!pressed) {
			transform.localScale *= scaleFactor;
		} else {
			transform.localScale /= scaleFactor;
		}
	}

	/**
	 * Check if the clicked input is this one.
	 */
	private string checkInput() {
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
		if (hit.collider != null) {
			return hit.collider.gameObject.name;
		} else {
			return null;
		}
	}

	public void clickSound() {
		PlayClickSound.play();
	}

}
