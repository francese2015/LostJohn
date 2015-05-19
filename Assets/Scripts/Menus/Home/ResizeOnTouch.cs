using UnityEngine;
using System.Collections;

public class ResizeOnTouch : MonoBehaviour {

	private float scaleFactor = 1.1f;
	private string myName;
	private bool clicked = false;

	// Use this for initialization
	void Start () {
		myName = gameObject.name;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			if(checkInput() == myName) {
				if(!clicked) {
					clicked = true;
					scaleUp(true);
					clickSound();

				}
			}
		}
		if (Input.GetMouseButtonUp(0)) {
			if(checkInput() == myName) {
				if(clicked) {
					scaleUp(false);
					clicked = false;
				}
			}
		}
	}

	private void scaleUp(bool pressed) {
		if (!pressed) {
			transform.localScale *= scaleFactor;
		} else {
			transform.localScale /= scaleFactor;
		}
	}

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
