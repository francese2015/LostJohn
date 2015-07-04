using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadCoins : MonoBehaviour {

	private Text textField;

	void Start () {
		textField = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		textField.text = "" + CoinsManager.getInstance ().getCoins ();
	}
}
