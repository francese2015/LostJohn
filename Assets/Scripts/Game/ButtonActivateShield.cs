using UnityEngine;
using System.Collections;

//This script enables/disables the shield activator button
public class ButtonActivateShield : MonoBehaviour{

	// Use this for initialization
	void Start () {
		checkShield ();
	}


	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			if (Utility.checkInput(gameObject)) {
				GameObject.FindGameObjectWithTag(GameTags.player).GetComponent<PlayerController>().activateShield();
				gameObject.SetActive(false);
			}
		}
	}

	private void checkShield() {
		if (!ShopList.getInstance ().getItem (ShopList.shield).isActivatable ()) {
			gameObject.SetActive(false);
		}
	}
}
