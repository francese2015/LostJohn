using UnityEngine;
using System.Collections;

public class MenuButtonAction : MonoBehaviour {

	public GameObject bottomBar;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp (0)) {
			if (Utility.checkInput(gameObject)) {
				bottomBar.GetComponent<ShowBottomBar>().moveBar();
			}
		}
	}
}
