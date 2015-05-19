using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/**
 * This script belongs to the Text object in the Game scene
 * and is responsable for loading and setting the lifes number.
 */
public class TextLifes_UpdateLifes : MonoBehaviour {

	void Start () {
		Text text = GetComponent<Text> ();
		text.text = "x " + LifeManager.getInstance ().getLifes ();
	}
}
