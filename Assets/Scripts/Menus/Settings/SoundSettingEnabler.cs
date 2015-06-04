using UnityEngine;
using System.Collections;

/**
 * This script is respondible for enabling and disabling the Home sounds
 * and setting the appropriate layout to the Sound button in the setting bar.
 */
public class SoundSettingEnabler : MonoBehaviour {

	private string myName;

	private AudioManager audioManager;
	private SpriteRenderer renderer;

	public Sprite soundOn;
	public Sprite soundOff;


	void Start () {
		myName = gameObject.name;
		audioManager = AudioManager.getInstance ();
		renderer = GetComponent<SpriteRenderer> ();
		setGraphicButton ();
	}
	
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if (checkInput () == myName) {
				invertState();
			}
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


	private void setGraphicButton() {
		bool sound = audioManager.canPlaySounds();
		renderer.sprite = (sound ? soundOn : soundOff);
	}
	
	private void invertState() {
		bool sound = audioManager.canPlaySounds();
		audioManager.setSounds (!sound);
		setGraphicButton ();
	}

}
