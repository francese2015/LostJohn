using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HiddenTimer : MonoBehaviour {

	private Text text;

	void Start () {
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (LifeManager.getInstance ().getLifes () < LifeManager.DEFAULT_LIFES) {
			text.text = LifeRegenerator.getRemainingTime ();
		} else {
			text.text = "";
		}
	}
}
