using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int level = LevelManager.getInstance ().getLevel ();
		GetComponent<Text> ().text = "lvl " + level;
	}
}
