using UnityEngine;
using System.Collections;

/**
 * On MouseUp event the LostJohn Facebook link
 * will be opened.
 */
public class Facebook_Link : MonoBehaviour {

	void OnMouseUp(){
		Application.OpenURL ("https://www.facebook.com/pages/Lost-John/302264893256518?ref=hl");
	}
}
