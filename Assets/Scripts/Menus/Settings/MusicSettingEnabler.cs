using UnityEngine;
using System.Collections;

public class MusicSettingEnabler : MonoBehaviour {

	private string myName;

	private AudioManager audioManager;
	private SpriteRenderer renderer;

	public Sprite musicOn;
	public Sprite musicOff;


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
		bool music = audioManager.canPlayMusic();
		renderer.sprite = (music ? musicOn : musicOff);
	}

	private void invertState() {
		bool music = audioManager.canPlayMusic();
		audioManager.setMusics (!music);
		setGraphicButton ();
	}

}
